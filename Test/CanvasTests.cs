using System;
using Xunit;
using SimpleCanvasProgram.Models;
using SimpleCanvasProgram.Processes;

namespace SimpleCanvasProgramTests
{
    public class CanvasTests
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(10, 20)]
        [InlineData(50, 50)]
        public void TestCreationOfValidCanvas(int width, int height)
        {
            CoreProcesses process = new CoreProcesses();
            Canvas createdCanvas = process.CreateCanvas(width, height);
            Assert.NotNull(createdCanvas);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(-1, -10)]
        [InlineData(1, -10)]
        [InlineData(200, 50)]
        public void TestCreationOfInvalidCanvas(int width, int height)
        {
            CoreProcesses process = new CoreProcesses();
            
            Exception ex = Assert.Throws<Exception>(
                    () => process.CreateCanvas(width, height)
                );
            if(width > 77)
                Assert.Equal("MaxWidthExceededException", ex.Message);
            else
                Assert.Equal("InvalidCanvasWidthAndHeightException", ex.Message);

        }
    }
}
