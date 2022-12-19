using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TIM.Lib.Data;
using TIM.Lib.Model.Request;
using TIM.Lib.Models;

namespace TIM.Lib.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EfCoreBookRepository _bookRepository;
        private readonly EfCoreBookTransactionRepository _bookTransactionRepository;
        private readonly MyMDBContext _db;

        public HomeController(ILogger<HomeController> logger, EfCoreBookRepository bookRepository, EfCoreBookTransactionRepository bookTransactionRepository, MyMDBContext db)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _bookTransactionRepository = bookTransactionRepository;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<JsonResult> Search([FromBody] Search search)
        {
            var allBooks = await _bookRepository.GetAll();

            var data = allBooks.Where(x => (x.Isbn.Contains(search.Isbn ?? "") || search.Isbn == null) && (x.Name.Contains(search.Name ?? "") || search.Name == null) && (x.Author.Contains(search.AuthorName ?? "") || search.AuthorName == null)).ToList();

            return Json(data);
        }

        public async Task<IActionResult> Transactions()
        {
            var trans = _db.BookTransaction.Include(x => x.Book).Include(x => x.Member).Select(x => x).AsEnumerable();

            return View(trans);
        }

        public async Task<IActionResult> Daily()
        {
            var getAllBooks = _db.BookTransaction.Include(x => x.Book).Include(x => x.Member).Select(x => x).AsEnumerable();

            var filterLateBooks = getAllBooks.Where(x => x.ActualReturnDate.HasValue && x.ActualReturnDate.Value.DateTime > x.ExpectedReturnDate.DateTime);

            return View(getAllBooks);
        }
        private void BubleSort() 
        {
            int[] arr = { 11, 93, 45, 98, 13, 55 };

            int length = arr.Length;

            int temp = arr[0];

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];

                        arr[i] = arr[j];

                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
