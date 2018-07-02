using System;
namespace ExecViewTask
{
    public class Height
    {
        public int Foot { get; set; }
        public int Inches { get; set; }

        public Height(int foot, int inches)
        {
            Foot = foot;
            Inches = inches;
        }

        public Height(string height)
        {
            char[] split = { 'f', 't', ' ', 'i', 'n' };
            string[] Height = height.Split(split, StringSplitOptions.RemoveEmptyEntries);
            Foot = int.Parse(Height[0]);
            Inches = int.Parse(Height[1]);
        }

        public override string ToString()
        {
            return Foot + " ft " + Inches + " in";
        }

        public double GetHeightInCentimeters()
        {
            return (Foot * 12 + Inches) * 2.54;
        }
    }
}
