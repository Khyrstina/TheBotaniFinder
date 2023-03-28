# Welcome to BotaniFinder!

BotaniFinder is an application that utilizes the Pl@ntNet API to identify plants from images that you upload through the ID Your Plant tab. After uploading your plant image it returns the top 2 matching plants according to the API, as well as a confidence score, and an image to compare to your original. Currently it adds the URL of the top result to an Azure database, and returns identified plants on the Previously Identified Plants tab of the application. There is lots of room to grow this application, the Pl@ntNet API can do so much more than I'm currently utilizing. 


# 3+ Required Features

 - **Make your application asynchronous:**
		 - The PlantIdentificationResult class sends an HTTP request to the Pl@ntNet API asynchronously, and deserializes the response asynchronously as well using JsonConvert.DeserializeObject.
 
 
 - **Use a generic class:**
		 - The BotaniFinderDbContext uses the generic class of DbContext that takes BotaniFinderDbContext as a type.


 - **Create a list and populate it with several values, retrieve at least one value and use it:**
		 - In the PlantIdentificationController class, the plantIdentificationResult.Results property is a list of Result objects.
		 - In the PreviousIdentificationsController class the _context.Urls.Select() method returns a list of Url objects.


 - **Comment two SOLID principles in your code:**
		 - Both the PlantIdentificationController and PreviousIdentificationsController classes have one responsibility, which is to handle plant identification and display previous identifications from the database. These classes demonstrate the Single Responsibility Principle (SRP).
		 - The BotaniFinderDbContext class is injected into the PlantIdentificationController and the PreviousIdentificationsController classes with their constructors which demonstrates the Dependency Inversion Principle (DIP).

# Special Instructions:

 1. On Line 17 of the PlantIdentificationController you will need to input the _plantNetApiUrl included in the project submission form. You can retrieve your own through the Pl@ntNet Developers page, which you can find in the Helpful Links tab.
 2. On line 3 of appsettings.json you will need to add the connection string for the Azure database. This can also be found in the project submission form.

