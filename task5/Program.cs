using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] ex = new double[4] { 2, -6, 4, 9 };
            TArray a = new TArray(4, ex);
            a.LowestGreatestValues();
            a.Sorting();
            Console.WriteLine(a.arraySum());
            a.Output();
            (a + 3).Output();
            (a - 2).Output();
            (a * 5).Output();

            double[] asd = new double[4] { 4, 5, 6, 7 };

            TOderedArray aa = new TOderedArray(4, asd);
            double[] bb = new double[3] { 4, 6, 9 };
            (aa - bb).Output();
        }

    }
    public class TArray
    {
        public int elemsQuantity;
        public double[] array;

        public TArray()
        {
            this.elemsQuantity = 4;
            this.array = new double[4] { 2, 4, 7, 8 };
        }
        public TArray(int elemsCount, double[] mainArray)
        {
            this.elemsQuantity = elemsCount;
            this.array = mainArray;
        }
        public TArray(TArray a)
        {
            this.elemsQuantity = a.elemsQuantity;
            this.array = a.array;
        }

        public void Output()
        {
            Console.WriteLine("Elements' quantity - " + this.elemsQuantity);
            Console.WriteLine("Array - " + "[" + string.Join(", ", this.array) + "]");
        }
        public void LowestGreatestValues()
        {
            Array.Sort(this.array);
            Console.WriteLine("Greatest - " + this.array[array.Length - 1]);
            Console.WriteLine("Lowest - " + this.array[0]);
        }
        public double[] Sorting()
        {
            Array.Sort(this.array);
            return this.array;
        }
        public double arraySum()
        {
            double sum = 0;
            foreach (double i in this.array)
            {
                sum += i;
            }
            return sum;
        }
        public static TArray operator +(TArray arr, double num)
        {
            int i = 0;
            double[] newArr = new double[arr.elemsQuantity];
            while (i < arr.elemsQuantity)
            {
                newArr[i] = arr.array[i] + num;
                i++;
            }
            return new TArray(arr.elemsQuantity, newArr);
        }
        public static TArray operator -(TArray arr, double num)
        {
            int i = 0;
            double[] newArr = new double[arr.elemsQuantity];
            while (i < arr.elemsQuantity)
            {
                newArr[i] = arr.array[i] - num;
                i++;
            }
            return new TArray(arr.elemsQuantity, newArr);
        }
        public static TArray operator *(TArray arr, double num)
        {
            int i = 0;
            double[] newArr = new double[arr.elemsQuantity];
            while (i < arr.elemsQuantity)
            {
                newArr[i] = arr.array[i] * num;
                i++;
            }
            return new TArray(arr.elemsQuantity, newArr);
        }
    }
    public class TOderedArray : TArray
    {

        public TOderedArray()
        {
            this.elemsQuantity = 4;
            this.array = new double[4] { 2, 4, 7, 8 };
        }
        public TOderedArray(int elemsCount, double[] mainArray)
        {
            this.elemsQuantity = elemsCount;
            this.array = mainArray;
        }
        public TOderedArray(TArray a)
        {
            this.elemsQuantity = a.elemsQuantity;
            this.array = a.array;
        }
        public TOderedArray(int num)
        {
            this.elemsQuantity = num;
            this.array = new double[num];
            for (int i = 0; i < num; i++)
            {
                this.array[i] = 0;
            }
        }

        public static TOderedArray operator +(TOderedArray arr, double[] nums)
        {
            int newLen = arr.elemsQuantity + nums.Length;
            TOderedArray newArr = new TOderedArray(newLen);
            for (int i = 0; i < arr.elemsQuantity; i++)
            {
                newArr.array[i] = arr.array[i];
            }
            for (int i = arr.elemsQuantity; i < newLen; i++)
            {
                newArr.array[i] = nums[i - arr.elemsQuantity];
            }

            return newArr;
        }
        public static TOderedArray operator -(TOderedArray arr, double[] nums)
        {
            bool Contains(double[] array, double value)
            {
                if (array == null) return false;

                for (int j = 0; j < array.Length; j++)
                    if (array[j] == value) return true;
                return false;
            }
            int newLen = arr.elemsQuantity;
            for (int i = 0; i < arr.elemsQuantity; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (arr.array[i] == nums[j]) newLen--;
                }
            }
            TOderedArray result = new TOderedArray(newLen);
            int index = 0;
            for (int i = 0; i < arr.elemsQuantity; i++)
            {
                if (!Contains(nums, arr.array[i]))
                {
                    result.array[index] = arr.array[i];
                    index++;
                }
            }
            return result;
        }
    }
}