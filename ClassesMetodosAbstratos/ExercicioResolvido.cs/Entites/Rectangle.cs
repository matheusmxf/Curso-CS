using System;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Rectangle : Shape
    {
        public double Widht { get; set; }
        public double Height { get; set; }
        
        public Rectangle(double widht, double height, Color color) : base(color)
        {
            Widht = widht;
            Height = height;
        }

        public override double Area()
        {
            return Widht * Height;
        }

        
    }
}