using System;
using Microsoft.Extensions.Configuration;
using SimpleCanvasProgram.Models;
using SimpleCanvasProgram.Processes;
using System.IO;


namespace SimpleCanvasProgram
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
         

            Canvas canvas = null;
            String command = string.Empty;
            
            while (!command.ToUpper().Equals("Q"))
            {
                Console.WriteLine("enter command:");
                command = Console.ReadLine();
                canvas = CommandAnalyzer.Analyzer(command, canvas);
            }
            Console.WriteLine("Shutting down");
        }
    }

}