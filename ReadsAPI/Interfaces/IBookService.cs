using Microsoft.AspNetCore.Mvc;
using ReadsAPI.Models;

namespace ReadsAPI.Interfaces
{
    public interface IBookService
    {
        JsonResult Save(Book book);

        JsonResult GetAll();

        JsonResult GetByName(string name);
    }
}
