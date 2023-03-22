namespace BotaniFinder.Models
{
    public enum PlantOrgan
    {
        Flower,
        Leaf,
        Bark,
        Fruit
    }

    public static class PlantOrganExtensions
    {
        public static string GetName(this PlantOrgan plantOrgan)
        {
            return plantOrgan
                .ToString()
                .ToLowerInvariant();
        }
    }
}
