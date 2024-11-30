using FakeBookData.Application.DTO;
using FakeBookData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBookData.Application.Services
{
    public interface IBookService
    {
        List<Book> GetRandomBooks(RandomBooksConfiguration booksInfo);
    }
}
