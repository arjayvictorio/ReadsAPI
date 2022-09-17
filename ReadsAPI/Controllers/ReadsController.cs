using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadsAPI.Data;
using ReadsAPI.Interfaces;
using ReadsAPI.Models;
using ReadsAPI.Services;
using ReadsAPI.Validations;

namespace ReadsAPI.Controllers
{
    [Route("api/[controller]/Done/[action]")]
    [ApiController]
    public class ReadsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly BookValidation _bookvalidator;

        public ReadsController(ApiContext context, BookValidation bookvalidator)
        {
            _context = context;
            _bookvalidator = bookvalidator;
        }

        /// <summary>
        /// Add read book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Save(Book book)
        {

            if(!_bookvalidator.isValid(book)) return new JsonResult(Ok(_bookvalidator));

            return new BookService(_context).Save(book);

        }

        /// <summary>
        /// Get all read books
        /// </summary>
        /// <returns>Return a list of book on json format</returns>
        [HttpGet]
        public JsonResult GetAll()
        {
            return new BookService(_context).GetAll();
        }

        /// <summary>
        /// Find book by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Return a book on json format</returns>
        [HttpGet]
        public JsonResult GetByName(string name)
        {
            return new BookService(_context).GetByName(name);

        }
    }
}
