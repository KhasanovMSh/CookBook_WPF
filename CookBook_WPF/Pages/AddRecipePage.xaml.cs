using DataLibrary;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookBook_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRecipePage.xaml
    /// </summary>
    public partial class AddRecipePage : Page
    {
        string path;
        BitmapImage bitmapImg;

        public AddRecipePage()
        {
            InitializeComponent();
        }

        private void BtnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images |*.png;*.jpg";

            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                bitmapImg = new BitmapImage(new Uri(path));
                ImageRecipe.Source = bitmapImg;
            }
        }

        private void BtnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (TbName.Text == "" || TbType.Text == "" || TbIngridients.Text == "" || TbSteps.Text == "" || ImageRecipe.Source == null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            }
            else
            {
                string tempSteps = RecipeSerializator.SerializeIngridientsAndSteps(new IngridientsAndSteps() { Ingridients = TbIngridients.Text, Steps = TbSteps.Text });

                bool IsAdd=DataController.AddRecipe(TbName.Text, TbType.Text, tempSteps, path);
                if (IsAdd)
                {
                    PageManager.FrameMain.GoBack();
                }
            }
        }
    }
}
