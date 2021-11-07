using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkybitTestTask.Services.Interfaces
{
    public interface IFibonacciService
    {
        public void DoChanges(List<List<int>> rows);
        public bool IsFibonacciNumber(int number);
        public bool IsFibonacciRow(List<int> numbers);
        public bool IsSqrtWithoutMod(double number);
        public void Reverse(List<int> data);
    }
}
