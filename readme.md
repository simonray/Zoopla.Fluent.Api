# Zoopla.Fluent.Api (.NET)

The Zoopla Fluent API provides functionality to retieve property information into your application.
     
Before you continue you will need to register for an API key from [Zoopla](http://developer.zoopla.com)
and update the appropriate configuration file. e.g.

     <appSettings>
        <add key="ZooplaApiKey" value="#your api key#"/>
     </appSettings>

To get started with the API simply add a reference and create an instance of the <c>Zoopla.Fluent.Api</c> class to start accessing the services. 

#Usage

Initialize the Api.

     var Api = new ZooplaFluentApi(ConfigurationManager.AppSettings["ZooplaApiKey"]);
     
 Get a list of properties for sale in Cheltenham.

     var listings = Api.Sales
         .In("Cheltenham")
         .Go();
         
 Get a paged list of properties  

     int pagesize = 25;
     int count = Api
         .Sales
         .OfHouses
         .In("GL52")
         .MinimumBeds(4)
         .MinimumPrice(250000)
         .MaximumPrice(350000)
         .PageSize(pagesize)
         .Count();
    
     for(int page = 1; ((page-1) * pagesize) < count; page++)
     {
         var listings = Api.Go(page);
     }
    
Get a list of suggested locations for the search term "gloucester" from the sales or rental listings group  

     var locations = Api.Suggestions("gloucester", SearchOption.SaleOrRentals);

#Sample Application

Provided is a basic console application that for a given property Id (-p) you can extract images (--ei) and floorplans (--ef).

    Zoopla.Console -p ######## -o"C:\Downloads" --ei --ef

#Stack
* [Automapper](https://www.nuget.org/packages/AutoMapper)  
* [Newton Json](https://www.nuget.org/packages/newtonsoft.json)
* [Sandcastle](http://sandcastle.codeplex.com)  
* [Sandcastle Help File Builder](http://shfb.codeplex.com)
* [Command Line Parser Library](https://www.nuget.org/packages/CommandLineParser)

#References
* [Zoopla Developer API](http://developer.zoopla.com/home)  
* [Zoopla Listing Documentation](http://developer.zoopla.com/docs/read/Property_listings)  
* [Zoopla Autocomplete Documentation](http://developer.zoopla.com/docs/read/Geo_Autocomplete)

#Tools
* [Json to C# Code Generator](http://json2csharp.com)  
