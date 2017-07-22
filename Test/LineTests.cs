using System;
using Xunit;
using SimpleCanvasProgram.Models;
using SimpleCanvasProgram.Processes;

namespace SimpleCanvasProgramTests
{
    public class LineTests
    {
        [Theory]
        [InlineData(1, 2, 6 ,2, 'X')]
        [InlineData(6, 3, 6, 4, 'X')]
        [InlineData(6, 3, 6, 4, 'T')]
        public void TestDrawValidLine(int x1, int y1, int x2, int y2, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            Canvas canvasToTest = null;
            char foundLiteral = ' ';
            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);

            canvasToTest = process.DrawLine(x1,y1,x2,y2,mchar,createdCanvas);

            for (int i = y1; i <= y2; i++)
            {
                for (int j = x1; j <= x2; j++)
                {
                    foundLiteral = canvasToTest.CanvasBody[i, j];
                    Assert.True(foundLiteral == mchar);
                }
            }

        }

        [Theory]
        [InlineData(1,2,6,25,'X')]
        public void TestDrawFailedLineDueToSize(int x1, int y1, int x2, int y2, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            Canvas canvasToTest = null;
            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);

            //Test Scenario: x & y axis is greater than canvas size and some negative value  
            if (x1 > width || x2 > width || y1 > height || y2 > height)
            {
                Exception ex = Assert.Throws<IndexOutOfRangeException>(
                       () => canvasToTest = process.DrawLine(x1, y1, x2, y2, mchar, createdCanvas)
                   );
                
            }
        }

        [Theory]
        [InlineData(1, 2, 6, 2, 'X')]
        public void TestInvalidCharInCanvas(int x1, int y1, int x2, int y2, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            char foundLiteral = ' ';
            char invalidmchar = 'Y';
            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);

            createdCanvas = process.DrawLine(x1, y1, x2, y2, mchar, createdCanvas);

            //Test incorrect character used to write line
            for (int i = y1; i <= y2; i++)
            {
                for (int j = x1; j <= x2; j++)
                {
                    foundLiteral = createdCanvas.CanvasBody[i, j];
                    Assert.False(foundLiteral == invalidmchar);
                }
            }

        }

    }
}
