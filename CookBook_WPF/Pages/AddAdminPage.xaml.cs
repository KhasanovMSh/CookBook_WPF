using DataLibrary;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAdminPage.xaml
    /// </summary>
    public partial class AddAdminPage : Page
    {
        public AddAdminPage()
        {
            InitializeComponent();
        }

        private void BtnAdminReg_Click(object sender, RoutedEventArgs e)
        {
            bool IsReg = DataController.Regin("admin", TbLogin.Text, TbPassword.Text, TbFirstName.Text, TbSurname.Text);
            if (IsReg)
            {
                PageManager.FrameMain.GoBack();
            }
        }
    }
}
