using ReadsAPI.Interfaces;
using ReadsAPI.Models;

namespace ReadsAPI.Validations
{
    public class BookValidation:IBookValidator
    {
        public string ErrorMessage { get; set; }=string.Empty;
        public string PropertyError { get; set; }=string.Empty;
        public bool isValid(Book book)
        {
            if (book.Id<=0)
            {
                ErrorMessage = "Invalid Id";
                PropertyError = "Id";
                return false;
            }

            if (book.Name=="")
            {
                ErrorMessage = "Invalid Name";
                PropertyError = "Name";
                return false;
            }

            if (book.Description=="")
            {
                ErrorMessage = "Invalid Description";
                PropertyError = "Description";
                return false;
            }

            return true;
        }
    }
}
