using System.Text.Json;

namespace DataLibrary
{
    public static class RecipeSerializator
    {
        public static string SerializeIngridientsAndSteps(IngridientsAndSteps tempIngridients)
        {
            return JsonSerializer.Serialize(tempIngridients);
        }

        public static string SerializeCategories(RecipeCategories tempCategories)
        {
            return JsonSerializer.Serialize(tempCategories);
        }

        public static IngridientsAndSteps DeserializeIngridientsAndSteps(string tempIngridients)
        {
            return JsonSerializer.Deserialize<IngridientsAndSteps>(tempIngridients);
        }

        public static RecipeCategories SerializeCategories(string tempCategories)
        {
            return JsonSerializer.Deserialize<RecipeCategories>(tempCategories);
        }
    }
}
