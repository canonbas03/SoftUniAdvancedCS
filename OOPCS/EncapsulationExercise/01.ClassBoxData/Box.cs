using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ClassBoxData
{
    public class Box
    {
        private const string ErrorMessage = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ErrorMessage, nameof(Length)));
                length = value;
            }
        }
        public double Width
        {
            get => width;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ErrorMessage, nameof(Width)));
                width = value;
            }
        }
        public double Height
        {
            get => height;

            private set
            {
                if (value <= 0)
                    throw new ArgumentException(string.Format(ErrorMessage, nameof(Height)));

                height = value;
            }
        }

        public double SurfaceArea()
        {
            // Surface Area = 2lw + 2lh + 2wh
            double result = 2 * length * width + 2 * length * height + 2 * width * height;
            return result;
        }

        public double LateralSurfaceArea()
        {
            // Lateral Surface Area = 2lh + 2wh
            double result = 2 * length * height + 2 * width * height;
            return result;
        }

        public double Volume()
        {
            double result = length * width * height;
            return result;
        }
    }
}
