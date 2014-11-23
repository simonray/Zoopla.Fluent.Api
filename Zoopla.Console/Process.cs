using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoopla.Fluent.Api;
using Zoopla.Fluent.Api.Extensions;

namespace Zoopla.Console
{
    public class Process
    {
        Options Opts { get; set; }

        public Process(Options options)
        {
            Opts = options;
        }

        public void Go()
        {
            using (ZooplaFluentApi api = new ZooplaFluentApi(ConfigurationManager.AppSettings["ZooplaApiKey"]))
            {
                var listing = api.Specific(new int[] { Opts.PropertyId })
                    .IncludeImages
                    .IncludeSold
                    .Go()
                    .FirstOrDefault();

                if (listing == null)
                {
                    throw new InvalidOperationException("No proprety could be found with the specified id");
                }

                if (Opts.ExtractFloorplan && listing.FloorPlanUrls.Count > 0)
                    listing.ImageUrls.AddRange(listing.FloorPlanUrls);

                var client = new GZipWebClient();
                foreach (var imageUrl in listing.ImageUrls)
                {
                    string fn = System.IO.Path.GetFileName(imageUrl.ToString());
                    string fullpath = System.IO.Path.Combine(
                        Opts.OutputLocation,
                        GenerateFileName(Opts.PropertyId, ".jpg")
                        );
                    System.Console.WriteLine("Downloading image: {0}", fn);
                    client.DownloadFile(imageUrl, fullpath);
                }
            }
        }

        private static string GenerateFileName(int listingId, string ext)
        {
            return listingId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString() + ext;
        }
    }
}
