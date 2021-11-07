using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SparkybitTestTask.Model;
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
        private readonly IMongoCollection<Logs> _mongoCollection;

        private static List<List<int>> list = new List<List<int>>();

        public FibonacciController(IFibonacciService fibonacciService, IFileService fileService, IMongoClient client)
        {
            _fibonacciService = fibonacciService;
            _fileService = fileService;
            var db = client.GetDatabase("Sparky");
            _mongoCollection = db.GetCollection<Logs>("Logs");
        }

        [HttpGet]
        public List<List<int>> GetRows(string fileName)
        {
            _mongoCollection.InsertOne(new Logs { DateTime=DateTime.Now, Level=Level.Info, Title = "HttpGet GetRows", Description = $"Read rows from {fileName}"});
            list = _fileService.ReadFromFile(fileName);
            _mongoCollection.InsertOne(new Logs { DateTime = DateTime.Now, Level = Level.Info, Title = "HttpGet GetRows", Description = $"Read successfully" });
            return list;
        }

        [HttpPost]
        public void WriteRows(string fileName)
        {
            _mongoCollection.InsertOne(new Logs { DateTime=DateTime.Now, Level=Level.Info, Title = "HttpPost WriteRows", Description = $"Write rows to {fileName}"});
            _fileService.WriteToFile(fileName, list);
            _mongoCollection.InsertOne(new Logs { DateTime = DateTime.Now, Level = Level.Info, Title = "HttpPost WriteRows", Description = $"Wrote successfully" });
        }

        [HttpPut]
        public void ReverseFibonacciRows()
        {
            _mongoCollection.InsertOne(new Logs { DateTime = DateTime.Now, Level = Level.Info, Title = "HttpPut ReverseFibonacciRows", Description = "Do changes for fibonacci rows" });
            _fibonacciService.DoChanges(list);
            _mongoCollection.InsertOne(new Logs { DateTime = DateTime.Now, Level = Level.Info, Title = "HttpPut ReverseFibonacciRows", Description = "Did successfully" });
        }
    }
}
