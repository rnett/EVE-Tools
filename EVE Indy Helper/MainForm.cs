using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EVE;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using SDEModel;

namespace CapitalBuildManagerApp
{
	public partial class MainForm : Form
	{

		public static readonly SDEEntities _sde = SDEEntities.SDE;
		private OreOptimizer _oreOptimizer;

		public MainForm()
		{
            
			_oreOptimizer = new OreOptimizer(_sde);

			InitializeComponent();

            this.QMMatsGrid.Rows.Add("Defaults", "-", 10, 20, 5.158, 59.4, 0, 32);
        }

		

		private void QMItemBox_TextChanged(object sender, EventArgs e)
		{

			if (this.QMItemBox.Text.Count() >= 3)
			{

				UpdateData(this.QMItemBox);


			}
			else
			{
				return;
			}
		}

		private void UpdateData(ComboBox box)
		{
			if (box.Text.Length > 1)
			{
				List<string> searchData = _sde.GetTypesLikeName(box.Text).Where(x => x.madeBy.Count > 0).ToList().Select(x => x.typeName).Where(s => s != null && s != "").ToList();
				HandleTextChanged(searchData, box);
			}
		}

		//Update combobox with new data
		private void HandleTextChanged(List<string> dataSource, ComboBox box)
		{
			var text = box.Text;
            
			if (box.Text.Count() >= 3 && dataSource.Count() > 0)
			{

				var sText = box.Text;
                box.DroppedDown = false;
                box.DropDownHeight = (int)(13.25 * Math.Min(16, dataSource.Count+1));
                box.DroppedDown = true;
                box.DataSource = dataSource;
                box.Text = sText;
                box.SelectionStart = sText.Length;
                box.Select(sText.Count(), 0);
				Cursor.Current = Cursors.Default;

				return;
			}

			else
			{
				box.DroppedDown = false;
                box.SelectionStart = text.Length;
			}
		}

		private void OptimizeButton_Click(object sender, EventArgs e)
		{
			Tuple<double, ItemList> list = this._oreOptimizer.getOre(
				this.RefineRateBox.Text != "" ? double.Parse(this.RefineRateBox.Text)/100 : 0,
				this.TritBox.Text != ""?int.Parse(this.TritBox.Text) : 0,
				this.PyerBox.Text != "" ? int.Parse(this.PyerBox.Text) : 0,
				this.MexBox.Text != "" ? int.Parse(this.MexBox.Text) : 0,
				this.IsoBox.Text != "" ? int.Parse(this.IsoBox.Text) : 0,
				this.NocxBox.Text != "" ? int.Parse(this.NocxBox.Text) : 0,
				this.ZydBox.Text != "" ? int.Parse(this.ZydBox.Text) : 0,
				this.MegaBox.Text != "" ? int.Parse(this.MegaBox.Text) : 0,
				this.MorphBox.Text != "" ? int.Parse(this.MorphBox.Text) : 0
				);
			this.OreOptimizerResultsGrid.Rows.Clear();
			foreach(KeyValuePair<invType, int> pair in list.Item2)
			{
				this.OreOptimizerResultsGrid.Rows.Add(pair.Key.typeName, pair.Value);
			}

			this.PriceTextbox.Text = list.Item1.ToString();
		}

		private void ParseButton_Click(object sender, EventArgs e)
		{

			ItemList data = parseItems(this.MineralImportTextbox.Text);

			int trit;
			int pyer;
			int mex;
			int iso;
			int nocx;
			int zydr;
			int mega;
			int morph;

			data.TryGetValue(MainForm._sde.GetTypeFromName("Tritanium").First(), out trit);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Pyerite").First(), out pyer);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Mexallon").First(), out mex);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Isogen").First(), out iso);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Nocxium").First(), out nocx);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Zydrine").First(), out zydr);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Megacyte").First(), out mega);
			data.TryGetValue(MainForm._sde.GetTypeFromName("Morphite").First(), out morph);

			this.TritBox.Text = trit.ToString();
			this.PyerBox.Text = pyer.ToString();
			this.MexBox.Text = mex.ToString();
			this.IsoBox.Text = iso.ToString();
			this.NocxBox.Text = nocx.ToString();
			this.ZydBox.Text = zydr.ToString();
			this.MegaBox.Text = mega.ToString();
			this.MorphBox.Text = morph.ToString();


		}

		public ItemList parseItems(string text) { 

			ItemList data = new ItemList();

			text = text.Replace(" x ", " ");

			text = text.Replace("	", " ");
			text = text.Replace("\t", " ");

			text = Regex.Replace(text, "([^A-Za-z])x([^A-Za-z])", "$1$2");

			text = Regex.Replace(text, "  *", " ");

			string[] lines = text.Split('\n', '\r');

			List<string> errors = new List<string>();

			foreach (string line in lines)
			{

				if (line == "")
				{
					continue;
				}

				string name = line.Substring(0, line.LastIndexOf(" "));
                int numStart = line.LastIndexOf(" ") + 1;
                string amount = line.Substring(numStart, line.Count() - numStart);

				try
				{
					data.Add(MainForm._sde.GetTypeFromName(name).First(), int.Parse(amount));
				}
				catch (Exception ex)
				{
					errors.Add(name);
				}

			}
			return data;
		}

		private void QMCalculateButton_Click(object sender, EventArgs e)
		{

			// write the mat tree

			invType type;

			try
			{
				type = MainForm._sde.GetTypeFromName(this.QMItemBox.Text).First();
			} catch (Exception ex)
			{
				return;
			}

			if(currentType == null || currentType.typeID != type.typeID)
			{
				currentType = type;
				meteDatas.Clear();
				baseMats.Clear();
			}
			refreshMatsTable();


		}

		private invType currentType;
		private Dictionary<invType, METEData> meteDatas = new Dictionary<invType, METEData>();
		private METEData defaultMETE = new METEData(10, 20, 5.158, 59.4, 0, 32);
		private ItemList baseMats = new ItemList();

		private void addMatR(invType mat, int amount, int depth, bool start = false)
		{

			if(mat == null)
			{
				return;
			}

			if (mat.isBaseMat())
			{
				baseMats.Add(mat, amount);

			}
			else
			{

				METEData data = null;
				this.meteDatas.TryGetValue(mat, out data);

				bool hadMEData = true;

				if (data == null)
				{
					data = this.defaultMETE;
					hadMEData = false;
				}

				string matStr = "";

				for(int i = 0; i < depth; i++) { matStr += "-"; }

				if (!hadMEData || start)
				{
					this.QMMatsGrid.Rows.Add(matStr + mat, amount, "", "", "", "", "", "");
				}
				else
				{
					string[] mesStrs = data.ToStrArray();
					this.QMMatsGrid.Rows.Add(matStr + mat, amount, mesStrs[0], mesStrs[1], mesStrs[2], mesStrs[3], mesStrs[4], mesStrs[5]);
				}
				var matlist = mat.getMats(amount, data.TotalMEAsMultiplier);

				foreach (KeyValuePair<invType, int> submat in matlist)
				{
					addMatR(submat.Key, submat.Value, depth + 1);
				}
			}
		}

		private void refreshMatsTable()
		{
			int amount = 1;
			try
			{
				amount = int.Parse(this.QMAmountBox.Text);
			}
			catch
			{

			}
			var dgv = this.QMMatsGrid;

			// remove all rows except defaults
			DataGridViewRow defaults = dgv.Rows[0];
			dgv.Rows.Clear();
			dgv.Rows.Add(defaults);

			baseMats.Clear();

			addMatR(currentType, amount, 0, false);

			this.QMMineralBaseMatsDataView.Rows.Clear();
			this.QMOtherBaseMatsDataView.Rows.Clear();

			foreach (KeyValuePair<invType, int> baseMat in this.baseMats)
			{
				if (baseMat.Key.isMineral())
				{
					this.QMMineralBaseMatsDataView.Rows.Add(baseMat.Key, baseMat.Value);
				} else
				{
					this.QMOtherBaseMatsDataView.Rows.Add(baseMat.Key, baseMat.Value);
				}
			}

		}

		private void QMMatsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{

			if(e.RowIndex == 0) // change the default
			{
				this.defaultMETE = new METEData(
					double.Parse(this.QMMatsGrid.Rows[0].Cells[2].Value.ToString()),
					double.Parse(this.QMMatsGrid.Rows[0].Cells[3].Value.ToString()),
					double.Parse(this.QMMatsGrid.Rows[0].Cells[4].Value.ToString()),
					double.Parse(this.QMMatsGrid.Rows[0].Cells[5].Value.ToString()),
					double.Parse(this.QMMatsGrid.Rows[0].Cells[6].Value.ToString()),
					double.Parse(this.QMMatsGrid.Rows[0].Cells[7].Value.ToString())
					);
				refreshMatsTable();
			} else if(e.RowIndex > 0)
			{
				string name = (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[0].Value;
				name = name.Substring(name.LastIndexOf("-") + 1);
				invType item = MainForm._sde.GetTypeFromName(name).First();

				METEData data = new METEData(
					(this.QMMatsGrid.Rows[e.RowIndex].Cells[2].Value == null || (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[2].Value == "") ? -1 : int.Parse(this.QMMatsGrid.Rows[e.RowIndex].Cells[2].Value.ToString()),
					(this.QMMatsGrid.Rows[e.RowIndex].Cells[3].Value == null || (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[3].Value == "") ? -1 : int.Parse(this.QMMatsGrid.Rows[e.RowIndex].Cells[3].Value.ToString()),
					(this.QMMatsGrid.Rows[e.RowIndex].Cells[4].Value == null || (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[4].Value == "") ? -1 : int.Parse(this.QMMatsGrid.Rows[e.RowIndex].Cells[4].Value.ToString()),
					(this.QMMatsGrid.Rows[e.RowIndex].Cells[5].Value == null || (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[5].Value == "") ? -1 : int.Parse(this.QMMatsGrid.Rows[e.RowIndex].Cells[5].Value.ToString()),
					(this.QMMatsGrid.Rows[e.RowIndex].Cells[6].Value == null || (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[6].Value == "") ? -1 : int.Parse(this.QMMatsGrid.Rows[e.RowIndex].Cells[6].Value.ToString()),
					(this.QMMatsGrid.Rows[e.RowIndex].Cells[7].Value == null || (string)this.QMMatsGrid.Rows[e.RowIndex].Cells[7].Value == "") ? -1 : int.Parse(this.QMMatsGrid.Rows[e.RowIndex].Cells[7].Value.ToString())
					);
				this.meteDatas.Remove(item);
				this.meteDatas.Add(item, data);
				refreshMatsTable();
			}


		}

		private void QMCalcOreButton_Click(object sender, EventArgs e)
		{
			int trit;
			int pyer;
			int mex;
			int iso;
			int nocx;
			int zydr;
			int mega;
			int morph;

			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Tritanium").First(), out trit);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Pyerite").First(), out pyer);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Mexallon").First(), out mex);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Isogen").First(), out iso);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Nocxium").First(), out nocx);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Zydrine").First(), out zydr);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Megacyte").First(), out mega);
			baseMats.TryGetValue(MainForm._sde.GetTypeFromName("Morphite").First(), out morph);

			this.TritBox.Text = trit.ToString();
			this.PyerBox.Text = pyer.ToString();
			this.MexBox.Text = mex.ToString();
			this.IsoBox.Text = iso.ToString();
			this.NocxBox.Text = nocx.ToString();
			this.ZydBox.Text = zydr.ToString();
			this.MegaBox.Text = mega.ToString();
			this.MorphBox.Text = morph.ToString();

			this.OptimizeButton_Click(null, null);
			this.Tabs.SelectedIndex = 1;
		}
	}
}
