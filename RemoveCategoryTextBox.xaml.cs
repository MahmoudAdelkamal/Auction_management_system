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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;


namespace Auction_Management_system
{
    /// <summary>
    /// Interaction logic for RemoveCategoryTextBox.xaml
    /// </summary>
    public partial class RemoveCategoryTextBox : Window
    {
        public RemoveCategoryTextBox()
        {
            InitializeComponent();
        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            if (DeleteCategoryName.Text == "")
            {
                MessageBox.Show("Please Enter A Category Name");
            }
            else // two cases if exist delete else print not exist
            {
                sql_queries sql = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
                bool found = sql.check_catagory(DeleteCategoryName.Text);
                if (found) // delete
                {
                    // e3mal query y delete el category

                    sql.Delete_catagory(DeleteCategoryName.Text);
                    sql.update_catagories(DeleteCategoryName.Text);
                    MessageBox.Show("Category Removed Successfully");
                }
                else
                {
                    MessageBox.Show("This Category isn't Exist"); 
                }

            }
        }
    }
}
