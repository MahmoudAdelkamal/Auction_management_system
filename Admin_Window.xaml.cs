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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Admin_Window : Window
    {
        public Admin_Window()
        {
            InitializeComponent();
        }

        private void AddCategoryButton(object sender, RoutedEventArgs e)
        {
            AddCategoryTextBox addCategory = new AddCategoryTextBox();
            addCategory.Show();
        }

        private void RemoveCategoryButton(object sender, RoutedEventArgs e)
        {
            RemoveCategoryTextBox removeCategory = new RemoveCategoryTextBox();
            removeCategory.Show();
        }
        
        private void RemoveUserButton(object sender, RoutedEventArgs e)
        {
            RemoveUserBox removeUser = new RemoveUserBox();
            removeUser.Show();
        }

    }
}
