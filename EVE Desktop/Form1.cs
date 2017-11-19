using EVE;
using EVE_Desktop.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace EVE_Desktop
{
    public partial class Form1 : Form
    {

        public Dictionary<int, Character> Characters = new Dictionary<int, Character>();
        public List<ICharacterDataControl> CharacterControls = new List<ICharacterDataControl>();
        

        public Form1()
        {
            //evedesktop.freecluster.eu


            InitializeComponent();
            _isMaximized = WindowState == FormWindowState.Maximized;

            // add CharacterDataControls
            CharacterControls.Add(this.charactersOverview);

            // adding the characters
            foreach (string refreshtoken in Settings.Default.RefreshTokens)
            {
                Character c = new Character(refreshtoken);
                Characters.Add(c.CharacterID, c);
            }

            refreshCharacterControls();
        }

        private void refreshCharacterControls()
        {
            foreach (ICharacterDataControl charControl in CharacterControls)
            {
                charControl.Characters = Characters;
                charControl.refreshCharacters();
            }


        }

        private void updateCharacters()
        {
            Dictionary<int, Character> oldChars = Characters;
            Characters = new Dictionary<int, Character>();


            foreach (string refreshtoken in Settings.Default.RefreshTokens)
            {
                Character c = new Character(refreshtoken);
                Characters.Add(c.CharacterID, c);
            }

            refreshCharacterControls();

            // contracts

            DateTime newestFinishedContract = DateTime.MinValue;

            foreach (Character old in oldChars.Values)
            {

                foreach (Contract c in old.RecentlyCompleted)
                {
                    if (c.Type == ContractType.Courier && c.DateCompleted > newestFinishedContract)
                    {
                        newestFinishedContract = c.DateCompleted;
                    }
                }

            }

            Dictionary<Contract, Character> justFinished = new Dictionary<Contract, Character>();

            foreach (Character newC in Characters.Values)
            {
                foreach (Contract c1 in newC.RecentlyCompleted)
                {
                    if (c1.Type == ContractType.Courier && c1.DateCompleted > newestFinishedContract)
                    {
                        justFinished.Add(c1, newC);
                    }
                }
            }


            string data = "";
            foreach (KeyValuePair<Contract, Character> pair in justFinished)
            {
                data += pair.Value.CharacterName + ": " + pair.Key.Type.GetDescription() + " @ " + pair.Key.EndLocation.Name + "\n";
            }
            sendPopup(justFinished.Count + " newly finished couriers", data);
        }

        private void addCharacterButton_Click(object sender, EventArgs e)
        {
            try
            {
                Character c = new Character(this.addCharacterTB.Text);
                Characters.Add(c.CharacterID, c);
                Settings.Default.RefreshTokens.Add(this.addCharacterTB.Text);
                Settings.Default.Save();
            }
            catch (Exception e2) { }
            refreshCharacterControls();
            sendPopup("test", "test\ntest\ntest\n");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.RefreshTokens.Clear();
            Settings.Default.RefreshTokens.AddRange(Characters.Select(kv => kv.Value.RefreshToken).ToArray());
            Settings.Default.Save();
        }

        private void sendPopup(string title, string body)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.ContentText = body;

            popup.ShowGrip = false;

            popup.TitleFont = new Font(new FontFamily("Microsoft Sans Serif"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
            popup.TitleColor = Color.White;
            popup.ContentColor = Color.LightGray;
            popup.BodyColor = SystemColors.ControlDarkDark;
            popup.HeaderColor = Color.Transparent;
            popup.HeaderHeight = 1;
            popup.Click += showThis;
            popup.TitlePadding = new Padding(4);
            popup.ContentHoverColor = popup.ContentColor;
            popup.ContentPadding = new Padding(4);

            popup.Popup();

        }
        private void showThis(object sender, EventArgs args)
        {
            

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = _isMaximized ? FormWindowState.Maximized : FormWindowState.Normal;
            }
            
            this.Activate();
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wparam = m.WParam.ToInt32() & 0xfff0;

                if (wparam == SC_MAXIMIZE)
                    _isMaximized = true;
                else if (wparam == SC_RESTORE)
                    _isMaximized = false;
            }

            base.WndProc(ref m);
        }

        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xf030;
        private const int SC_RESTORE = 0xf120;
        private bool _isMaximized;
    }
}
