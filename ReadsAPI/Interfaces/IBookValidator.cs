using ReadsAPI.Models;

namespace ReadsAPI.Interfaces
{
    public interface IBookValidator
    {
        bool isValid(Book book);
    }
}
