using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Trilogic.Common.Settings;

namespace TestSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready...set...go?");
            Console.ReadKey();
            ArgSettings settings = ArgSettings.ParseSettings(args);
            Console.WriteLine("done");
        }
    }
}
