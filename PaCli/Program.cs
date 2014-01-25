using System;
using PrisonArchitect;
using PrisonArchitect.Parser;

namespace PaCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser("D:/Dropbox/games/Prison Architect/saves/grantededit.prison");
            var readLine = Console.ReadLine();
        }
    }
}
