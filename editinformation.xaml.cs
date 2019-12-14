using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;

namespace Auction_Management_system
{
    public partial class editinformation : Window
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=(local);Initial Catalog=Auction_mangement_system;Integrated Security=True");

        public editinformation()
        {
            InitializeComponent();
            username_block.Text = User.username;
            profilename_block.Text = User.profilename;
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void Create_session_Click(object sender, RoutedEventArgs e)
        {
            Create_session create_Session = new Create_session();
            create_Session.Show();
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

        private void username_Click(object sender, RoutedEventArgs e)
        {
            Validator validator = new Validator();
            validator.validate_user(username_textbox.Text,User.username,"username");
        
        }

        private void Profilename_Click(object sender, RoutedEventArgs e)
        {
            Validator validator = new Validator();
            validator.validate_user(profile_name_textbox.Text, User.profilename, "profile_name");
        }

        private void password_Click(object sender, RoutedEventArgs e)
        {
            Validator validator = new Validator();
            validator.validate_user(password_box.Text, User.password, "password");
        }
    }
}