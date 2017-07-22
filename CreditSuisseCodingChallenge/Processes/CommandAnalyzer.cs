using System;
using System.Collections.Generic;
using System.Text;
using CreditSuisseCodingChallenge.Models;

namespace CreditSuisseCodingChallenge.Processes
{
    public class CommandAnalyzer
    {
        public static Canvas Analyzer(string command, Canvas canvas)
        {
            char ch = command[0];
            String[] cmd;
            CoreProcesses process = new CoreProcesses();
            try
            {
                switch (ch)
                {
                    case 'C':
                        cmd = command.Split(' ');
                        canvas = process.CreateCanvas(
                                int.Parse(cmd[1]),
                                int.Parse(cmd[2])
                            );
                        process.Render(canvas);
                        break;
                    case 'L':
                        cmd = command.Split(' ');
                        if (canvas == null)
                        {
                            Console.WriteLine("Create a canvas first");
                            return canvas;
                        }
                        process.DrawLine(
                                    int.Parse(cmd[1]),
                                    int.Parse(cmd[2]),
                                    int.Parse(cmd[3]),
                                    int.Parse(cmd[4]),
                                    'X',
                                    canvas
                                );

                        process.Render(canvas);
                        break;
                    case 'R':
                        cmd = command.Split(' ');
                        if (canvas == null)
                        {
                            Console.WriteLine("Create a canvas first");
                            return canvas;
                        }
                        process.DrawRectangle(
                                    int.Parse(cmd[1]),
                                    int.Parse(cmd[2]),
                                    int.Parse(cmd[3]),
                                    int.Parse(cmd[4]),
                                    'X',
                                    canvas
                                );
                        process.Render(canvas);
                        break;
                    case 'B':
                        cmd = command.Split(' ');
                        if (canvas == null)
                        {
                            Console.WriteLine("Create a canvas first");
                            return canvas;
                        }
                        process.BucketFill(
                                   int.Parse(cmd[1]),
                                   int.Parse(cmd[2]),
                                   cmd[3][0],
                                   canvas
                               );
                        process.Render(canvas);
                        break;
                }
           
            }
            catch (IndexOutOfRangeException e)
            {
                //TODO: log here use exception stack
                Console.WriteLine("Invalid command. Try again!!\n");
                
            }
            catch (Exception e)
            {
                //TODO: log here
                Console.WriteLine(" Error Occured\n Please contact your system administrator. \n You may also refer to the documentation included in this software.");
            }

            return canvas;
        }
    }
}
