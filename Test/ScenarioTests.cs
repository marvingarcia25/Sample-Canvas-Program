using System;
using Xunit;
using SimpleCanvasProgram.Models;
using SimpleCanvasProgram.Processes;
using SimpleCanvasProgram;

namespace SimpleCanvasProgramTests
{
    public class ScenarioTests
    {
        [Fact]
        public void TestScenario()
        {
            try
            {
                char[,] expectedResult = new char[6, 22] {  
                                                            {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-' },
                                                            {'|','o','o','o','o','o','o','o','o','o','o','o','o','o','X','X', 'X', 'X', 'X', 'o', 'o', '|' },
                                                            {'|','X','X','X','X','X','X','o','o','o','o','o','o','o','X','\0', '\0', '\0', 'X', 'o', 'o', '|' },
                                                            {'|','\0','\0','\0','\0','\0','X','o','o','o','o','o','o','o','X','X', 'X', 'X', 'X', 'o', 'o', '|' },
                                                            {'|','\0','\0','\0','\0','\0','X','o','o','o','o','o','o','o','o','o', 'o', 'o', 'o', 'o', 'o', '|' },
                                                            {'-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-','-' },
                };

                //This can be also came from a file
                string[] commands = new string[] {  "C 20 4",
                                                    "L 1 2 6 2",
                                                    "L 6 3 6 4" ,
                                                    "R 14 1 18 3",
                                                    "B 10 3 o",
                                                    "help"
                                                };
                Canvas canvas = null;

                foreach (string command in commands)
                {
                    canvas = CommandAnalyzer.Analyzer(command, canvas);
                }

                char[,] _createdCanvas = canvas.CanvasBody;
                for (int i = 0; i < canvas.Height; i++)
                {
                    for (int j = 0; j < canvas.Width; j++)
                    {
                        //Check if the expected result correct
                        Assert.True(_createdCanvas[i, j] == expectedResult[i, j]);
                    }
                }
            }
            catch (Exception e)
            {
                Assert.True(false);
            }
            
        }
    }
}
