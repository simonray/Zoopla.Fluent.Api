using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoopla.Fluent.Api
{
    /// <summary>
    /// ZooplaFluentApi (.NET)
    /// 
    /// The Zoopla Fluent API provides functionality to retieve property information into your application. 
    /// 
    /// Before you start you will need to register for an API key from [Zoopla](http://developer.zoopla.com)
    /// and update the appropriate configuration file. e.g.
    /// 
    /// Simply add a reference and create an instance of the <c>Zoopla.Fluent.Api</c> class to start accessing the services. 
    ///
    /// Here are some examples showing just how easy it is to use:
    /// <example>
    /// <para>
    /// <code>    
    /// <![CDATA[
    /// //Setup your configuration file with your Zoopla Api key
    /// <appSettings>
    ///    <add key="ZooplaApiKey" value="your key here"/>
    /// </appSettings>
    /// 
    /// //Initalize the Api
    /// var Api = new ZooplaFluentApi(ConfigurationManager.AppSettings["ZooplaApiKey"]);
    /// 
    /// //Get a list of properties for sale in Cheltenham
    /// var listings = Api.Sales
    ///     .In(InOption.Area, "Cheltenham")
    ///     .Go();
    ///     
    /// //Get a paged list of properties
    /// int pagesize = 25;
    /// int count = Api
    ///     .Sales
    ///     .OfHouses
    ///     .In(InOption.Postcode, "GL52")
    ///     .MinimumBeds(4)
    ///     .MinimumPrice(250000)
    ///     .MaximumPrice(350000)
    ///     .PageSize(pagesize) //default is 10
    ///     .Count();
    ///
    /// for(int page = 1; ((page-1) * pagesize) < count; page++)
    /// {
    ///     var listings = Api.Go(page);
    /// }
    ///
    /// //Get a list of suggested locations for the search term "gloucester" from the sales or rental listings group
    /// var locations = Api.Suggestions("gloucester", SearchOption.SaleOrRentals);
    /// ]]>
    /// </code>
    /// </para>
    /// </example>
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    class NamespaceDoc
    {
    }
}
