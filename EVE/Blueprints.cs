using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVE;
using static EVE.ItemList;
using System.Diagnostics;
using System.Configuration;

namespace EVE
{
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class BPO
	{

		public int ME { get; }
		public int TE { get; }
		public invtype Type { get; }
		public invtype ManufacturingProductType { get; }

		/// <summary>
		/// Creates a BPO object using the invtype of the blueprint(!!!), me, and te
		/// </summary>
		public BPO (invtype type, int me, int te)
		{
			this.Type = type;
			this.ManufacturingProductType = type.blueprint_industryactivityproducts.Where(x => x.activityID == 1).First().product_invtype;
			this.ME = me;
			this.TE = te;
		}

		public override bool Equals(object obj)
		{
			var item = obj as BPO;

			if (item == null)
			{
				return false;
			}

			return this.Type.Equals(item.Type) && this.ME == item.ME && this.TE == item.TE;
		}

		public override string ToString()
		{
			return this.Type.ToString() + " (" + this.ME + ", " + this.TE + ")";
		}

		public override int GetHashCode()
		{
			return this.Type.GetHashCode();
		}

	}
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class BPC : BPO
	{
		public BPC(invtype type, int me, int te, int runs) : base(type, me, te)
		{
			this.Runs = runs;
		}

		public BPC(BPO bpo, int runs) : base(bpo.Type, bpo.ME, bpo.TE)
		{
			this.Runs = runs;
		}

		public int Runs { get; }

		public override string ToString()
		{
			return base.ToString() + "\t" + this.Runs;
		}
	}
	[SettingsSerializeAs(SettingsSerializeAs.Xml)]
	public class BPOList : IDictionary<BPO, int>
	{
		private Dictionary<BPO, int> _items = new Dictionary<BPO, int>();

		public int this[BPO key]
		{
			get
			{
				return ((IDictionary<BPO, int>)_items)[key];
			}

			set
			{
				((IDictionary<BPO, int>)_items)[key] = value;
			}
		}

		public int Count
		{
			get
			{
				return ((IDictionary<BPO, int>)_items).Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return ((IDictionary<BPO, int>)_items).IsReadOnly;
			}
		}

		public ICollection<BPO> Keys
		{
			get
			{
				return ((IDictionary<BPO, int>)_items).Keys;
			}
		}

		public ICollection<int> Values
		{
			get
			{
				return ((IDictionary<BPO, int>)_items).Values;
			}
		}

		public void Clear()
		{
			((IDictionary<BPO, int>)_items).Clear();
		}

		public bool Contains(KeyValuePair<BPO, int> item)
		{
			return ((IDictionary<BPO, int>)_items).Contains(item);
		}

		public bool ContainsKey(BPO key)
		{
			return ((IDictionary<BPO, int>)_items).ContainsKey(key);
		}

		public void CopyTo(KeyValuePair<BPO, int>[] array, int arrayIndex)
		{
			((IDictionary<BPO, int>)_items).CopyTo(array, arrayIndex);
		}

		public IEnumerator<KeyValuePair<BPO, int>> GetEnumerator()
		{
			return ((IDictionary<BPO, int>)_items).GetEnumerator();
		}

		public bool Remove(KeyValuePair<BPO, int> item)
		{
			return ((IDictionary<BPO, int>)_items).Remove(item);
		}

		public bool Remove(BPO key)
		{
			return ((IDictionary<BPO, int>)_items).Remove(key);
		}

		public bool TryGetValue(BPO key, out int value)
		{
			return ((IDictionary<BPO, int>)_items).TryGetValue(key, out value);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IDictionary<BPO, int>)_items).GetEnumerator();
		}

		public static BPOList operator +(BPOList c1, BPOList c2)
		{
			var result = new BPOList();
			result.AddAll(c1);
			result.AddAll(c2);

			return result;
		}

		public static BPOList operator +(BPOList c1, KeyValuePair<BPO, int> c2)
		{
			c1.Add(c2);

			return c1;
		}

		public static BPOList operator -(BPOList c1, BPOList c2)
		{
			var result = new BPOList();
			result.AddAll(c1);

			c2.Multiply(-1);

			result.AddAll(c2);

			return result;
		}

		public static BPOList operator -(BPOList c1, KeyValuePair<BPO, int> c2)
		{
			c1.Add(c2.Key, -1 * c2.Value);

			return c1;
		}

		public void Add(BPO key, int value)
		{

			
			int amount = 0;
			this.TryGetValue(key, out amount);

			this.Remove(key);

			this._items.Add(key, amount + value);
		}

		public void AddAll(IDictionary<BPO, int> items)
		{
			foreach (var stack in items.AsEnumerable())
			{
				this.Add(stack);
			}
		}

		private void Multiply(double scalar, bool ceil = true)
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

		public void Add(KeyValuePair<BPO, int> item)
		{
			this.Add(item.Key, item.Value);
		}

		public List<BPC> AsBPCList()
		{
			List<BPC> data = new List<BPC>();
			foreach(KeyValuePair<BPO, int> pair in this)
			{
				data.Add(new BPC(pair.Key, pair.Value));
			}

			return data;
		}

		public string ToStringWithFormat(ItemListFormat format)
		{

			string str = "";

			switch (format)
			{
				case ItemListFormat.EFT:
					foreach (var item in this)
					{
						str += item.Key.Type.typeName + "(" + item.Key.ME + ", " + item.Key.TE + ")" + " x" + item.Value;
						str += "\r\n";
					}
					break;

				case ItemListFormat.Tabs:
					foreach (var item in this)
					{
						str += item.Key.Type.typeName + "(" + item.Key.ME + ", " + item.Key.TE + ")" + "\t" + item.Value;
						str += "\r\n";
					}
					break;

				case ItemListFormat.Spaces:
					foreach (var item in this)
					{
						str += item.Key.Type.typeName + "(" + item.Key.ME + ", " + item.Key.TE + ")" + "	" + item.Value;
						str += "\r\n";
					}
					break;

			}

			return str;
		}

	}

}
