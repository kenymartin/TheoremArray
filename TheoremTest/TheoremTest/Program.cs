using System;
using System.Collections.Generic;
using System.Linq;

namespace TheoremTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //// [[1,2,[3]],4] -> [1,2,3,4]          

            object[] values = { 1, 2, new object[] { 3 }, 4  };
            object[] values2 = { new object[] { 1 }, new object[] { 2 }, new object[] { 3 }, new object[] { 4 },5,7,6 };

            var result = FlattenArray(values2, new List<int>());

        }

        public static int[] FlattenArray(object[] NotFlattenArray, List<int> temList)
        {
            for (int i = 0; i < NotFlattenArray.Length; i++)
            {
                if (NotFlattenArray[i].GetType() == typeof(object[]))
                    FlattenArray((object[])NotFlattenArray[i], temList);
                else if (NotFlattenArray[i].GetType() == typeof(int))
                    temList.Add((int)NotFlattenArray[i]);
                else
                    throw new ArgumentException("Only int or arrays as arguments are allowed");
            }
            return temList.OrderBy(o=> o).ToArray();

        }
    }
}
