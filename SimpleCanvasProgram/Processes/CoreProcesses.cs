using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SimpleCanvasProgram.Models;
using Microsoft.Extensions.Configuration;

namespace SimpleCanvasProgram.Processes
{
    public class CoreProcesses
    {
        public void Render(Canvas createdCanvas)
        {
            char[,] _createdCanvas = createdCanvas.CanvasBody;
            for (int i = 0; i < createdCanvas.Height; i++)
            {
                for (int j = 0; j < createdCanvas.Width; j++)
                {
                    Console.Write(_createdCanvas[i, j]);
                }
                Console.WriteLine();
            }
        }

        public Canvas CreateCanvas(int width, int height)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("app-settings.json", false)
             .Build();

            if (width < 0 || height < 0)
            {
                Console.WriteLine("InvalidCanvasWidthAndHeightException");
                throw new Exception("InvalidCanvasWidthAndHeightException");
            }

            if (width > int.Parse( configuration["Configuration:CanvasWidthMaxLength"]))
            {
                Console.WriteLine(" CanvasWidthMaxLength exceedeed. Maximum is " + configuration["Configuration:CanvasWidthMaxLength"]);
                throw new Exception("MaxWidthExceededException");
            }

            Canvas createdCanvas = new Canvas(width, height);
            width += 2;
            height += 2;
            createdCanvas = DrawLine(0, 0, width - 1, 0, '-', createdCanvas);
            createdCanvas = DrawLine(0, height - 1, width - 1, height - 1, '-', createdCanvas);
            createdCanvas = DrawLine(0, 1, 0, height - 2, '|', createdCanvas);
            createdCanvas = DrawLine(width - 1, 1, width - 1, height - 2, '|', createdCanvas);
            return createdCanvas;
        }


        public Canvas DrawLine(int x1, int y1, int x2, int y2, char mchar, Canvas createdCanvas)
        {
            if (x1 > createdCanvas.Width || x2 > createdCanvas.Width || y1 > createdCanvas.Height || y2 > createdCanvas.Height ||
                x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0)
            {
                Console.WriteLine("InvalidLinePointsException");
                throw new IndexOutOfRangeException("InvalidLinePointsException");
            }
            for (int i = y1; i <= y2; i++)
            {
                for (int j = x1; j <= x2; j++)
                {
                    createdCanvas.CanvasBody[i,j] = mchar;
                }
            }
            return createdCanvas;
        }

        public Canvas DrawRectangle(int x1, int y1, int x2, int y2, char mchar, Canvas createdCanvas)
        {
            if (x1 > createdCanvas.Width || x2 > createdCanvas.Width || y1 > createdCanvas.Height || y2 > createdCanvas.Height ||
                 x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0)
            {
                Console.WriteLine("InvalidLineRectanglePointsException");
                throw new IndexOutOfRangeException("InvalidLineRectanglePointsException");
            }
            createdCanvas = DrawLine(x1, y1, x2, y1, mchar, createdCanvas);
            createdCanvas = DrawLine(x1, y1, x1, y2, mchar, createdCanvas);
            createdCanvas = DrawLine(x2, y1, x2, y2, mchar, createdCanvas);
            createdCanvas = DrawLine(x1, y2, x2, y2, mchar, createdCanvas);

            return createdCanvas;
        }

        public Canvas BucketFillUtil(int x, int y, char oldchar, char mchar,  Canvas createdCanvas)
        {

            if (createdCanvas.CanvasBody[y,x] != oldchar) {
        			return createdCanvas;
        		}

        		if(x > 0 || x< createdCanvas.Height || y> 0 || y< createdCanvas.Width)
                {
        			if(createdCanvas.CanvasBody[y, x] == oldchar)
                        createdCanvas.CanvasBody[y, x] = mchar;

                    createdCanvas = BucketFillUtil(x+1, y, oldchar, mchar, createdCanvas);

                    createdCanvas = BucketFillUtil(x-1, y, oldchar, mchar, createdCanvas);

                    createdCanvas = BucketFillUtil(x, y-1, oldchar, mchar, createdCanvas);

                    createdCanvas = BucketFillUtil(x, y+1, oldchar, mchar, createdCanvas);

                
                }
            return createdCanvas;
        }

        public Canvas BucketFill(int x, int y, char mchar, Canvas createdCanvas)
        {
            if (x > createdCanvas.Width || y > createdCanvas.Height || x <= 0 || y <= 0)
            {
                Console.WriteLine("InvalidPointsException");
                throw new IndexOutOfRangeException("InvalidPointsException");
            }
            char oldChar = createdCanvas.CanvasBody[y, x];
            BucketFillUtil(x, y, oldChar, mchar, createdCanvas);

            return createdCanvas;
        }

    }
}
