using System;
using PrisonArchitect;


namespace PaCli
{
    class Program
    {
        static void Main(string[] args)
        {
            //var parser = new Parser("D:/Dropbox/games/Prison Architect/saves/grantededit.prison");
            var p = new Prison(100,80);
            p.Generate();
            var output = new PrisonArchitect.SaveFile.Output(p, "D:/Dropbox/games/Prison Architect/saves/paeditor.prison");
            var readLine = Console.ReadLine();
        }
    }
}
