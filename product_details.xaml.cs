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
    public partial class product_details : Window
    {
        public product_details(string title,double price,BitmapImage photo,string category)
        {
            InitializeComponent();
            Title_textbox.Text = title;
            price_textbox.Text = price.ToString();
            product_img.Source = photo;
            category_textbox.Text = category;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
    }
}
