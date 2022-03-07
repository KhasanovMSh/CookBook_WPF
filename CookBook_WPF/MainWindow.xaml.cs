using CookBook_WPF.Pages;
using DataLibrary;
using System;
using System.Windows;
using System.Windows.Input;

namespace CookBook_WPF
{
    public delegate void TypeDefenition();
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TypeDefenition typeDef;

        public MainWindow()
        {
            InitializeComponent();
            typeDef = UserTypeDefenition;

            PageManager.FrameMain = MainFrame;
            PageManager.FrameMain.Navigate(new RecipeViewPage());
        }

        private void UserTypeDefenition()
        {
            switch (CurrentUser.currentUser.UserType)
            {
                case "client":
                    {
                        BtnAccount.Visibility = Visibility.Visible;
                        BtnAddRecipe.Visibility = Visibility.Visible;
                        BtnLogout.Visibility = Visibility.Visible;
                        BtnLogin.Visibility = Visibility.Collapsed;
                        TbUser.Text = CurrentUser.currentUser.Name + " " + CurrentUser.currentUser.Surname;
                        break;
                    }
                case "admin":
                    {
                        BtnAccount.Visibility = Visibility.Visible;
                        BtnAddRecipe.Visibility = Visibility.Visible;
                        BtnLogout.Visibility = Visibility.Visible;
                        BtnAddAdmin.Visibility = Visibility.Visible;
                        BtnUsersData.Visibility = Visibility.Visible;
                        BtnLogin.Visibility = Visibility.Collapsed;
                        TbUser.Text = CurrentUser.currentUser.Name + " " + CurrentUser.currentUser.Surname;
                        break;
                    }
            }            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.GoBack();
            BtnAccount.Visibility = Visibility.Visible;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnMenu.Visibility = Visibility.Hidden;
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnMenu.Visibility = Visibility.Visible;
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void BtnAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupAccount.IsOpen = true;
        }

        private void BtnAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupAccount.IsOpen = false;
        }

        private void PopupAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            PopupAccount.IsOpen = true;
        }

        private void PopupAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            PopupAccount.IsOpen = false;
        }

        private void BtnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            BtnAccount.Visibility = Visibility.Hidden;
            PopupAccount.IsOpen = false;
            PageManager.FrameMain.Navigate(new AddRecipePage());
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            BtnAccount.Visibility = Visibility.Hidden;
            PopupAccount.IsOpen = false;
            PageManager.FrameMain.Navigate(new AuthRegPage(typeDef));
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            TbUser.Text = string.Empty;
            BtnLogout.Visibility = Visibility.Collapsed;
            BtnAddRecipe.Visibility = Visibility.Collapsed;
            BtnLogin.Visibility = Visibility.Visible;
            BtnAddAdmin.Visibility = Visibility.Collapsed;
            BtnUsersData.Visibility = Visibility.Collapsed;
            CurrentUser.currentUser = null;
        }

        private void BtnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new AddAdminPage());
        }

        private void BtnUsersData_Click(object sender, RoutedEventArgs e)
        {
            PageManager.FrameMain.Navigate(new UsersDataPage());
        }
    }
}
