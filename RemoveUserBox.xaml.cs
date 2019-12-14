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
    public partial class RemoveUserBox : Window
    {
        public RemoveUserBox()
        {
            InitializeComponent();
        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            if (UserName.Text == "")
            {
                MessageBox.Show("Please Enter UserName");
            }
            else // two cases if it not found , else remove it from database
            {
                
               sql_queries sql = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
                bool found = sql.check_username(UserName.Text);
                if (found) // e3mel delete query ll username
                {

                    sql.Delete_user(UserName.Text);
                    MessageBox.Show("User Removed Successfully");
                }
                else
                {
                    MessageBox.Show("This UserName isn't Exist");
                }


            }
        }
    }
}
