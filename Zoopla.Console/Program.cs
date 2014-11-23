
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Example:
//  Extract a properties images to a specific folder
//                          <id>        <output>    <include images and/or floorpan>
//      Zoopla.Console -p ######## -o"C:\Downloads" --ei --ef
namespace Zoopla.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                System.Console.WriteLine("Property Id: {0}", options.PropertyId);

                if (string.IsNullOrEmpty(options.OutputLocation) == false)
                {
                    System.Console.WriteLine("Extract to: {0}", options.OutputLocation);
                    System.Console.WriteLine("Extract Images: {0}", options.ExtractImages);
                    System.Console.WriteLine("Extract Floorplan: {0}", options.ExtractFloorplan);

                    try
                    {
                        new Process(options).Go();
                    }
                    catch(Exception e)
                    {
                        System.Console.WriteLine(string.Format("Error: {0}", e.Message));
                    }
                }
                else
                {
                    System.Console.WriteLine("Nothing to do!");
                }
            }
            else
            {
                options.GetUsage();
            }

            System.Console.WriteLine("Press <RETURN> to exit");
            System.Console.ReadKey();
        }
    }

}
