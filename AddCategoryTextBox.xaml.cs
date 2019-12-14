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
    /// Interaction logic for AddCategoryTextBox.xaml
    /// </summary>
    public partial class AddCategoryTextBox : Window
    {
        public AddCategoryTextBox()
        {
            InitializeComponent();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            if(CategoryName.Text == "") 
            {
                MessageBox.Show("Please Enter A Category Name");
            }
            else // two cases if it already exit , else add it to database
            {
                sql_queries sql = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
                bool found = sql.check_catagory(CategoryName.Text);

                if (found)
                {
                    MessageBox.Show("This Category is Already Exist");
                }
                else
                {
                    // e3mel query y insert Category *note that how we can make the combbobox change when insertion , delete
                    sql.Add_catagory(CategoryName.Text);
                    MessageBox.Show("Category Inserted Successfully");
                }
                

            }


        }

    }
}
