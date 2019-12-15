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

        ///////////////////////////////////////////////////////////////Inserting data into the database//////////////////////////////////////////////////


        //inserting the user information into the database 
        public void insert_user_information(string profilename, string username, string password)
        {
            try
            {
                sqlcon.Open();
                string query = "Sign_Up";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter("@username", username);
                sqlcmd.Parameters.Add(sqlParameter);
                SqlParameter parameter = new SqlParameter("@profilename", profilename);
                sqlcmd.Parameters.Add(parameter);
                SqlParameter parameter2 = new SqlParameter("@password", password);
                sqlcmd.Parameters.Add(parameter2);

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
        public void insert_product_info(string Title, double price, string category, string description, string image_location, string startdate, string enddate,string seller)
        {
            byte[] image = null;
            FileStream fs = new FileStream(image_location, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            image = br.ReadBytes((int)fs.Length);
            try
            {
                sqlcon.Open();
                string query = "Insert_product";
                SqlCommand sqlcmd;
                sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add(new SqlParameter("@Title", Title));
                sqlcmd.Parameters.Add(new SqlParameter("@price", price));
                sqlcmd.Parameters.Add(new SqlParameter("@category", category));
                sqlcmd.Parameters.Add(new SqlParameter("@description", description));
                sqlcmd.Parameters.Add(new SqlParameter("@image", image));
                sqlcmd.Parameters.Add(new SqlParameter("@start", startdate));
                sqlcmd.Parameters.Add(new SqlParameter("@end", enddate));
                sqlcmd.Parameters.Add(new SqlParameter("@seller", seller));
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
                string query = "check_username";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", name));
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
            catch (SqlException exception)
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
        public bool check_username_and_password(string name, string password)
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string query = "check_username_and_password";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt.Rows.Count > 0;
        }

        public void Delete_user(string name)
        {
            try
            {
                sqlcon.Open();
                string query = "delete from UserInformation where username = '" + name + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.ExecuteNonQuery();


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

        /////////////////////////////////////////////////////////////////Retrieving data from the database//////////////////////////////////////////////////////

        public DataTable profilename(string username)
        {
            DataTable dt = new DataTable();
            string query = "select * from UserInformation where username = '" + username + "'";
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

        /////////////////////////////////////////////////////////////////Retrieving data from the database//////////////////////////////////////////////////////

        //retrieve all of products to show it in the home page
        public DataTable Retrieve_products()
        {
            DataTable dt = new DataTable();
            try
            {
                sqlcon.Open();
                string query = "select * from product";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch (SqlException exception)
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
        public DataTable search_product(string title, string category)
        {
            DataTable dt = new DataTable();
            string query;
            if (category == "")
            {
                query = "select * from product where  Title like'%" + title + "%'";
            }
            else
            {       
                query = "select * from product where category='" + category + "' and Title like'%" + title + "%'";
            } 
            try
            {
                sqlcon.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                sda.Fill(dt);
            }
            catch (SqlException exception)
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

                string querys = "select * from product where category ='" + category + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querys, sqlcon);
                sda.Fill(dt);
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }
        //------------------------------ check catagory ---------------------------//
    public bool check_catagory(string catagory)
    {
        DataTable dt = new DataTable();
        try
        {
            sqlcon.Open();
            string query = "check_category";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@category", catagory));
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            sda.SelectCommand = cmd;
            sda.Fill(dt);
        }
        catch (SqlException exception)
        {
            MessageBox.Show(exception.Message);
        }
        finally
        {
            sqlcon.Close();
        }
        return dt.Rows.Count > 0;
    }
        ////// delete catagory////////////// 
        public void Delete_catagory(string catagory)
        {
            try
            {
                sqlcon.Open();
                string query = "delete from Category where category_name = '" + catagory + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);

                cmd.ExecuteNonQuery();

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
        // update 
        public void update_catagories(string catagory)
        {
            try
            {
                sqlcon.Open();
                string query = "update product set category = 'others' where category= '" + catagory + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);

                cmd.ExecuteNonQuery();

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

        // add catagory
        public void Add_catagory(string catagory)
        {
            try
            {
                sqlcon.Open();
                string query = "insert into Category values ( '" + catagory + "')";
                SqlCommand cmd = new SqlCommand(query, sqlcon);

                cmd.ExecuteNonQuery();

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
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return dt;
        }
        ///////////////////////////////////////////////////////Update queries////////////////////////////////////////////////
        public void update_top_price(double value, int Id, string username)
        {
            string query = "update product set price = " + value + ", Winner ='" + username + "'" + "where id =" + Id;
            try
            {
                sqlcon.Open();
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
        public void update_user(string new_name,string old_name,string type)
        {
            string query = "update UserInformation set " + type + "= '" + new_name + "'"+"where "+type+"= '"+old_name+"'";
            try
            {
                sqlcon.Open();
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
        /////////////////////////////////////////Deleting queries////////////////////////////////////////////////////////////
        public void delete_product(int id)
        {
            string query = "delete from product where id = " + id;
            try
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.ExecuteNonQuery();
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        }
    }
}