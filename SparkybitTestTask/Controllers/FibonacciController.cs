using Microsoft.AspNetCore.Mvc;
using SparkybitTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SparkybitTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        private readonly IFibonacciService _fibonacciService;
        private readonly IFileService _fileService;
        private static List<List<int>> list = new List<List<int>>();

        public FibonacciController(IFibonacciService fibonacciService, IFileService fileService)
        {
            _fibonacciService = fibonacciService;
            _fileService = fileService;
        }

        [HttpGet]
        public List<List<int>> GetRows(string fileName)
        {
            list = _fileService.ReadFromFile(fileName);
            return list;
        }

        [HttpPost]
        public void WriteRows(string fileName)
        {
            _fileService.WriteToFile(fileName, list);
        }

        [HttpPut]
        public void ReverseFibonacciRows()
        {
            _fibonacciService.DoChanges(list);
        }
    }
}
