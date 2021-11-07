using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkybitTestTask.Services.Interfaces
{
    public interface IFileService
    {
        public List<List<int>> ReadFromFile(string fileName);
        public void WriteToFile(string fileName, List<List<int>> data);
    }
}
