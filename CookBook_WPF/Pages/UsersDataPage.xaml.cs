using DataLibrary;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для UsersDataPage.xaml
    /// </summary>
    public partial class UsersDataPage : Page
    {
        public UsersDataPage()
        {
            InitializeComponent();

            UpdateTable();
        }

        private void ChangeValueDataGrid(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataController.UpdateUser(e.Row.Item as User);
                UpdateTable();
            }
        }

        private void UpdateTable()
        {
            DataGridUsers.ItemsSource = DataController.LoadUsers();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataController.DeleteUser(DataGridUsers.SelectedItem as User);
            UpdateTable();
        }
    }
}
