using System;
using Xunit;
using SimpleCanvasProgram.Models;
using SimpleCanvasProgram.Processes;

namespace SimpleCanvasProgramTests
{
    public class RectangleTests
    {
        [Theory]
        [InlineData(14, 1, 18, 3,'X')]
        [InlineData(1, 1, 20, 4, 'X')]
        public void TestCreationOfValidRectangle(int x1, int y1, int x2, int y2, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);
            Canvas testCanvas = process.CreateCanvas(width, height); 

            createdCanvas = process.DrawRectangle(x1, y1, x2, y2,  mchar, createdCanvas);

            testCanvas = process.DrawLine(x1, y1, x2, y1, mchar, testCanvas);
            testCanvas = process.DrawLine(x1, y1, x1, y2, mchar, testCanvas);
            testCanvas = process.DrawLine(x2, y1, x2, y2, mchar, testCanvas);
            testCanvas = process.DrawLine(x1, y2, x2, y2, mchar, testCanvas);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Assert.True(createdCanvas.CanvasBody[i,j] == testCanvas.CanvasBody[i,j]);
                }
            }
        }

        [Theory]
        [InlineData(14, 1, 18, 3, 'X')]
        [InlineData(1, 1, 20, 3, 'X')]
        public void TestCreationOfInvalidRectangle(int x1, int y1, int x2, int y2, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;
            char invalidmchar = 'Y';

            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);

            createdCanvas = process.DrawRectangle(x1, y1, x2, y2, mchar, createdCanvas);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Assert.False(createdCanvas.CanvasBody[i, j] == invalidmchar);
                }
            }
        }

        [Theory]
        [InlineData(14, 1, 18, -13, 'X')]
        [InlineData(1, 1, 28, 4, 'X')]
        public void TestCreationOfInvalidRectangleDueToSize(int x1, int y1, int x2, int y2, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);
            
            //Test Scenario: x & y axis is greater than canvas size and some negative value  
            if (x1 > width || x2 > width || y1 > height || y2 > height)
            {
                Exception ex = Assert.Throws<IndexOutOfRangeException>(
                       () => createdCanvas = process.DrawRectangle(x1, y1, x2, y2, mchar, createdCanvas)
                   );
                return;
            }

        }
    }
}
