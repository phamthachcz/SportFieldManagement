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


namespace VIS_UI.UserControls
{
    public partial class UC_Settings : UserControl
    {
        private Account loginAccount;
        private Employee loginEmployee;
        public UC_Settings(Account loginAccount)
        {
            InitializeComponent();
            this.loginAccount = loginAccount;
            LoadInformation();
        }

        private void LoadInformation()
        {
            this.LoginEmployee = EmployeeService.Instance.getAccountDetailbyId(this.loginAccount.Id);
            txbLogin.Text = this.loginAccount.Login;
            txbFName.Text = this.loginEmployee.First_name;
            txbLName.Text = this.loginEmployee.Last_name;
            txbPhone.Text = this.loginEmployee.Phone;
            txbEmail.Text = this.loginEmployee.Email;
            if (this.loginEmployee.Gender == 0)
            {
                rdMale.Checked = true;
                rdFeMale.Checked = false;
                rdUnDetect.Checked = false;
            }
            else if (this.loginEmployee.Gender == 1)
            {
                rdMale.Checked = false;
                rdFeMale.Checked = true;
                rdUnDetect.Checked = false;
            }
            else
            {
                rdMale.Checked = false;
                rdFeMale.Checked = false;
                rdUnDetect.Checked = true;
            }
            dtBirthday.Value = this.loginEmployee.Date_of_birth;
        }

        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }
        public Employee LoginEmployee { get => loginEmployee; set => loginEmployee = value; }

        private void btnUpdateInfor_Click(object sender, EventArgs e)
        {
            string fname = txbFName.Text;
            string lname = txbLName.Text;

            string phone = txbPhone.Text;
            string email = txbEmail.Text;
            DateTime birthday = dtBirthday.Value;
            int gender = 0;
            if (rdMale.Checked)
            {
                gender = 0;
            }
            else if (rdFeMale.Checked)
            {
                gender = 1;
            }
            else
            {
                gender = 2;
            }
            if (EmployeeService.Instance.UpdateEmployee(this.loginEmployee.Account_id, fname, lname, gender, phone, email, birthday))
            {
                MessageBox.Show("Update Information Sucessfull!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Updare error", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadInformation();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string currentPass = txbCurrentPass.Text;
            string newPass = txbNewPass.Text;
            string rePass = txbRePass.Text;

            if (currentPass == "" && newPass == "" && rePass == "")
            {
                MessageBox.Show("Password does not blank!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!newPass.Equals(rePass))
                {
                    MessageBox.Show("New password and Re-Enter password not match");
                }
                if (AccountService.Instance.AccountUpdate(this.loginAccount.Login, currentPass, newPass))
                {
                    MessageBox.Show("Update Information Sucessfull!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Check Current Password!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
