using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class RedPill : IRedPill
    {
        #region Public API
        /// <summary>
        /// What Is My Token
        /// </summary>
        /// <returns></returns>
        public Guid WhatIsYourToken()
        {
            return new Guid("87cc6406-28c5-47e3-ab1a-b336b1eacdd5");
        }
        /// <summary>
        /// Triangel Type
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            if (!isValidTriangle(a, b, c))
            {
                return TriangleType.Error;
            }
            else if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }
            else if (a == b || b == c || a == c)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }
        /// <summary>
        /// Fibonacci Sum
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long FibonacciNumber(long n)
        {
            long sum = 0;
            long X = 1;
            long _temp = 0;

            try
            {
                if (n == 0)
                {
                    return 0;
                }
                else if (n < 0)
                {
                    if (n < -92)
                        throw new Exception("Integer overflow.");
                    for (long i = n; i < 0; i++)
                    {
                        _temp = sum;
                        sum = X;
                        X = _temp - X;
                    }
                }
                else
                {
                    if (n > 92)
                        throw new Exception("Integer overflow.");
                    for (long i = 0; i < n; i++)
                    {
                        _temp = sum;
                        sum = X;
                        X = _temp + X;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Result Overflow");
            }
            return sum;
        }
        /// <summary>
        /// Reverse String Only Words
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                string ReversedWord = "";
                List<string> WordBlocksList = SplitStringOverSpace(s);

                foreach (string w in WordBlocksList)
                {
                    if (w.Length > 0)
                    {
                        for (int i = w.Length - 1; i > -1; i--)
                            ReversedWord += w[i].ToString();
                    }
                }
                return ReversedWord;
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region Private Method
        private bool isValidTriangle(int a, int b, int c)
        {
            return (a > 1 && b > 1 && c > 1)
                && !(((long)a + (long)b) <= c || ((long)b + (long)c) <= a || ((long)c + (long)a) <= b);
        }
        private List<string> SplitStringOverSpace(string Word)
        {
            List<string> tempArray = new List<string>();
            tempArray.Add("");

            foreach (char c in Word)
            {
                if (c == ' ')
                {
                    tempArray.Add(" ");
                    tempArray.Add("");
                }
                else
                {
                    tempArray[tempArray.Count - 1] += c;
                }
            }

            return tempArray;
        }
        #endregion
    }
}
