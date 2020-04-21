using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearEquation eq = new LinearEquation(4, -4, 1);
            LinearEquation eq2 = new LinearEquation(-2, 7, 1);
            Console.WriteLine(eq2.IntersectionPoints(eq)[0]);
            Console.WriteLine(eq2.IntersectionPoints(eq)[1]);
            Console.WriteLine(eq2.IsBelongs(4, 1));
        }
    }
    class LinearEquation
    {
        private double a_;
        private double b_;
        private double c_;
        public double a
        {
            get { return a_; }
            set
            {
                if (this.b_ == 0 && value == 0) throw new ArgumentException("A and B cannot equal 0 at the same time!");
                else a_ = value;
            }
        }
        public double b
        {
            get { return b_; }
            set
            {
                if (this.a_ == 0 && value == 0) throw new ArgumentException("A and B cannot equal 0 at the same time!");
                else b_ = value;
            }
        }
        public double c
        {
            get { return c_; }
            set
            {
                c_ = value;
            }
        }
        public double this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return a_;
                    case 1:
                        return b_;
                    case 2:
                        return c_;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        a_ = value;
                        break;
                    case 1:
                        b_ = value;
                        break;
                    case 2:
                        c_ = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        public LinearEquation()
        {
            a = 1;
            b = 2;
            c = 3;
        }
        public LinearEquation(double a1, double b1, double c1)
        {
            a = a1;
            b = b1;
            c = c1;
        }
        public void ToString()
        {
            Console.WriteLine("A = " + a);
            Console.WriteLine("B = " + b);
            Console.WriteLine("C = " + c);
        }
        public double[] IntersectionPoints(LinearEquation line)
        {
            double delta = a * line[1] - line[0] * b;
            if (delta == 0)
            {
                throw new ArgumentException("Lines are parallel!");
            }
            double x = (line[1] * c - b * line[2]) / delta;
            double y = (a * line[2] - line[0] * c) / delta;
            double[] result = new double[2] { -x, -y };
            return result;
        }
        public Boolean IsBelongs(double x, double y)
        {
            if (this.a * x + this.b * y + this.c == 0) return true;
            else return false;
        }
    }
}
