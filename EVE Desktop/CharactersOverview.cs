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
using Tulpep.NotificationWindow;

namespace EVE_Desktop
{
    public partial class CharactersOverview : UserControl, ICharacterDataControl
    {
        public Dictionary<int, Character> Characters { get; set; }

        public CharactersOverview()
        {
            InitializeComponent();
        }

        public CharactersOverview(Dictionary<int, Character> characters)
        {
            Characters = characters;
            InitializeComponent();
        }
        
        public void refreshCharacters()
        {
            // clear things
            courierContractsDGV.Rows.Clear();
            ieContractsDGV.Rows.Clear();
            recentContractsDGV.Rows.Clear();
            industryJobsDGV.Rows.Clear();

            foreach (Control ctrl in this.charOverviews.Controls)
            {
                ctrl.Dispose();
            }
            this.charOverviews.Controls.Clear();

            foreach (Character c in Characters.Values)
            {
                addCharacterData(c);
            }
        }

        private void addCharacterData(Character c)
        {
            
            foreach (Contract ct in c.UnfinishedCouriers)
            {
                this.courierContractsDGV.Rows.Add(c.CharacterName, ct.StartLocation.Name, ct.EndLocation.Name, ct.Collateral, ct.DateAccepted, ct.DateExpired);
            }
            foreach (Contract ct in c.OutstandingItemExchangesToMe)
            {
                this.ieContractsDGV.Rows.Add(c.CharacterName, ct.StartLocation.Name, ct.Price, ct.DateIssued, ct.DateExpired);
            }
            foreach (Contract ct in c.RecentlyCompleted)
            {
                this.recentContractsDGV.Rows.Add(c.CharacterName, ct.Type.GetDescription(), ct.StartLocation.Name, ct.DateCompleted, ct.Type == ContractType.Courier ? string.Format("{0:n0}", ct.Collateral) : string.Format("{0:n0}", ct.Price));
            }

            this.charOverviews.Controls.Add(new CharacterDataOverview(c));

            foreach (IndustryJob ij in c.IndustryJobs)
            {
                this.industryJobsDGV.Rows.Add(c.CharacterID, ij.ActivityType.GetDescription(), ij.Facility.Name, ij.Runs, ij.ProductType.typeName, ij.EndDate);
            }

        }
    }
}
