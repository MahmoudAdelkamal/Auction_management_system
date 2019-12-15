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
        public product_details(string title,double price,BitmapImage photo,string category,string description,string start_date,string end_date)
        {
            InitializeComponent();
            Title_textbox.Text = title;
            price_textbox.Text = price.ToString();
            product_img.Source = photo;
            category_textbox.Text = category;
            Description_textbox.Text = description;
            datepicker1.Text = start_date;
            datepicker2.Text = end_date;
        }
        private void Home_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        private void Create_session_Click(object sender, EventArgs e)
        {

        }
        private void account_Click(object sender, EventArgs e)
        {
            editinformation en = new editinformation();
            en.Show();
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
    }
}
