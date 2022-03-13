using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            int tempResult;
            List<int> negatives = new List<int>();

            if (numbers.Length != 0)
            {
                List<string> delimeters = new List<string>();
                if (!numbers.Contains("//"))
                {
                    delimeters.Add(",");
                    delimeters.Add("\n");
                }
                else
                {
                    if (numbers.Contains("[") && numbers.Contains("]"))
                    {
                        // multiple and/or longer than 1 delimeters
                        int dInd = 2;
                        bool cont = true;
                        while (cont)
                        {
                            if (numbers.IndexOf("[", dInd) != -1 && numbers.IndexOf("]", dInd) != -1)
                            {
                                string newDeli = numbers.Substring(dInd + 1, numbers.IndexOf("]", dInd) - (dInd + 1));
                                delimeters.Add(newDeli);
                                dInd = numbers.IndexOf("]", dInd) + 1;
                            }
                            else
                                cont = false;
                            //dInd = numbers.IndexOf("[");
                        }
                        numbers = numbers.Substring(dInd + 1);
                    }
                    else
                    {
                        delimeters.Add(numbers.Substring(2, 1));
                        numbers = numbers.Substring(4);
                    }
                }

                // we have delimeters list
                int ind, startInd;
                string usedDeli;
                (ind, usedDeli) = FindInd(numbers, 0, delimeters);
                startInd = 0;

                if (ind == Int32.MaxValue) // one number
                {
                    result = Int32.Parse(numbers);
                    startInd = -1;
                }

                while (startInd != -1)
                {
                    tempResult = Int32.Parse(numbers.Substring(startInd, ind - startInd));
                    if (tempResult >= 0)
                    {
                        if (tempResult <= 1000)
                            result += tempResult;
                    }
                    else
                        negatives.Add(tempResult);

                    startInd = ind + usedDeli.Length;
                    (ind, usedDeli) = FindInd(numbers, startInd, delimeters);
                    if (ind == Int32.MaxValue) // last element
                    {
                        tempResult = Int32.Parse(numbers.Substring(startInd));
                        if (tempResult >= 0)
                        {
                            if (tempResult <= 1000)
                                result += tempResult;
                        }
                        else
                            negatives.Add(tempResult);
                        startInd = -1;
                    }
                }
            }

            if (negatives.Count > 0)
            {
                string err = "negatives not allowed";
                foreach (int n in negatives)
                    err = err + " " + n;
                throw new ArgumentException(err);
            }

            return result;
        }

        private (int, string) FindInd(string numbers, int startInd, List<string> delimeters)
        {
            List<int> indexes = new List<int>();
            foreach (string deli in delimeters)
                indexes.Add(numbers.IndexOf(deli, startInd));
            for (int i = 0; i < indexes.Count; i++)
                if (indexes[i] == -1)
                    indexes[i] = Int32.MaxValue;

            int min = Int32.MaxValue;
            int minInd = 0;
            for (int i = 0; i < indexes.Count; i++)
                if (indexes[i] < min)
                {
                    min = indexes[i];
                    minInd = i;
                }

            //indexes.Sort();

            return (indexes[minInd], delimeters[minInd]);
        }
    }
}
