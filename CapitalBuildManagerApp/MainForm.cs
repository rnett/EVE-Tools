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

namespace CapitalBuildManagerApp
{
	public partial class MainForm : Form
	{

		public static readonly SDEEntities _sde = new SDEEntities();
		private UserData _userData;
		private OreOptimizer _oreOptimizer;

		public MainForm()
		{

			
			this._userData = Properties.Settings.Default.UserData;

			if(this._userData == null)
			{
				this._userData = new UserData();
			}

			_oreOptimizer = new OreOptimizer(_sde);

			InitializeComponent();

			this.QMMatsGrid.Rows.Add("Defaults", "-", 10, 20, 5.158, 59.4, 0, 32);

			UpdateAPITable();
			UpdateJobTable();
		}

		private void AddAPIButton_Click(object sender, EventArgs e)
		{
			try
			{
				this._userData.AddAPI(new XMLAPI(this.APIKeyIDTextbox.Text, this.APIvCodeTextBox.Text));
			}
			catch (Exception exception)
			{
				this.APIErrorLabel.Text = "Error: " + exception.Message;
				return;
			}

			this.APIKeyIDTextbox.Text = "";
			this.APIvCodeTextBox.Text = "";
			this.UpdateAPITable();
		}

		private void APIGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
				e.RowIndex >= 0)
			{
				this._userData.RemoveAPI(long.Parse((string)senderGrid.Rows[e.RowIndex].Cells[1].Value));
				UpdateAPITable();
			}
		}

		private void UpdateAPITable()
		{

			this.APIGridView.Rows.Clear();

			foreach (XMLAPI api in this._userData.APIs)
			{
				string characters = "";
				foreach (CharacterData character in api.Characters)
				{
					if (character != null)
					{
						characters += ", " + character.CharacterName;
					}
				}

				characters = characters.Substring(2);

				this.APIGridView.Rows.Add(characters, api.KeyID, api.VCode, "Delete");

			}


		}

		private void UpdateJobTable()
		{
			this.JobDataGridView.Rows.Clear();

			foreach (Job job in this._userData.Jobs)
			{
				this.JobDataGridView.Rows.Add(job.Type.typeName, job.Amount, job.TimeEntered, job.BpcsOnly, "+", "-", "x");

			}
		}

		private void JobDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
				e.RowIndex >= 0)
			{
				if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Up")
				{
					if (e.RowIndex - 1 > 0)
						this._userData.Jobs.Move(e.RowIndex - 1, e.RowIndex - 2);

				}
				else if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Down")
				{
					if (e.RowIndex - 1 < this._userData.Jobs.Count - 1)
						this._userData.Jobs.Move(e.RowIndex - 1, e.RowIndex);


				}
				else if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Remove")
				{
					this._userData.Jobs.RemoveAt(e.RowIndex - 1);


				}
			}

			this.UpdateJobTable();

		}

		private void AddJobButton_Click(object sender, EventArgs e)
		{
			this._userData.Jobs.Add( new Job(_sde.GetTypeFromName(this.AddJobItemCombobox.Text).First(), int.Parse(this.AddJobQuantityTextBox.Text), DateTime.UtcNow, this.AddJobCopyOnlyCheckbox.Checked ) );
			this.UpdateJobTable();
		}

		private void AddJobItemCombobox_TextChanged(object sender, EventArgs e)
		{

			if (this.AddJobItemCombobox.Text.Count() >= 3)
			{
				
				UpdateData(this.AddJobItemCombobox);
					
				
			}
			else
			{
				return;
			}
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
				List<string> searchData = _sde.GetTypesLikeName(box.Text).Where(x => x.product_industryactivityproducts.Count > 0).ToList().Select(x => x.typeName).ToList();
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
				box.DataSource = dataSource;
				box.DroppedDown = true;
				box.Text = sText;
				box.Select(text.Count(), 0);
				Cursor.Current = Cursors.Default;

				return;
			}

			else
			{
				box.DroppedDown = false;
				box.SelectionStart = text.Length;
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.UserData = this._userData;
			Properties.Settings.Default.Save();
			var settings = JsonConvert.SerializeObject(this._userData);
			UserData product = JsonConvert.DeserializeObject<UserData>(settings); //TODO figure out a way to get settings to save and load
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
			foreach(KeyValuePair<invtype, int> pair in list.Item2)
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
				string amount = line.Substring(line.LastIndexOf(" "), line.Count() - line.LastIndexOf(" "));

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

			invtype type;

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

		private invtype currentType;
		private Dictionary<invtype, METEData> meteDatas = new Dictionary<invtype, METEData>();
		private METEData defaultMETE = new METEData(10, 20, 5.158, 59.4, 0, 32);
		private ItemList baseMats = new ItemList();

		private void addMatR(invtype mat, int amount, int depth, bool start = false)
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

				foreach (KeyValuePair<invtype, int> submat in matlist)
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

			foreach (KeyValuePair<invtype, int> baseMat in this.baseMats)
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
				invtype item = MainForm._sde.GetTypeFromName(name).First();

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
			this.Tabs.SelectedIndex = 9;
		}
	}
}
