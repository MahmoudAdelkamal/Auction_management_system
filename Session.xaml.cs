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
    public partial class Session : Window
    {
        private int Id;
        private string Winner;
        private double current_price;
        public Session(int Id,BitmapImage b,string title,string Winner,double current_price)
        { 
            InitializeComponent();
            this.Id = Id;
            this.Winner = Winner;
            this.current_price = current_price;
            product_img.Source = b;
            titinsession.Text = title;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        private void Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Log out", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        private void Top_price_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The current price is " + current_price.ToString());
        }
        private void Bid_Click(object sender, RoutedEventArgs e)
        {
            if (current_price_textbox.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a value");
            }
            else if (Convert.ToDouble(current_price_textbox.Text) <= current_price)
            {
                MessageBox.Show("The entered price should be higher than the current price");
            }
            else
            {
                current_price = Convert.ToDouble(current_price_textbox.Text);
                sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
                query.update_top_price(current_price,Id,User.profilename);
            }
                current_price_textbox.Text = "";
        }
    }
}
