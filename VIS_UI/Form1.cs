
using BusinessLayer.Services;
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


namespace VIS_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //
        private void button1_Click(object sender, EventArgs e)
        {
            string login = txbLogin.Text.Trim();

            string password = txbPassword.Text.Trim();
            int result = AccountService.Instance.Login(login, password);
            if(result == 0)
            {
                Account account = AccountService.Instance.getUserDetailbyLogin(login);
                using (fSportManager f = new fSportManager(account))
                {
                    f.ShowDialog();
                }
            }
            else if (result == 1)
            {
                    MessageBox.Show("Login or Password is Incorrect", "Incorrect Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Required Fields are Empty", "Please Fill All Required Fields..!", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
