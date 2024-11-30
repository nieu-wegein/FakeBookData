using Bogus;
using FakeBookData.Application.DTO;
using FakeBookData.Application.Tools;
using FakeBookData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FakeBookData.Application.Services
{
    public class BookService : IBookService
    {
        public List<Book> GetRandomBooks(RandomBooksConfiguration booksInfo)
        {
            var locale = CaseConverter.ToLowerFirst(booksInfo.Locale.ToString());
            var getLikeCount = FunctionLooper.LoopWithFloat<int>(i => ++i, booksInfo.LikeCount, booksInfo.Seed);
            var getReviewCount = FunctionLooper.LoopWithFloat<int>(i => ++i, booksInfo.ReviewCount, booksInfo.Seed);

            var reviewGenerator = new Faker<Review>(locale)
                .UseSeed(booksInfo.Seed)
                .RuleFor(r => r.Author, gen => gen.Name.FullName())
                .RuleFor(r => r.Content, gen => CaseConverter.ToUpperFirst(gen.Hacker.Phrase()));

            var generator = new Faker<Book>(locale)
                .UseSeed(booksInfo.Seed)
                .RuleFor(b => b.ISBN, gen => gen.Random.ReplaceNumbers("978-#-####-####-#"))
                .RuleFor(b => b.Title, gen => CaseConverter.ToUpperFirst(gen.Hacker.Adjective() + " " + gen.Hacker.Noun()))
                .RuleFor(b => b.AuthorList, gen => gen.Make(gen.Random.Int(1, 3), () => gen.Name.FullName()))
                .RuleFor(b => b.CoverUrl, gen => gen.Image.PicsumUrl(240, 320))
                .RuleFor(b => b.Publisher, gen => gen.Company.CompanyName().Replace(" and", ","))
                .RuleFor(b => b.Year, gen => gen.Date.PastDateOnly(30))
                .RuleFor(b => b.PageCount, gen => gen.Random.Int(100, 900))
                .RuleFor(b => b.LikeCount, gen => getLikeCount(0))
                .RuleFor(b => b.Reviews, gen => reviewGenerator.Generate(getReviewCount(0)).ToList());

            return generator.Generate(booksInfo.BookCount);
        }
    }
}