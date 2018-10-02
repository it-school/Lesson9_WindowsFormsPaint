using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsPaint
{
    class Paint
    {
        uint thickness;
        bool isDrawing;
        Color foregroundColor;
        Color backgroundColor;
        Pen pen;
        uint type;
        bool isFirstLinePoint;
        bool isFirstDrawPoint;

        public Paint()
        {
            Thickness = 1;
            IsDrawing = false;
            ForegroundColor = Color.Black;
            BackgroundColor = Color.Black;
            Pen = new Pen(ForegroundColor, 1);
            type = 1;
            isFirstLinePoint = true;
            IsFirstDrawPoint = true;
        }

        public bool IsDrawing { get => isDrawing; set => isDrawing = value; }
        public uint Thickness { get => thickness; set => thickness = value; }
        public Color ForegroundColor { get => foregroundColor; set => foregroundColor = value; }
        public Pen Pen { get => pen; set => pen = value; }
        public Color BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public uint Type { get => type; set => type = value; }
        public bool IsFirstLinePoint { get => isFirstLinePoint; set => isFirstLinePoint = value; }
        public bool IsFirstDrawPoint { get => isFirstDrawPoint; set => isFirstDrawPoint = value; }
    }
}
