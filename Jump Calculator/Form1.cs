using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jump_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.refreshToken.Text = "EBb41PywItqhVpo7744FW1Rv0Q_UBSPBIz255Uhf9Nc96bnMcxmFt0wlWxLOGUlqmA9Tmjco4osYVk7URvYJRg2";
            LocChar me = new LocChar(this.refreshToken.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JumpLoc.LoadAll(this.stationBar, this.structureBar);

        }
    }
}
