using FakeBookData.Application.DTO;
using FakeBookData.Application.Services;
using FakeBookData.Contracts;
using FakeBookData.Enums;
using FakeBookData.Models;
using FakeBookData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FakeBookData.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetIndexPage()
        {
            var config = new RandomBooksConfiguration(
                BookCount: 20,
                Locale: FakerLocale.En,
                Seed: 500000,
                LikeCount: 5,
                ReviewCount: 3);

            var model = new HomeIndexViewModel()
            {
                StartIndex = 1,
                Books = _bookService.GetRandomBooks(config)
            };

            return View("Index", model);
        }

        [HttpGet("/next")]
        public IActionResult GetNextBooks([FromQuery] GetBooksRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var configuration = req.ToApplicationDTO();

            var model = new HomeIndexViewModel()
            {
                StartIndex = req.StartIndex,
                Books = _bookService.GetRandomBooks(configuration)
            };

            return PartialView("BookList", model);
        }
    }
}
