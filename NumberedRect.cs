using System.Drawing;
using System.Runtime.InteropServices;

namespace _2048
{
    class NumberedRect
    {
        public int value;
        public Color clr;
        public int w, h;
        public int RowIndex, ColumnIndex;
        public NumberedRect(int val,int width,int heigth,int r,int c,Color color)
        {
            value = val;
            clr = color;
            w = width;
            h = heigth;
            RowIndex = r;
            ColumnIndex = c;
        }
    }
}
