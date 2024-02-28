using System;
using System.Text;

namespace CP_Practice
{
    public class CP
    {
        public static void Main(string[] args)
        {
            //ReversedNum(1234);
            //SumOfNOddNum(3);
            //GetMaxProfit(new int[] { 2,321,3,213,319,301,1});
            RemoveAdjacentDuplicates("azxxxzy");
        }
        public static int ReversedNum(int num)
        {
            int reversedNum = 0;
            while(num>0)
            {
                reversedNum = reversedNum * 10 + num % 10;
                num = num / 10;
            }
            Console.WriteLine(reversedNum);
            return reversedNum;
        }

        public static int SumOfNOddNum(int num)
        {
            int sum = 0;
            for(int i = 1; i <= num; i += 2)
            {
                sum += i;
            }
            Console.WriteLine(sum);
            return sum;
        }
        public static int GetMaxProfit(int[] array)
        {
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }

            int difference = array[maxIndex] - array[minIndex];
            int indexOfDifference = Array.IndexOf(array, difference);
            if (indexOfDifference == -1)
                indexOfDifference = 0;
            Console.WriteLine(indexOfDifference);
            return indexOfDifference;
        }

        public static string removeUtil(string str, char last_removed)
        {
            // If length of string is 1 or 0
            if (str.Length == 0 || str.Length == 1)
                return str;

            // Remove leftmost same characters and recur for remaining string
            if (str[0] == str[1])
            {
                last_removed = str[0];
                while (str.Length > 1 && str[0] == str[1])
                {
                    str = str.Substring(1, str.Length - 1);
                }
                str = str.Substring(1, str.Length - 1);
                return removeUtil(str, last_removed);
            }

            // At this point, the first character is definitely different
            // from its adjacent. Ignore first character and recursively
            // remove characters from remaining string
            string rem_str = removeUtil(
                str.Substring(1, str.Length - 1), last_removed);

            // Check if the first character of the rem_string matches with
            // the first character of the original string
            if (rem_str.Length != 0 && rem_str[0] == str[0])
            {
                last_removed = str[0];

                // Remove first character
                return rem_str.Substring(1, rem_str.Length - 1);
            }

            // If remaining string becomes empty and last removed character
            // is same as first character of original string. This is needed
            // for a string like "acbbcddc"
            if (rem_str.Length == 0 && last_removed == str[0])
                return rem_str;

            // If the two first characters of str and rem_str don't match,
            // append first character of str before the first character of rem_str
            return (str[0] + rem_str);
        }

        public static string RemoveAdjacentDuplicates(string str)
        {
            char last_removed = '\0';
            Console.WriteLine(removeUtil(str, last_removed));
            return removeUtil(str, last_removed);
        }

    }
}
