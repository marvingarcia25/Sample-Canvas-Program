using System;
using System.Collections.Generic;
using System.Text;
using SimpleCanvasProgram.Models;

namespace SimpleCanvasProgram.Processes
{
    public class CommandAnalyzer
    {
        public static Canvas Analyzer(string command, Canvas canvas)
        {
            
            
            CoreProcesses process = new CoreProcesses();
            try
            {
                String[] cmd = command.Split(' ');
                string ch = cmd[0];// GET the first command

                switch (ch)
                {
                    case "C":
                        canvas = process.CreateCanvas(
                                int.Parse(cmd[1]),
                                int.Parse(cmd[2])
                            );
                        process.Render(canvas);
                        break;
                    case "L":

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
                    case "R":

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
                    case "B":

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
                    case "help":

                        Console.WriteLine("Below are the following Commands available:");
                        Console.WriteLine("- C - create a canvas");
                        Console.WriteLine("     SYNTAX:    C Width Height");
                        Console.WriteLine("     Description:    This will create a canvas with the following Width and");
                        Console.WriteLine("                     Height");
                        Console.WriteLine("     Example:   C 20 4 - will create a canvas with width = 20 and height = 4.");
                        Console.WriteLine();

                        Console.WriteLine("- L - draw a line");
                        Console.WriteLine("     SYNTAX:    L x1 y1 x2 y2");
                        Console.WriteLine("     Description    This will draw a line from axis(x1, y1) to axis(x2, y2).");
                        Console.WriteLine("     Example:   L 1 2 6 2 - will create a line from axis(1, 2) to axis(6, 2).");
                        Console.WriteLine();

                        Console.WriteLine("- R - draw a rectangle");
                        Console.WriteLine("     SYNTAX:    R x1 y1 x2 y2");
                        Console.WriteLine("     Description    This will draw a rectangle with the upper left corner");
                        Console.WriteLine("                     = axis(x1, y1) and lower right corner = axis(x2, y2)");
                        Console.WriteLine("     Example:   R 14 1 18 3 -will create a rectangle with the upper left corner");
                        Console.WriteLine("                     = axis(14, 1) and lower right corner = axis(18, 3)");
                        Console.WriteLine();

                        Console.WriteLine("- B - bucketfill, just like ms paint bucketfill functionality");
                        Console.WriteLine("     SYNTAX:    B x y");
                        Console.WriteLine("     Description    This will fill to all the surroundings of x,y=axis(x,y)");
                        Console.WriteLine("                    with charToUse just like in paint programs.charToUse can be");
                        Console.WriteLine("                     any single alpha numeric character.");
                        Console.WriteLine("     Example:   B 10 3 o - will do a bucketfill to all the surroundings ");
                        Console.WriteLine("                     of axis(10, 3) with 'o' just like in paint programs.");
                        Console.WriteLine();

                        Console.WriteLine("- Q - quit the program");
                        Console.WriteLine("     SYNTAX:    Q");
                        Console.WriteLine("     Description    This will quit the program and remove everything ");
                        Console.WriteLine("                     that is stored in the memory.");
                        Console.WriteLine("     Example:   Q");
                        break;
                    default:
                        Console.WriteLine("Invalid command. Try again!!\n You may also use the help command.");
                        break;
                }
           
            }
            catch (IndexOutOfRangeException e)
            {
                //TODO: log here use exception stack
                Console.WriteLine("Invalid command. Try again!!\n You may also use the help command.");
                
            }
            catch (Exception e)
            {
                //TODO: log here
                Console.WriteLine(" Error Occured\n Please contact your system administrator. \n You may also use the help command.");
            }

            return canvas;
        }
    }
}
