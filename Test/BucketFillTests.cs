using System;
using Xunit;
using CreditSuisseCodingChallenge.Models;
using CreditSuisseCodingChallenge.Processes;

namespace CreditSuisseCodingChallengeTests
{
    public class BucketFillTests
    {
        [Theory]
        [InlineData(10,3, 'o')]
        [InlineData(20, 4, 'o')]
        public void TestValidBucketFill(int x, int y, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            CoreProcesses process = new CoreProcesses();
            Canvas createdCanvas = process.CreateCanvas(width, height);

            createdCanvas = process.BucketFill(x,y,mchar,createdCanvas);

            Assert.NotNull(createdCanvas);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                { 
                    Assert.True(createdCanvas.CanvasBody[i,j] != ' ');
                }
            }
        }

        [Theory]
        [InlineData(40, 3, 'o')]
        [InlineData(5, 56, 'o')]
        [InlineData(-1, 3, 'o')]
        [InlineData(5, -3, 'o')]
        public void TestInvalidBucketFillDueToSize(int x, int y, char mchar)
        {
            //create valid canvas
            int width = 20;
            int height = 4;

            Canvas canvasToTest = null;
            CoreProcesses process = new CoreProcesses();

            Canvas createdCanvas = process.CreateCanvas(width, height);

            //Test Scenario: x & y axis is greater than canvas size and some negative value  
            if (x > width || y > height )
            {
                Exception ex = Assert.Throws<IndexOutOfRangeException>(
                       () => canvasToTest = process.BucketFill(x, y, mchar, createdCanvas)
                   );

            }
        }
    }
}
