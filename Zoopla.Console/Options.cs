using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoopla.Console
{
    public class Options
    {
        [Option('p', "propertyid", Required = true, HelpText = "This is the property id specified on the url")]
        public int PropertyId { get; set; }

            [Option('o', "output", MutuallyExclusiveSet = "extract", HelpText = "Folder where the extracts will be downloaded to")]
            public string OutputLocation { get; set; }

                [Option("ef", MutuallyExclusiveSet = "extract", HelpText = "Extract the floorplan image")]
                public bool ExtractFloorplan { get; set; }

                [Option("ei", MutuallyExclusiveSet = "extract", HelpText = "Extract the property images")]
                public bool ExtractImages { get; set; }

        [CommandLine.HelpOption]
        public string GetUsage()
        {
            return CommandLine.Text.HelpText.AutoBuild(this,
              (CommandLine.Text.HelpText current) => CommandLine.Text.HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }

}
