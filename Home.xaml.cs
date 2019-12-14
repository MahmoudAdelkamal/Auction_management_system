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
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            DataTable dt = new DataTable();
            dt = query.Get_categories();
            foreach (DataRow dr in dt.Rows)
            {
                Category_Combobox.Items.Add(dr["category_name"]);
            }
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
           // MessageBox.Show(x.Winner);
            product_details pd = new product_details(x.Title, x.price, x.photo, x.category);
            pd.Show();
        }
        private List<product> GetProducts()
        {
            DataTable dt = new DataTable();
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            dt = query.Retrieve_products();
            List<product> list = new List<product>();
            BitmapImage bmp = new BitmapImage();
            foreach (DataRow dr in dt.Rows)
            {
                byte[] img = null;
                img = (byte[])(dr["photo"]);
                BitmapImage b = new BitmapImage();
                b = bytes_to_image(img);
                product p = new product(Convert.ToInt32(dr["ID"]),dr["Winner"].ToString(), dr["Title"].ToString(), Convert.ToDouble(dr["price"]), b, dr["category"].ToString(), dr["start_date"].ToString(), dr["end_date"].ToString());
                list.Add(p);
            }
            return list;
        }
        private List<product> Get_Product_by_search()
        {
            DataTable dt = new DataTable();
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            dt = query.search_product(search_textbox.Text,Category_Combobox.Text);
            List<product> list = new List<product>();
            BitmapImage bmp = new BitmapImage();
            foreach (DataRow dr in dt.Rows)
            {
                byte[] img = null;
                img = (byte[])(dr["photo"]);
                BitmapImage b = new BitmapImage();
                b = bytes_to_image(img);
                product p = new product(Convert.ToInt32(dr["ID"]), dr["Winner"].ToString(), dr["Title"].ToString(), Convert.ToDouble(dr["price"]), b, dr["category"].ToString(), dr["start_date"].ToString(), dr["end_date"].ToString());
                list.Add(p);
            }
            return list;
        }
        private List<product> Get_products_by_category(string category)
        {
            DataTable dt = new DataTable();
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            dt = query.Filter_by_category(category);
            List<product> list = new List<product>();
            BitmapImage bmp = new BitmapImage();
            foreach (DataRow dr in dt.Rows)
            {
                byte[] img = null;
                img = (byte[])(dr["photo"]);
                BitmapImage b = new BitmapImage();
                b = bytes_to_image(img);
                product p = new product(Convert.ToInt32(dr["ID"]), dr["Winner"].ToString(), dr["Title"].ToString(),Convert.ToDouble(dr["price"]), b, dr["category"].ToString(),dr["start_date"].ToString(),dr["end_date"].ToString());
                list.Add(p);
            }
            return list;
        }
        private void search_textbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void search_textbox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            search_textbox.Text = "";
        }

        private void search_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var p = Get_Product_by_search();
            if (p.Count > 0)
                Listproduct.ItemsSource = p;
        }

        private void Category_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = Get_products_by_category(Category_Combobox.SelectedItem.ToString());
            if (p.Count > 0)
                Listproduct.ItemsSource = p;
        }
        private void join(object sender, RoutedEventArgs e)
        {
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            var btn = (Button)sender;
            var x = (product)btn.Tag;
            DateTime Start = Convert.ToDateTime(x.start_date);
            DateTime End = Convert.ToDateTime(x.end_date);
            int t1 = DateTime.Compare(Start, DateTime.Now);
            int t2 = DateTime.Compare(DateTime.Now, End);
            if (t1 > 0)
            {
                MessageBox.Show("The session didn't start yet");         
            }
            else if (t2 < 0)
            {
                Session session = new Session(x.Id, x.photo, x.Title, x.Winner, x.price);
                session.Show();
                this.Close();
            }
            else if (t2 > 0)
            {
                
               MessageBox.Show("The winner is " + x.Winner);
            }
        }
    }
}

