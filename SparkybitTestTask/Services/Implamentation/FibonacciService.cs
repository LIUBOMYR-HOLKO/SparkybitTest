using MongoDB.Driver;
using SparkybitTestTask.Model;
using SparkybitTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SparkybitTestTask.Services.Implamentation
{
    public class FibonacciService : IFibonacciService
    {
        private readonly IMongoCollection<Logs> _mongoCollection;
        public FibonacciService(IMongoClient client)
        {
            var db = client.GetDatabase("Sparky");
            _mongoCollection = db.GetCollection<Logs>("Logs");
        }
        public void DoChanges(List<List<int>> rows)
        {
            foreach (List<int> row in rows)
            {
                if (IsFibonacciRow(row))
                {
                    Reverse(row);
                }
            }

        }
        public bool IsFibonacciNumber(int number)
        {
            int commonPartOfTheFormula = 5 * number * number;
            double rightPartOfTheFormula = commonPartOfTheFormula + 4;
            double leftPartOfTheFormula = commonPartOfTheFormula - 4;

            if (IsSqrtWithoutMod(rightPartOfTheFormula) || IsSqrtWithoutMod(leftPartOfTheFormula))
            {
                return true;
            }

            return false;
        }
        public bool IsFibonacciRow(List<int> numbers)
        {
            for(int i = 0; i<numbers.Count; i++)
            {
                if (IsFibonacciNumber(numbers[i]) == false)
                {
                    return false;
                }
                else
                {
                    if (i > 1)
                    {
                        int FN_2 = numbers[i - 2];
                        int FN_1 = numbers[i - 1];
                        if (FN_2 + FN_1 != numbers[i])
                        {
                            return false;
                        }
                    }
                }
            }

            string fibonacciRow = String.Empty;
            foreach(int number in numbers)
            {
                fibonacciRow+=number+" ";
            }
            _mongoCollection.InsertOne(new Logs { DateTime = DateTime.Now, Level = Level.Info, Title = "IsFibonacciRow", Description = $"{fibonacciRow}is Fibonacci row" });

            return true;
        }
        public bool IsSqrtWithoutMod(double number)
        {
            double expectedSqrt = Math.Round(Math.Sqrt(number),0);
            double realSqrt = Math.Sqrt(number);

            if(expectedSqrt == realSqrt)
            {
                return true;
            }

            return false;
        }
        public void Reverse(List<int> data)
        {
            int size = data.Count;

            for (int i = 0; i < size / 2; i++)
            {
                int left = data[i];
                int right = data[size - 1 - i];

                data[i] = right;
                data[size - 1 - i] = left;
            }
        }
    }
}
