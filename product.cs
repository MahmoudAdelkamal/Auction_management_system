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
        public string description { get; set; }
        public int Id { get; set; }
        public double price { get; set; }
        public string Winner { get; set; }
        public string seller { get; set; }
        public BitmapImage photo { get; set; }
        public string category { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public product(int Id,string Winner,string seller,string Title,double price,BitmapImage photo,string category,string start_date,string end_date,string description)
        {
            this.Id = Id;
            this.Winner = Winner;
            this.seller = seller;
            this.Title = Title;
            this.price = price;
            this.photo = photo;
            this.category = category;
            this.start_date = start_date;
            this.end_date = end_date;
            this.description = description;
        }
    }
}
