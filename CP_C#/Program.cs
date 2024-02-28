using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace competitiveProgramming
{
    public class cpQuestions
    {
        static void Main(string[] args)
        {

            RemoveAdjacentDuplicates("azxxxzy");
            /*var sumOfNos = 0;
            for(int i = 1; i <= 20; i++)
            {
                if (i % 3 == 0)
                {
                    sumOfNos += i;
                }
            }
            Console.WriteLine(sumOfNos);*/

            //SumOfOddNumbers(5);

            //LongestCommonPrefix("flower", "flow", "fluid");

            //RomanToInt("XXXVIII");

            //PalindromeCheck(123321);

            //ReverseInt(321);

            //Dictionary<int, int> dict = new Dictionary<int, int>();
            //dict.Add(1, 4);//1 is key and 4 is value
            //var value = dict[1];//this will return the value i.e 4

            //reverseString();

            //getMaxMinValues();

            //descendingOrder(new string[] { "fsd", "Fds", "vs" }, new int[] { });

            /* 
            //s for kth smallest, l for kth largest
            kSmallestLargestElement(new int[] {7,10,4,20,15},4,'l');
            */

            //ascendingOrder(new int[] { 2, 2, 3, 1, 1, 0, 0, 1, 0, 1, 4, 5, 6 });


            /*
            int[] a1 = { 1, 2, 3, 8 , 9 , 88 , 12 , 321 , 535, 41 };
            int[] a2 = { 1, 2, 3, 4, 5, 6, 63, 15, 31, 51532, 151, 532 };
            unionOfArrays(a1, a2);
            */

            /*
            int[] a1 = { 1, 2, 3, 8, 9};
            cyclicArrayRotation(a1);
            */
        }
        public static int getMaxProfit(int[] stockPriceArr)
        {

            int minPrice = stockPriceArr[0];
            int maxProfit =  int.MinValue;

            for (int i = 1; i < stockPriceArr.Length; i++)
            {
                if (stockPriceArr[i] < minPrice)
                {
                    minPrice = stockPriceArr[i];
                }
                else if (stockPriceArr[i] - minPrice > maxProfit)
                {
                    maxProfit = stockPriceArr[i] - minPrice;
                }
            }
            return maxProfit;
        }

        public static string[] BorderedMatrix(string[] matrix) {
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            int borderedRows = rows+2;
            int borderedColumns = columns+2;

            string[] borderedArray = new string[matrix.Length];

            string border = new string('*', borderedColumns);
            borderedArray[0] = border;
            borderedArray[borderedRows -1] = border;

            for(int i = 0; i < rows; i++)
            {
                borderedArray[i + 1] = '*' + matrix[i] + '*';
            }

            return borderedArray;
        }

        static string removeUtil(string str, char last_removed)
        {
            // If length of string is 1 or 0
            if (str.Length == 0 || str.Length == 1)
                return str;

            // Remove leftmost same characters
            // and recur for remaining
            // string
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

            // At this point, the first
            // character is definitely different
            // from its adjacent. Ignore first
            // character and recursively
            // remove characters from remaining string
            string rem_str = removeUtil(
                str.Substring(1, str.Length - 1), last_removed);

            // Check if the first character of
            // the rem_string matches with
            // the first character of the original string
            if (rem_str.Length != 0 && rem_str[0] == str[0])
            {
                last_removed = str[0];

                // Remove first character
                return rem_str.Substring(1, rem_str.Length - 1);
            }

            // If remaining string becomes
            // empty and last removed character
            // is same as first character of
            // original string. This is needed
            // for a string like "acbbcddc"
            if (rem_str.Length == 0 && last_removed == str[0])
                return rem_str;

            // If the two first characters
            // of str and rem_str don't match,
            // append first character of str
            // before the first character of
            // rem_str
            return (str[0] + rem_str);
        }

        static string RemoveAdjacentDuplicates(string str)
        {
            char last_removed = '\0';
            Console.WriteLine(removeUtil(str, last_removed));
            return removeUtil(str, last_removed);
        }


        static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int maxLength = 0;
            int left = 0;
            int right = 0;
            HashSet<char> uniqueChars = new HashSet<char>();

            while (right < n)
            {
                if (!uniqueChars.Contains(s[right]))
                {
                    uniqueChars.Add(s[right]);
                    maxLength = Math.Max(maxLength, right - left + 1);
                    right++;
                }
                else
                {
                    uniqueChars.Remove(s[left]);
                    left++;
                }
            }

            return maxLength;
        }

        public static int SumOfOddNumbers(int n)
        {
            int sum = 0;
            for(int i =1; i <= n; i+=2)
            {
                sum += i;
            }
            return sum;
        }

        public static string LongestCommonPrefix(params string[] arr)
        {
            int i = 0;
            string common = string.Empty;
            string shortest = arr.OrderBy(x => x.Length).First();

            foreach (char c in shortest)
            {
                if (arr.Any(s => s[i] != c))
                    break;
                common += c;
                i++;
            }

            Console.WriteLine(common);

            return common;
        }

        public static int ReversedNumber(int num)
        {
            int reversedNum = 0;
            while(num>0)
            {
                reversedNum = reversedNum*10 + num%10;
                num = num / 10;
            }
            Console.WriteLine(reversedNum);
            return reversedNum;
        }

        public static int RomanToInt(string s)
        {
            var num = 0;
            var dictRomanNum = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 },
            };
            
            for (int i = 0; i < s.Length; i++)
            {
                if (i+1< s.Length && dictRomanNum[s[i]]< dictRomanNum[s[i+1]])
                {
                    num -= dictRomanNum[s[i]];
                }
                else
                {
                    num += dictRomanNum[s[i]];
                }
            }
            Console.WriteLine(num);
            return num;
        } 

        public static bool PalindromeCheck(int num)
        {
            var str = new string(num.ToString().Reverse().ToArray());
            Console.WriteLine(num.ToString() == str);
            return (num.ToString() == str);
        }

        public static int ReverseInt(int num)
        {
            int rev = 0;
            while (num > 0)
            {
                rev = rev * 10 + num % 10;  //1st Iter -> rev = 0 + 1 = 1; 2nd Iter -> rev = 10 + 2 = 12; 3rd Iter -> rev = 120 + 3 = 123
                num = num / 10;             //1st Iter -> num = 32 ; 2nd Iter -> num = 3; 3rd Iter -> num = 0
            }
            Console.WriteLine(rev);
            return rev;
        }

        public static void cyclicArrayRotation(int[] arr)
        {
            if (arr.Length <= 1)
                return;
            int temp = arr.Last();

            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }

            arr[0] = temp;

            foreach (int element in arr)
            {
                Console.Write(element+" ");
            }
        }

        public static void unionOfArrays(int[] array1, int[] array2)
        {
            int[] unionArray = array1.Union(array2).ToArray();

            foreach(int i in unionArray)
            {
                Console.WriteLine(i);
            }
        }

        public static void ascendingOrder(int[] intArr)
        {
            Array.Sort(intArr);
            foreach (int i in intArr)
            {
                Console.Write($"{i} ");
            }
        }

        public static void descendingOrder(string[] strArray, int[] intArray)
        {
            bool isEmpty = !strArray.Any() || !intArray.Any();
            Array.Sort(intArray, (x, y) => y.CompareTo(x));
            strArray.OrderByDescending(item => item).ToArray();
            foreach (string str in strArray)
            {
                Console.Write($"{str} ");
            }
            foreach (int num in intArray)
            {
                Console.Write($"{num} ");
            }
        }

        public static void kSmallestLargestElement(int[] numArr, int k, char smallOrLarge)
        {
            switch (smallOrLarge)
            {
                case 's':
                    Array.Sort(numArr);
                    break;
                case 'l':
                    Array.Sort(numArr, (x, y) => y.CompareTo(x));
                    break;
            }
            Console.WriteLine(numArr[k-1]);
        }

        public static void getMaxMinValues()
        {
            Console.WriteLine("Write the numbers seperated by space");
            var numSequence = Console.ReadLine();
            var numValues = numSequence.Split(' ');
            var numArray = new int[numValues.Length];
            for (int i = 0; i < numValues.Length; i++)
            {
                numArray[i] = (int.Parse(numValues[i]));
            }

            int minValue = Convert.ToInt32(numArray[0]);
            int maxValue = Convert.ToInt32(numArray[0]);

            for (int i = 1; i < numArray.Length; i++)
            {
                if (numArray[i] < minValue)
                {
                    minValue = numArray[i];
                }
                if (numArray[i] > maxValue)
                {
                    maxValue = numArray[i];
                }
            }

            Console.WriteLine("max val is " + maxValue);
            Console.WriteLine("min val is " + minValue);
        }


        public static void reverseString()
        {
            Console.WriteLine("Write the numbers sequence seperated with space");
            var numSequence = Console.ReadLine();
            var numArr = (numSequence.Split(' '));

            var reversedArr = new string[numArr.Length];

            for (int i = numArr.Length; i >= 1; i--)
            {
                reversedArr[numArr.Length - i] = numArr[i - 1];
            }
            Console.WriteLine(string.Join(' ', reversedArr));
        }
    }
}