namespace EVE
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;
	using System.Web;

	/// <summary>
	/// A list of items
	/// </summary>
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class ItemList : IDictionary<invtype, int>
	{
		private Dictionary<invtype, int> _items;

		public ICollection<invtype> Keys
		{
			get
			{
				return ((IDictionary<invtype, int>)_items).Keys;
			}
		}

		public ICollection<int> Values
		{
			get
			{
				return ((IDictionary<invtype, int>)_items).Values;
			}
		}

		public int Count
		{
			get
			{
				return ((IDictionary<invtype, int>)_items).Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IDictionary<invtype, int>)_items).IsReadOnly;
			}
		}

		public int this[invtype key]
		{
			get
			{
				return ((IDictionary<invtype, int>)_items)[key];
			}

			set
			{
				((IDictionary<invtype, int>)_items)[key] = value;
			}
		}

		public static ItemList operator +(ItemList c1, ItemList c2)
		{
			var result = new ItemList();
			result.AddAll(c1);
			result.AddAll(c2);

			return result;
		}

		public static ItemList operator +(ItemList c1, KeyValuePair<invtype, int> c2)
		{
			c1.Add(c2);

			return c1;
		}

		public static ItemList operator -(ItemList c1, ItemList c2)
		{
			var result = new ItemList();
			result.AddAll(c1);

			c2.Multiply(-1);

			result.AddAll(c2);

			return result;
		}

		public static ItemList operator -(ItemList c1, KeyValuePair<invtype, int> c2)
		{
			c1.Add(c2.Key, -1 * c2.Value);

			return c1;
		}

		public static ItemList operator *(ItemList c1, double c2)
		{
			c1.Multiply(c2);

			return c1;
		}

		public static ItemList operator /(ItemList c1, double c2)
		{
			c1.Multiply(1 / c2);

			return c1;
		}

		public ItemList(Dictionary<invtype, int> items)
		{
			this._items = items;
		}

		public ItemList(ICollection<industryactivitymaterial> mats)
		{
			this._items = new Dictionary<invtype, int>();

			foreach (var mat in mats)
			{
				this.Add(mat.material_invtype, mat.quantity ?? 0);
			}
		}

		public ItemList(ICollection<industryactivityproduct> products)
		{
			this._items = new Dictionary<invtype, int>();

			foreach (var mat in products)
			{
				this.Add(mat.product_invtype, mat.quantity ?? 0);
			}
		}

		public ItemList()
		{
			this._items = new Dictionary<invtype, int>();
		}

		public bool ContainsKey(invtype key)
		{
			return ((IDictionary<invtype, int>)_items).ContainsKey(key);
		}

		public void Add(invtype key, int value)
		{
			if (_items.ContainsKey(key))
			{
				int amount;
				this._items.TryGetValue(key, out amount);

				this._items.Remove(key);

				this._items.Add(key, amount + value);

			}
			else
			{
				((IDictionary<invtype, int>)_items).Add(key, value);
			}
		}

		public void AddAll(IDictionary<invtype, int> items)
		{
			foreach (var stack in items.AsEnumerable())
			{
				this.Add(stack);
			}
		}

		public void Multiply(double scalar, bool ceil = true)
		{
			var items = this.ToList();
			foreach (var item in items)
			{
				this[item.Key] = ceil ? (int)Math.Ceiling(item.Value * scalar) : (int)Math.Floor(item.Value * scalar);
			}
		}

		public bool Remove(invtype key)
		{
			return ((IDictionary<invtype, float>)_items).Remove(key);
		}

		public bool TryGetValue(invtype key, out int value)
		{
			return ((IDictionary<invtype, int>)_items).TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<invtype, int> item)
		{
			this.Add(item.Key, item.Value);
		}

		public void Clear()
		{
			((IDictionary<invtype, int>)_items).Clear();
		}

		public bool Contains(KeyValuePair<invtype, int> item)
		{
			return ((IDictionary<invtype, int>)_items).Contains(item);
		}

		public void CopyTo(KeyValuePair<invtype, int>[] array, int arrayIndex)
		{
			((IDictionary<invtype, int>)_items).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<invtype, int> item)
		{
			return ((IDictionary<invtype, int>)_items).Remove(item);
		}

		public IEnumerator<KeyValuePair<invtype, int>> GetEnumerator()
		{
			return ((IDictionary<invtype, int>)_items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IDictionary<invtype, float>)_items).GetEnumerator();
		}

		public enum ItemListFormat { EFT, Tabs, Spaces }

		public string ToStringWithFormat(ItemListFormat format)
		{

			string str = "";

			switch (format)
			{
				case ItemListFormat.EFT:
					foreach (var item in this)
					{
						str += item.Key.typeName + " x" + item.Value;
						str += "\r\n";
					}
					break;

				case ItemListFormat.Tabs:
					foreach (var item in this)
					{
						str += item.Key.typeName + "\t" + item.Value;
						str += "\r\n";
					}
					break;

				case ItemListFormat.Spaces:
					foreach (var item in this)
					{
						str += item.Key.typeName + "	" + item.Value;
						str += "\r\n";
					}
					break;

			}

			return str;
		}

		public ItemList getAllMats()  ///<todo>Make this work with ME</todo>
		{
			ItemList mats = new ItemList();

			foreach (var item in this)
			{
				ItemList list = ItemList.getMatsFor(item.Key);
				list.Multiply(item.Value);

				mats.AddAll(list);

			}

			return mats;
		}

		public ItemList getAllMats(double defaultME, IDictionary<invtype, double> MEs)  ///<todo>Make this work with ME</todo>
		{
			ItemList mats = new ItemList();

			foreach (var item in this)
			{
				ItemList list = ItemList.getMatsFor(item.Key);
				list.Multiply(item.Value);

				double me = defaultME;
				MEs.TryGetValue(item.Key, out me);
				list.Multiply(me);

				mats.AddAll(list);

			}

			return mats;
		}

		public static ItemList getMatsFor(invtype type)
		{
			var db = new SDEEntities();
			return new ItemList(db.GetMats(type.typeID, 1).ToList());
		}

		public void SubtractIfPresent(ItemList toSubtract)
		{
			foreach(KeyValuePair<invtype, int> pair in toSubtract)
			{
				if (this.ContainsKey(pair.Key))
				{
					this.Add(pair.Key, -1 * pair.Value);
				}
			}
		}

	}
}