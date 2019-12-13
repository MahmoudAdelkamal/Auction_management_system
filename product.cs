using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace Auction_Management_system
{
    class product
    {
        public string Title { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public BitmapImage photo { get; set; }
        public product(string Title,double price,BitmapImage photo,string category)
        {
            this.Title = Title;
            this.photo = photo;
            this.price = price;
            this.category = category;
        }
    }
}
