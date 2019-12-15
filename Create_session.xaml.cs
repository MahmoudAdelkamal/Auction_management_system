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
using System.Data;
namespace Auction_Management_system
{
    public partial class Create_session : Window
    {
        sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
        private string imgloc = "";
        public Create_session()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = query.Get_categories();
            foreach(DataRow dr in dt.Rows)
            {
                category_textbox.Items.Add(dr["category_name"]);
            }
        }
        private void Home_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }
        private void category_Click(object sender, EventArgs e)
        {

        }
        private void account_Click(object sender, EventArgs e)
        {

        }
        private void Create_session_Click(object sender, EventArgs e)
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
        private void Browse_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "JPEG|*.jpg";
            dlg.Title = "select product image";
            bool? res = dlg.ShowDialog();
            if (res == true)
            {
                imgloc = dlg.FileName.ToString();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imgloc);
                bitmap.EndInit();
                product_img.Source = bitmap;
            }
        }
        private void clear()
        {
            Title_textbox.Text = "";
            Description_textbox.Text = "";
            category_textbox.Text = "";
            price_textbox.Text = "";
            datepicker1.SelectedDate = null;
            datepicker2.SelectedDate = null;
            time1.SelectedTime = null;
            time2.SelectedTime = null;
            product_img.Source = null;
        }
        private void sumbit_Click(object sender, EventArgs e)
        {
            DateTime dt1 = Convert.ToDateTime(datepicker1.SelectedDate);
            DateTime time = Convert.ToDateTime(time1.SelectedTime);
            DateTime dtime2 = Convert.ToDateTime(time2.SelectedTime);
            DateTime dt2 = Convert.ToDateTime(datepicker2.SelectedDate);
            string startdate = "";
            string enddate = "";
            startdate = time1.SelectedTime.ToString();
            enddate = time2.SelectedTime.ToString();
            if (Title_textbox.Text.Length > 30 || Title_textbox.Text.Length < 5)
            {
                MessageBox.Show("The title length should be between 5 and 30 letters ! ");
            }
            else if (price_textbox.Text.Length == 0)
            {
                MessageBox.Show("Please Enter the initial price !");
            }
            else if (Convert.ToDouble(price_textbox.Text) <= 0)
            {
                MessageBox.Show("The initial price should be more than zero");
            }
            else if (imgloc == "")
            {
                MessageBox.Show("please Enter the image of the product");
            }
            else if (datepicker1.SelectedDate.ToString().Length == 0 || datepicker2.SelectedDate.ToString().Length == 0)
            {
                MessageBox.Show("please Enter the start and the end date of the session");
            }
            else if (DateTime.Compare(dt1, DateTime.Now.AddDays(-1)) < 0)
            {
                MessageBox.Show("The starting date should be a valid date !");
            }
            else if (DateTime.Compare(dt1, dt2) > 0)
            {
                MessageBox.Show("The end date couldn't be earlier than the start date ! ");
            }
            else
            {
                query.insert_product_info(Title_textbox.Text, Convert.ToDouble(price_textbox.Text), category_textbox.Text, Description_textbox.Text, imgloc, startdate, enddate,User.username);
                MessageBox.Show("The product has been submitted to the Admin");
                clear();
            }
        }
    }
}