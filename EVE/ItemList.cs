
using SDEModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
namespace EVE
{

	/// <summary>
	/// A list of items
	/// </summary>
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class ItemList : IDictionary<invType, int>
	{
		private Dictionary<invType, int> _items;

		public ICollection<invType> Keys
		{
			get
			{
				return ((IDictionary<invType, int>)_items).Keys;
			}
		}

		public ICollection<int> Values
		{
			get
			{
				return ((IDictionary<invType, int>)_items).Values;
			}
		}

		public int Count
		{
			get
			{
				return ((IDictionary<invType, int>)_items).Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IDictionary<invType, int>)_items).IsReadOnly;
			}
		}

		public int this[invType key]
		{
			get
			{
				return ((IDictionary<invType, int>)_items)[key];
			}

			set
			{
				((IDictionary<invType, int>)_items)[key] = value;
			}
		}

		public static ItemList operator +(ItemList c1, ItemList c2)
		{
			var result = new ItemList();
			result.AddAll(c1);
			result.AddAll(c2);

			return result;
		}

		public static ItemList operator +(ItemList c1, KeyValuePair<invType, int> c2)
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

		public static ItemList operator -(ItemList c1, KeyValuePair<invType, int> c2)
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

		public ItemList(Dictionary<invType, int> items)
		{
			this._items = items;
		}

		public ItemList(ICollection<industryActivityMaterial> mats)
		{
			this._items = new Dictionary<invType, int>();

			foreach (var mat in mats)
			{
				this.Add(mat.materialType, mat.quantity ?? 0);
			}
		}

		public ItemList(ICollection<industryActivityProduct> products)
		{
			this._items = new Dictionary<invType, int>();

			foreach (var mat in products)
			{
				this.Add(mat.productType, mat.quantity ?? 0);
			}
		}

		public ItemList()
		{
			this._items = new Dictionary<invType, int>();
		}

		public bool ContainsKey(invType key)
		{
			return ((IDictionary<invType, int>)_items).ContainsKey(key);
		}

		public void Add(invType key, int value)
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
				((IDictionary<invType, int>)_items).Add(key, value);
			}
		}

		public void AddAll(IDictionary<invType, int> items)
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

		public bool Remove(invType key)
		{
			return ((IDictionary<invType, float>)_items).Remove(key);
		}

		public bool TryGetValue(invType key, out int value)
		{
			return ((IDictionary<invType, int>)_items).TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<invType, int> item)
		{
			this.Add(item.Key, item.Value);
		}

		public void Clear()
		{
			((IDictionary<invType, int>)_items).Clear();
		}

		public bool Contains(KeyValuePair<invType, int> item)
		{
			return ((IDictionary<invType, int>)_items).Contains(item);
		}

		public void CopyTo(KeyValuePair<invType, int>[] array, int arrayIndex)
		{
			((IDictionary<invType, int>)_items).CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<invType, int> item)
		{
			return ((IDictionary<invType, int>)_items).Remove(item);
		}

		public IEnumerator<KeyValuePair<invType, int>> GetEnumerator()
		{
			return ((IDictionary<invType, int>)_items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IDictionary<invType, float>)_items).GetEnumerator();
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

		public ItemList getAllMats(double defaultME, IDictionary<invType, double> MEs)  ///<todo>Make this work with ME</todo>
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

		public static ItemList getMatsFor(invType type)
		{
			var db = new SDEEntities();
			return new ItemList(db.GetMats(type.typeID, 1).ToList());
		}

		public void SubtractIfPresent(ItemList toSubtract)
		{
			foreach(KeyValuePair<invType, int> pair in toSubtract)
			{
				if (this.ContainsKey(pair.Key))
				{
					this.Add(pair.Key, -1 * pair.Value);
				}
			}
		}

	}
}