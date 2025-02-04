using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo_App
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection("Data source = ToDo-App");
            connection.Open();

            if (connection.State == ConnectionState.Open)
            {
                var command = connection.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS Users (ID int primary key, Email text, Password text)";
                command.ExecuteNonQuery();
            }

            string emailValue = txtemail.Text;
            string passwordValue = txtpassword.Text;
            string CorrectPassword = txtpassword.Text;

            var emailValidation = Regex.Match(emailValue, "^[\\w\\.-]+@[a-zA-Z\\d\\.-]+\\.[a-zA-Z]{2,6}$");
            if (!emailValidation.Success)
            {
                MessageBox.Show("Email not Valid!", "pakiayos po",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (passwordValue != CorrectPassword)
            {
                MessageBox.Show("Password not Valid!", "pakiayos po", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (emailValidation.Success && passwordValue == CorrectPassword)
            {
                var command1 = connection.CreateCommand();
                command1.CommandText = $"INSERT INTO Users (email, password) values ('{emailValue}', '{passwordValue}')";
                command1.ExecuteNonQuery();
            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
