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
using System.Windows.Shapes;
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
            else
            {
                Home home = new Home();
                home.Show();
                this.Close();
            }
        }
    }
}
