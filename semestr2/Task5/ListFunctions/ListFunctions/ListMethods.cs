using System;
using System.Collections.Generic;

namespace ListFunctions
{
    public static class ListMethods
    {
        /// <summary>
        /// Returns list. Elements form old list were chenged by method and added to new list.
        /// </summary>
        public static List<int> Map(List<int> list, Func<int, int> method)
        {
            List<int> result = new List<int>();
            foreach (int value in list)
            {
                result.Add(method(value));
            }
            return result;
        }

        /// <summary>
        /// Returns list. Elements from old list were "filtered" by method and added to new.
        /// </summary>
        public static List<int> Filter(List<int> list, Func<int, bool> method)
        {
            List<int> result = new List<int>();
            foreach (int value in list)
            {
                if (method(value))
                {
                    result.Add(value);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns account, which was changed by every list's element by meyhod. 
        /// </summary>
        public static int Fold(List<int> list, int account, Func<int, int, int> method)
        {
            foreach (int value in list)
            {
                account = method(account, value);
            }
            return account;
        }
    }
}
