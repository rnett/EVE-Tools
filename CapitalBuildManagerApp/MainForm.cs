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

namespace CapitalBuildManagerApp
{
	public partial class MainForm : Form
	{

		public static readonly SDEEntities _sde = new SDEEntities();
		private UserData _userData;

		public MainForm()
		{
			InitializeComponent();
			this._userData = new UserData();
			UpdateAPITable();

		}

		private void AddAPIButton_Click(object sender, EventArgs e)
		{
			
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

			foreach(XMLAPI api in this._userData.APIs)
			{
				string characters = "";
				foreach(CharacterData character in api.Characters)
				{
					if(character != null)
					{
						characters += ", " + character.CharacterName;
					}
				}

				characters = characters.Substring(2);

				this.APIGridView.Rows.Add(characters, api.KeyID, api.VCode, "Delete");

			}


		}

	}
}
