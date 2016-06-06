using System;
using System.Collections.Generic;

using System.Web.Mvc;
using AlgorithmsDemo.Models;
using System.Linq;

namespace AlgorithmsDemo.Controllers
{
    public class AlgorithmController : Controller
    {
        // GET: Algorithm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FibonacciFinder()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FibonacciFinder(double FiboInput)
        {
            DataModel DM = new DataModel();
            DM.FiboInput = FiboInput;
            DM.NFibonacciNumbers = new List<string> { "0, ", "1, " }; //use double to avoid overflow problem
            double recent0 = 0;
            double recent1 = 1;
            for (int i = 0; i < DM.FiboInput - 2; i++)
            {
                double newFibonacci = recent0 + recent1;
                recent0 = recent1;
                recent1 = newFibonacci;
                DM.NFibonacciNumbers.Add(newFibonacci.ToString() + ", ");
            }
            return View(DM);
        }





        ///Check is a number is prime
        private Boolean isPrime(double x)
        {
            if (x == 1)
            {
                return false;
            }
            else if (x == 2)
            {
                return true;
            }

            double mark = Math.Floor(Math.Sqrt(x));
            for (double i = 2; i <= mark; i++)
            {
                if (x % i == 0)
                {
                    return false;
                }

            }
            return true;
        }


        [HttpGet]
        public ActionResult PrimeNumbers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PrimeNumbers(double PrimeInput)
        {
            DataModel DM = new DataModel();
            DM.PrimeInput = PrimeInput;
            List<string> PrimeNumbersLessThanN = new List<string>();
            Console.WriteLine("Running PrimeNumberLister function, where input n > 1 is an integer......");
            for (double i = 2; i <= PrimeInput; i++)
            {
                if (isPrime(i))
                {
                    PrimeNumbersLessThanN.Add(i.ToString() + ", ");
                }
                else
                {
                    continue;
                }
            }
            DM.PrimeNumbersLessThanN = PrimeNumbersLessThanN;
            return View(DM);
        }










        private class AlphanumComparatorFast : IComparer<object>
        {
            public int Compare(object x, object y)
            {
                string s1 = x as string;
                if (s1 == null)
                {
                    return 0;
                }
                string s2 = y as string;
                if (s2 == null)
                {
                    return 0;
                }

                int len1 = s1.Length;
                int len2 = s2.Length;
                int marker1 = 0;
                int marker2 = 0;

                // Walk through two the strings with two markers.
                while (marker1 < len1 && marker2 < len2)
                {
                    char ch1 = s1[marker1];
                    char ch2 = s2[marker2];

                    // Some buffers we can build up characters in for each chunk.
                    char[] space1 = new char[len1];
                    int loc1 = 0;
                    char[] space2 = new char[len2];
                    int loc2 = 0;

                    // Walk through all following characters that are digits or
                    // characters in BOTH strings starting at the appropriate marker.
                    // Collect char arrays.
                    do
                    {
                        space1[loc1++] = ch1;
                        marker1++;

                        if (marker1 < len1)
                        {
                            ch1 = s1[marker1];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                    do
                    {
                        space2[loc2++] = ch2;
                        marker2++;

                        if (marker2 < len2)
                        {
                            ch2 = s2[marker2];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                    // If we have collected numbers, compare them numerically.
                    // Otherwise, if we have strings, compare them alphabetically.
                    string str1 = new string(space1);
                    string str2 = new string(space2);

                    int result;

                    if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                    {
                        int thisNumericChunk = int.Parse(str1);
                        int thatNumericChunk = int.Parse(str2);
                        result = thisNumericChunk.CompareTo(thatNumericChunk);
                    }
                    else
                    {
                        result = str1.CompareTo(str2);
                    }

                    if (result != 0)
                    {
                        return result;
                    }
                }
                return len1 - len2;
            }
        }


        [HttpGet]
        public ActionResult StringSorter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StringSorter(string[] StringInput)
        {
            DataModel DB = new DataModel();
            DB.StringInput = StringInput;
            var result = StringInput.ToList();
            AlphanumComparatorFast myCamparer = new AlphanumComparatorFast();
            result.Sort(myCamparer);
            DB.SortedStrings = result;
            return View(DB);
        }
    }
    
}