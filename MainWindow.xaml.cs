using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Auction_Management_system
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SignUpbtn(object sender, EventArgs e)
        {
            if (username_textbox.Text == "" || password_textbox.Password == "" || profilename_textbox.Text == "")
            {
                MessageBox.Show("Fill the username , password and profile name first");
            }
            else if (password_textbox.Password.Length > 10 || password_textbox.Password.Length < 5)
            {
                MessageBox.Show("The password should be between 5 and 10 characters ");
            }
            else if (username_textbox.Text.Length > 10 || username_textbox.Text.Length < 5)
            {
                MessageBox.Show("The username should be between 5 and 10 characters ");
            }
            else if (profilename_textbox.Text.Length > 10 || profilename_textbox.Text.Length < 5)
            {
                MessageBox.Show("The profile name should be between 5 and 10 characters ");
            }
            else if (repassword_textbox.Password.Length == 0)
            {
                MessageBox.Show("Confirm the password");
            }
            else if (repassword_textbox.Password != password_textbox.Password)
            {
                MessageBox.Show("The two password don't match !");
            }
            else
            {
                sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
                if (query.check_username(username_textbox.Text))
                {
                    MessageBox.Show("This username is already taken!");
                }
                else
                {
                    query.insert_user_information(profilename_textbox.Text, username_textbox.Text, password_textbox.Password);
                    MessageBox.Show("Registrated successifly!");
                    Sign_in signin = new Sign_in();
                    this.Close();
                    signin.Show();
                }
            }
        }
        private void signinbtn(object sender, EventArgs e)
        {
            Sign_in signin = new Sign_in();
            signin.Show();
            this.Close();
        }
    }
}
