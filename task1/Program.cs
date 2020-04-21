using System;
using System.Collections.Generic;


namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TSet ex = new TSet(3, 44, 2, 9);
            ex.AddNew(4);
            Console.WriteLine("Максимальний: " + ex.MaxElem());
            Console.WriteLine("Сума: " + ex.GetSum());
            ex.Output();
        }
    }
    class TSet
    {
        public HashSet<int> mainSet = new HashSet<int>();
        public TSet()
        {
            this.mainSet.Add(1);
            this.mainSet.Add(2);
            this.mainSet.Add(3);
        }
        public TSet(params int[] nums)
        {
            foreach (int i in nums)
            {
                this.mainSet.Add(i);
            }
        }
        public void AddNew(int newElem)
        {
            this.mainSet.Add(newElem);
        }
        public void Output()
        {
            foreach (int i in this.mainSet)
                Console.Write(i + " ");
        }
        public int MaxElem()
        {
            int result = 0;
            foreach (int i in this.mainSet)
            {
                result = i;
                break;
            }
            foreach (int item in this.mainSet)
            {
                if (result < item) result = item;
            }
            return result;
        }
        public int GetSum()
        {
            int result = 0;
            foreach (int i in this.mainSet) result += i;
            return result;
        }
    }
}