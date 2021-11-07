using SparkybitTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SparkybitTestTask.Services.Implamentation
{
    public class FileService : IFileService
    {
        public List<List<int>> ReadFromFile(string fileName)
        {
            List<List<int>> result = new List<List<int>>();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string fileContent = streamReader.ReadToEnd();
                string[] lines = fileContent.Split("\r\n");

                for(int i = 0; i<lines.Length; i++)
                {
                    result.Add(new List<int>());
                    string []splittedLine = lines[i].Split(' ');
                    for(int j = 0;j< splittedLine.Length; j++)
                    {
                        result[i].Add(Convert.ToInt32(splittedLine[j]));
                    }
                }
            }

            return result;
        }

        public void WriteToFile(string fileName, List<List<int>> data)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                foreach (List<int> list in data)
                {
                    foreach (int number in list)
                    {
                        streamWriter.Write(number + " ");
                    }
                    streamWriter.WriteLine();
                }
            }
        }
    }
}
