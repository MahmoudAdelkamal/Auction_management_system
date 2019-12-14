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
            Validator validator = new Validator();
            validator.validate_signup(username_textbox.Text, password_textbox.Password, repassword_textbox.Password, profilename_textbox.Text);
           
        }
        private void signinbtn(object sender, EventArgs e)
        {
            Sign_in signin = new Sign_in();
            signin.Show();
            this.Close();
        }
    }
}
