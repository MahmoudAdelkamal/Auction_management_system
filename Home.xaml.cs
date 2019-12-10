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
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                Listproduct.ItemsSource = products;
        }
        private void home_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        private void Create_session_Click(object sender, EventArgs e)
        {
            Create_session session = new Create_session();
            session.Show();
            this.Close();
        }
        private void category_Click(object sender, EventArgs e)
        {

        }
        private void account_Click(object sender, EventArgs e)
        {
            
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
        private BitmapImage bytes_to_image(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = ms;
            bmp.EndInit();
            return bmp;
        }
        private void details_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var x = (product)btn.Tag;
            product_details pd = new product_details(x.Title);
            pd.Show();
        }
        private List<product> GetProducts()
        { 
            DataTable dt = new DataTable();
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            dt = query.Retrieve_products();
            List<product> list = new List<product>();
            foreach(DataRow dr in dt.Rows)
            {
                product p = new product(dr["Title"].ToString(),Convert.ToDouble (dr["price"]),"C:\\Users\\Lenovo\\Pictures\\Camera Roll\\iphone.jpg");
                list.Add(p);
            }
            return list;    
        }
      }
   }
    
          