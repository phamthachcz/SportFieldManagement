using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VIS_UI.UserControls;

namespace VIS_UI
{
    public partial class fSportManager : Form
    {
        int PanelWidth;
        bool isCollapsed;
        private Account loginAccount;

        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }

        public fSportManager(Account account)
        {
            InitializeComponent();
            this.LoginAccount = account;
            timerTime.Start();
            timerDay.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            LoadConfig();
        }

        private void LoadConfig()
        {
            lbLogin.Text = this.loginAccount.Login;
            if(this.loginAccount.Type == 0)
            {
                lbRole.Text = "Admin";
            }
            else if(this.loginAccount.Type == 1)
            {
                lbRole.Text = "Manager";
            }
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnClosefSport_Click(object sender, EventArgs e)
        {
            timerTime.Stop();
            timerDay.Stop();
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if(panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if(panelLeft.Width <= 58)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void moveSidePanel(Control btn)
        {
            panelMove.Top = btn.Top;
            panelMove.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(c);
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:mm:ss");
        }

        private void timerDay_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelDay.Text = dt.ToString("dd-MM-yyyy");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSettings);
            UC_Settings uC_Settings = new UC_Settings(loginAccount);
            AddControlsToPanel(uC_Settings);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSettings);
            UC_Booking uC_Booking = new UC_Booking();
            AddControlsToPanel(uC_Booking);
        }
    }
}
