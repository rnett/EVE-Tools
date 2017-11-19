using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EVE;

namespace EVE_Desktop
{
    public partial class CharacterDataOverview : UserControl
    {

        public Character Character;

        public CharacterDataOverview(Character c)
        {
            Character = c;
            InitializeComponent();

            this.picture.Load(c.PictureURL);
            this.isk.Text = string.Format("{0:n}", c.ISK);
            this.sp.Text = string.Format("{0:n0}", c.TotalSP);

            if (c.Training)
            {
                this.currentSkill.Value = (int)(100D * ((double)c.CurrentTrain.InvestedSPInLevel / c.CurrentTrain.SPForLevel));
                this.skillLabel.Text = c.CurrentTrain.ToString() + " - " + c.CurrentTrain.RemainingTime.Days + "d " + c.CurrentTrain.RemainingTime.Hours + "h " + c.CurrentTrain.RemainingTime.Minutes  + "m";
                int implant = c.Attributes.ValueOf(c.CurrentTrain.Skill.Primary) - 27;
                this.attributesLabel.Text = c.CurrentTrain.Skill.Primary.ToString().Substring(0, 3) + ": " + c.Attributes.ValueOf(c.CurrentTrain.Skill.Primary) + ", " +
                    c.CurrentTrain.Skill.Secondary.ToString().Substring(0, 3) + ": " + c.Attributes.ValueOf(c.CurrentTrain.Skill.Secondary) + ".  " +
                    (implant > 0 ? "+" + implant + "s.  " : "") + ((int)c.CurrentTrain.SPPerHour) + " sp/h";

                if (c.Attributes.ValueOf(c.CurrentTrain.Skill.Primary) < 30 || c.Attributes.ValueOf(c.CurrentTrain.Skill.Secondary) < 24) // < +3s
                {
                    this.attributesLabel.BackColor = Color.Orange;
                }
                else if (c.Attributes.ValueOf(c.CurrentTrain.Skill.Primary) <= 31 || c.Attributes.ValueOf(c.CurrentTrain.Skill.Secondary) <= 25) // +3s or +4s
                {
                    this.attributesLabel.BackColor = Color.Yellow;
                }
            } else
            {
                this.currentSkill.Value = 0;
                this.skillLabel.Text = "Not Training.";
                this.attributesLabel.Text = "";

            }

            if (c.JumpFatigue > TimeSpan.Zero)
            {
                this.jumpFatigue.Text = (c.JumpFatigue.Days > 0 ? c.JumpFatigue.Days + "d " : "") + c.JumpFatigue.Hours + "h " + c.JumpFatigue.Minutes + "m";
            }
            else
                this.jumpFatigue.Text = "";


        }
    }
}
