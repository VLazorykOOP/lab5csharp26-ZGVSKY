using System;

namespace Lab5
{
    public class Task4
    {
        public static void Execute()
        {
            Trapeze t = new Trapeze(5, 10, 4);
            t.ShowTrapeze();
        }
    }

    public sealed partial class Trapeze
    {
        private int a;
        private int b;
        private int h;

        public Trapeze(int a, int b, int h)
        {
            this.a = a;
            this.b = b;
            this.h = h;
        }

        public partial void ShowTrapeze();
    }
}