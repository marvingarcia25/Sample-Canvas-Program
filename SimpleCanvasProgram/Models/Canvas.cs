using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCanvasProgram.Models
{
    public class Canvas
    {
        public int Width;
        public int Height;
        public char[,] CanvasBody = new char[0,0];

        public Canvas(int _width, int _height) {
            _width += 2;
            _height += 2;

            Width = _width;
            Height = _height;
            CanvasBody = new char[_height, _width ];
        }
    }
}
