using DataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CookBook_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для RecipeViewPage.xaml
    /// </summary>
    public partial class RecipeViewPage : Page
    {
        public List<Recipe> currentRecipes;

        public RecipeViewPage()
        {
            InitializeComponent();

            UpdateRecipe();
        }
        private void UpdateRecipe()
        {
            currentRecipes = DataController.LoadRecipe();
            LViewRecipes.ItemsSource = currentRecipes;
        }

        private void LViewRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentObject = LViewRecipes.SelectedIndex;
            try
            {
                Recipe currentRecipe = currentRecipes[currentObject];
                TbName.Text = currentRecipe.Name;
                TbType.Text = currentRecipe.Categories;
                IngridientsAndSteps ingridients = RecipeSerializator.DeserializeIngridientsAndSteps(currentRecipe.Ingridients);
                TbIngridients.Text = ingridients.Ingridients + Environment.NewLine + ingridients.Steps;
            }
            catch(Exception ex)
            {

            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                using (RecipeBaseEntities db=new RecipeBaseEntities())
                {
                    db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                }
                UpdateRecipe();
            }
        }


        private void BtnFavourite_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
