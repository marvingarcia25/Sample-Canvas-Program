using System;
using Microsoft.Extensions.Configuration;
using SimpleCanvasProgram.Models;
using SimpleCanvasProgram.Processes;
using System.IO;


namespace SimpleCanvasProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Canvas canvas = null;
            String command = string.Empty;
            Console.WriteLine("***************************************************");
            Console.WriteLine("****************Simple Canvas App******************");
            Console.WriteLine("***************************************************");
            while (!command.ToUpper().Equals("Q"))
            {
                Console.WriteLine("Enter command:");
                command = Console.ReadLine();
                canvas = CommandAnalyzer.Analyzer(command, canvas);
            }
            Console.WriteLine("Shutting down");
        }
    }

}