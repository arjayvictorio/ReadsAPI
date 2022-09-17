using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadsAPI.Data;
using ReadsAPI.Interfaces;
using ReadsAPI.Models;
using System.Text.RegularExpressions;

namespace ReadsAPI.Services
{
    public class BookService:IBookService
    {
        private ApiContext _book;
        public BookService(ApiContext book)
        {
            _book= book;
        }

        public JsonResult GetAll()
        {
            var result = _book.Books.ToList();

            if (result == null)
                return new JsonResult(new NotFoundResult());

            return new JsonResult(new OkObjectResult(result));
        }

        public JsonResult GetByName(string name)
        {
            name ??= "";

            var result = _book.Books.Where(i=>i.Name.Contains(name)).ToList();

            if (result == null)
                return new JsonResult(new NotFoundResult());

            return new JsonResult(new OkObjectResult(result));
        }

        public JsonResult Save(Book book)
        {

            var bookInDb = _book.Books.Find(book.Id);


            if (bookInDb == null)
            {
                _book.Books.Add(book);
                _book.SaveChanges();
            }

            return new JsonResult(new OkObjectResult(book));
        }
    }
}
