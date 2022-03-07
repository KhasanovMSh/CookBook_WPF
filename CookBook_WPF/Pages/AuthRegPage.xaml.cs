using DataLibrary;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthRegPage.xaml
    /// </summary>
    public partial class AuthRegPage : Page
    {
        bool _auth = true;
        TypeDefenition _typeDef;

        public AuthRegPage(TypeDefenition typeDelegate)
        {
            InitializeComponent();
            _typeDef = typeDelegate;

        }

        private void BtnAuthReg_Click(object sender, RoutedEventArgs e)
        {
            if (_auth == true)
            {
                Authorization();
            }
            else
            {
                Registration();
            }
        }
        private void Registration()
        {
            bool IsReg = DataController.Regin("client", TbLogin.Text, TbPassword.Text, TbFirstName.Text, TbSurname.Text);
            if (IsReg)
            {
                _typeDef();
                PageManager.FrameMain.GoBack();
            }           
        }

        private void Authorization()
        {
            bool IsAuth = DataController.Login(TbLogin.Text, TbPassword.Text);
            if (IsAuth)
            {
                _typeDef();
                PageManager.FrameMain.GoBack();
            }

        }

        private void BtnChangeAuth_Click(object sender, RoutedEventArgs e)
        {
            if (_auth == true)
            {
                _auth = false;
                TbAuth.Text = "Регистрация";
                BtnChangeAuth.Content = "Авторизация";
                GridFirstName.Visibility = Visibility.Visible;
                GridSurname.Visibility = Visibility.Visible;
                BtnAuthReg.Content = "Зарегистрироваться";
            }
            else
            {
                _auth = true;
                TbAuth.Text = "Авторизация";
                BtnChangeAuth.Content = "Регистрация";
                GridFirstName.Visibility = Visibility.Hidden;
                GridSurname.Visibility = Visibility.Hidden;
                BtnAuthReg.Content = "Авторизоваться";
            }
        }
    }
}

