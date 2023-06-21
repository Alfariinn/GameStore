using GameStore.MVVM.Model;
using Microsoft.EntityFrameworkCore;
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

namespace GameStore
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public  LoginScreen()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var Username = txtUser.Text;
            var Password = txtPass.Password;

            using (GameStoreDBContext dbContext = new GameStoreDBContext())
            {
                //sprawdza czy w bazie istnieje User dla którego Username i Password pasują do tych wpisanych w formularzu
                bool userfound = dbContext.Users.Any(user => user.Username == Username&& user.Password == Password);
                bool emptyEntry = (Username != "" && Password != "");
                //dbContext.Users.Remove(dbContext.Users.Single(u => u.Username == ""));
                //dbContext.SaveChanges();

                if (!emptyEntry)
                    return;

                if (userfound)
                {
                    GrantAcces();
                    Close();
                }
                else
                {
                    MessageBox.Show("Login failed!");
                }


            }

        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
 
            var Username = txtUser.Text;
            var Password = txtPass.Password;

            using (GameStoreDBContext dbContext = new GameStoreDBContext())
            {
                bool userfound = dbContext.Users.Any(user => user.Username == Username);
                bool emptyEntry = (Username != "" && Password != "");
                bool length = Username.Length <=20 && Password.Length <=20;

                if (!emptyEntry)
                    return;

                if (userfound)
                {
                    MessageBox.Show("That user already exist.");
                }
                else if (length)
                {
                    dbContext.Users.Add(new User() { Username = Username, Password = Password });
                    dbContext.SaveChanges();
                    MessageBox.Show("New user registered");
                }

                else
                    MessageBox.Show("Registration failed");
            }
        }

        public void GrantAcces()
        {
            StoreScreen StoreMain = new StoreScreen();
            StoreMain.Show();
        }

    }
}
