using System;
using System.IO;
using PrisonArchitect;
using CommandLine;


namespace PaCli
{

    class Options
    {
        [Option('o', "out", Required = true, HelpText = "Path to save generated Prison")]
        public string OutFile { get; set; }

        [Option('w', "width", DefaultValue = 100, HelpText = "Width of prison - default 100")]
        public int Width { get; set; }
        
        [Option('h', "height", DefaultValue = 80, HelpText = "Height of prison - default 80")]
        public int Height { get; set; }
    }

    class Program
    {
        static void Main(string[] args) {
            
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
            {
                var w = (short) options.Width;
                var h = (short) options.Height;

                var p = new Prison(w, h);
                p.Generate();
                if (File.Exists(options.OutFile))
                {
                    Console.WriteLine("Careful, that file already exists. Are you sure you want to overwrite it? y/N");
                    if (Console.ReadLine().ToLower().Trim() != "y")
                    {
                        Console.WriteLine("Bailing out, you didn't answer correctly");
                        return;
                    }
                }
                var output = new PrisonArchitect.SaveFile.Output(p, options.OutFile);
                Console.WriteLine("Done! Wrote file to " + options.OutFile);
            }
            else
            {
                Console.WriteLine("Something's wrong there!");
                return;
            }
        }
    }
}
