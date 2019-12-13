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
    class sql_queries
    {
        private SqlConnection sqlcon;

        public sql_queries(string connectionstrings)
        {
            sqlcon = new SqlConnection(connectionstrings);
        }

        ////////////////////////////////////////////////////////////Inserting data into the database//////////////////////////////////////////////////
       

        //inserting the user information into the database 
        public void insert_user_information(string profilename,string username,string password)
        {
            try
            {
                sqlcon.Open();
                string query = "insert into UserInformation (username,profile_name,password) values('" + username + "','" + profilename + "','" + password + "'" + ")";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
        //inserting the product information into the database
        public void insert_product_info(string Title, double price, string category, string description, string image_location, string startdate, string enddate)
        {
            byte[] image = null;
            FileStream fs = new FileStream(image_location, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            image = br.ReadBytes((int)fs.Length);
            try
            {
                sqlcon.Open();
                string query = "insert into session(Title,price,category,Descriptions,photo,start_date,end_date) values(@Title,@price,@category,@description,@image,@start,@end)";
                SqlCommand sqlcmd;
                sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.Add(new SqlParameter("@Title", Title));
                sqlcmd.Parameters.Add(new SqlParameter("@price", price));
                sqlcmd.Parameters.Add(new SqlParameter("@category", category));
                sqlcmd.Parameters.Add(new SqlParameter("@description", description));
                sqlcmd.Parameters.Add(new SqlParameter("@image", image));
                sqlcmd.Parameters.Add(new SqlParameter("@start", startdate));
                sqlcmd.Parameters.Add(new SqlParameter("@end", enddate));
                sqlcmd.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }

    ///////////////////////////////////////////////////////////User Authentication/////////////////////////////////////////////////////////////    

        // checking for the existence of a specific username in the database
        public bool check_username(string name)
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string query = "select username from UserInformation where username=" + "'" + name + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt.Rows.Count > 0;
        }
        // checking for the existence of a specific username and password in the database
        public bool check_username_and_password(string name,string password) 
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string query= "select username,password from UserInformation where username="+"'"+name+"'"+"and password="+"'"+password+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt.Rows.Count > 0;
        }

       /////////////////////////////////////////////////////////////////Retrieving data from the database//////////////////////////////////////////////////////

            //retrieve all of products to show it in the home page
        public DataTable Retrieve_products()
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string query = "select * from session";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }
        //searching for specific product
        public DataTable search_product(string title)
        {
            DataTable dt = new DataTable();
            string query = "select * from session where Title like'%" + title + "%'";
            try
            {
                sqlcon.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }

        //searching for a product in a specific category
        public DataTable Filter_by_category(string category)
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string querys = "select * from session where category ='" + category + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querys, sqlcon);
                sda.Fill(dt);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message) ;
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }
        public void g()
        {

        }
        // returns all the products found in a specific category
        public DataTable Get_categories()
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string query = "select * from Category";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }
    }
}


