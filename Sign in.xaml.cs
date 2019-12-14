using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
    public partial class Sign_in : Window
    {
        public Sign_in()
        {
            InitializeComponent();
        }
        private void log_in_btn(object sender, EventArgs e)
        {
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            if (!query.check_username_and_password(username_login_textbox.Text, password_login_passwordbox.Password))
            {
                MessageBox.Show("Invalid username or password");
            }
            else if (username_login_textbox.Text.ToLower()=="admin")
            {
                Admin_Home admin_Home = new Admin_Home();
                admin_Home.Show();
                this.Close();
            }
            else
            {
                DataTable dt = new DataTable();
                dt = query.profilename(username_login_textbox.Text);
                User.profilename = dt.Rows[0]["profile_name"].ToString();
                User.username = dt.Rows[0]["username"].ToString();
                User.password = dt.Rows[0]["password"].ToString();
                Home home = new Home();
                home.Show();
                this.Close();
            }
        }
    }
}
