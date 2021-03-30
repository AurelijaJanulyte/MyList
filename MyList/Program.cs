using System;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            NewList<int> newList = new NewList<int>();
            int[] array = new int[10];
            newList.Add(1);
            newList.Add(2);
            newList.Add(3);
            newList.Add(4);
            newList.Add(5);
            newList.CopyTo(array,4);
            //newList.Insert(1,34);

            //new List<int>().FindIndex(x => x == 6);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
