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
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result(BitmapImage photo, string title, double price, string winner)
        {
            InitializeComponent();
            product_image.Source = photo;
            title_res.Text = title;
            topprice_res.Text = price.ToString();
            winner_name.Text = winner;
        }
    }
}
