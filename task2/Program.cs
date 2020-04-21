using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] ex = new double[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { -2, 4, -7 } };
            double[,] ex2 = new double[3, 3] { { 2, 3, 4 }, { 4, 5, 6 }, { -2, 4, -7 } };
            TSMatrix a = new TSMatrix(3, ex);
            TSMatrix b = new TSMatrix(3, ex2);
            TSMatrix c = new TSMatrix(4);
            a.LowerGreaterValues();
            b.GetSum();
            (b + a).Output();
        }
    }
}
class TSMatrix
{
    public int size;
    public double[,] matrix;
    public TSMatrix()
    {
        this.size = 3;
        this.matrix = new double[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == j) this.matrix[i, j] = 1;
                else this.matrix[i, j] = 0;
            }
        }
    }
    public TSMatrix(int size)
    {
        this.size = size;
        Random rnd = new Random();
        this.matrix = new double[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == j) this.matrix[i, j] = 1;
                else this.matrix[i, j] = rnd.Next(0, 10);
            }
        }
    }
    public TSMatrix(int size, double[,] matrix)
    {
        this.size = size;
        this.matrix = matrix;
    }
    public TSMatrix(TSMatrix a)
    {
        this.size = a.size;
        this.matrix = a.matrix;
    }
    public void Output()
    {
        for (int i = 0; i < this.size; i++)
        {
            for (int j = 0; j < this.size; j++)
            {
                Console.Write(this.matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void LowerGreaterValues()
    {
        double maxV = this.matrix[0, 0];
        double minV = this.matrix[0, 0];
        for (int i = 0; i < this.size; i++)
        {
            for (int j = 0; j < this.size; j++)
            {
                if (this.matrix[i, j] > maxV) maxV = this.matrix[i, j];
                if (this.matrix[i, j] < minV) minV = this.matrix[i, j];
            }
        }
        Console.WriteLine("Greater: " + maxV);
        Console.WriteLine("Lower: " + minV);
    }
    public void GetSum()
    {
        double sum = 0;
        for (int i = 0; i < this.size; i++)
        {
            for (int j = 0; j < this.size; j++)
            {
                sum += this.matrix[i, j];
            }
        }
        Console.WriteLine("Sum: " + sum);
    }
    public static TSMatrix operator +(TSMatrix a, TSMatrix b)
    {
        int len = a.size;
        if (len == b.size)
        {
            TSMatrix res = new TSMatrix(len);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    res.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
            return res;
        }
        else
        {
            throw new System.ArgumentException("Sizes arne't same!");
        }
    }
    public static TSMatrix operator -(TSMatrix a, TSMatrix b)
    {
        int len = a.size;
        if (len == b.size)
        {
            TSMatrix res = new TSMatrix(len);
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    res.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return res;
        }
        else
        {
            throw new System.ArgumentException("Sizes aren't same!");
        }
    }
}

