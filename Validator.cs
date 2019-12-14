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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Auction_Management_system
{
    class Validator
    {
        public void validate_user(string new_name,string old_name,string type)
        {
            bool valid = true;
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            for(int i=0;i<new_name.Length;i++)
            {
                if (!char.IsDigit(new_name[i]) && !char.IsLetter(new_name[i]))
                {
                    valid = false;
                }
            }
            if (!valid)
            {
                MessageBox.Show("The username must contain only letters and digits !");
            }
            else if(new_name.Length==0)
            {
                MessageBox.Show("Please enter the " + type);
            }
            else if (new_name.Length > 10 || new_name.Length < 5)
            {
                MessageBox.Show("The "+type+" must be between 5 and 10 characters" );
            }
            else if(type=="username" && query.check_username(new_name))
            {
                MessageBox.Show("This username is already taken !");
            }
            else
            {
                query.update_user(new_name,old_name,type);
                if (type == "username")
                    User.username = new_name;
                else if (type == "profile_name")
                    User.profilename = new_name;
                else
                    User.password = new_name;
                MessageBox.Show("The " + type + " is updated successfully");
            }
        }

        public void validate_signup(string username , string password,string repassword,string profilenme)
        {
            bool valid = true; string notvalid = "";
            sql_queries query = new sql_queries("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");
            for (int i = 0; i < username.Length; i++)
            {
                if (!char.IsDigit(username[i]) && !char.IsLetter(username[i]))
                {
                    notvalid = "username";
                    valid = false;
                }
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsDigit(password[i]) && !char.IsLetter(password[i]))
                {
                    notvalid = "password";
                    valid = false;
                }
            }
            for (int i = 0; i < profilenme.Length; i++)
            {
                if (!char.IsDigit(profilenme[i]) && !char.IsLetter(profilenme[i]))
                {
                    notvalid = "profile_name";
                    valid = false;
                }
            }

            if (!valid)
            {
                MessageBox.Show("The "+notvalid+" must contain only letters and digits !");
            }
            else if (username == "" || password == "" || profilenme == "")
            {
                MessageBox.Show("Fill the username , password and profile name first");
            }
            else if (password.Length > 10 || password.Length < 5)
            {
                MessageBox.Show("The password should be between 5 and 10 characters ");
            }
            else if (username.Length > 10 || username.Length < 5)
            {
                MessageBox.Show("The username should be between 5 and 10 characters ");
            }
            else if (profilenme.Length > 10 || profilenme.Length < 5)
            {
                MessageBox.Show("The profile name should be between 5 and 10 characters ");
            }
            else if (repassword.Length == 0)
            {
                MessageBox.Show("Confirm the password");
            }
            else if (repassword != password)
            {
                MessageBox.Show("The two password don't match !");
            }
            else
            {
               
                if (query.check_username(username))
                {
                    MessageBox.Show("This username is already taken!");
                }
                else
                {
                    query.insert_user_information(profilenme , username, password);
                    MessageBox.Show("Registrated successifly!");
                    Sign_in signin = new Sign_in();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Close();
                    signin.Show();
                }
            }

        }
        
    }
}
