using Plant.NET;
using Plant.NET.Models;

public class PlantIdentificationService
{
    private PlantNetClient _plantNet;

    public PlantIdentificationService(PlantNetClient plantNet)
    {
        _plantNet = plantNet;
    }

    //internal static Task IdentifyPlant(Stream image)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task IdentifyPlant(string imageUrl)
    {
        // Create a new RemotePlantImage with an optional PlantOrgan tag (defaults to PlantOrgan.Leaf)
        var plantImage = new RemotePlantImage(imageUrl, PlantOrgan.Leaf);

        // Get a list of possible plant species
        var result = await _plantNet.Identify(plantImage);
    }

}
