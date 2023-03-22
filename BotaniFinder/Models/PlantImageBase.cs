using System.Diagnostics.CodeAnalysis;
using Plant.NET.Infrastructure;
using Plant.NET.Models;

namespace BotaniFinder.Models
{
    public abstract class PlantImageBase<T>
    {
        public PlantImageBase(T image, PlantOrgan organ = (PlantOrgan)PlantNetClientDefaults.Organ)
        {
            Image = image;
            Organ = organ;
        }

        public void Deconstruct(out T image, out PlantOrgan organ)
        {
            image = Image;
            organ = Organ;

        }

        public T Image { get; }
        public PlantOrgan Organ { get; }
    }
}
