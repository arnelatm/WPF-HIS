using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"d:\Projects\Picture.jpg"; //select source path

            ImageResizer resizer = new ImageResizer(307200, path, @"d:\Projects\result.jpg");
            resizer.ScaleImage();
        }
    }
}
