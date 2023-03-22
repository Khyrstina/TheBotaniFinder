using Microsoft.CodeAnalysis.CSharp.Syntax;
using Plant.NET.Infrastructure;
using Plant.NET.Models;
using System.IO;

namespace BotaniFinder.Models
{
    public class PlantImage : PlantImageBase<Stream>
    {
        private string imageString;
        private PlantOrgan leaf;

        public PlantImage(Stream image, PlantOrgan organ = (PlantOrgan)PlantNetClientDefaults.Organ) : base(image, organ)
        {
            
        }
       
    }
   
}
