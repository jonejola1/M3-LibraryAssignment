namespace M3_LibraryAssignment
{
    internal class Borrower
    {
        private string _borrowerName;
        private Book _borrowedBook;
        private DateTime _dateBorrowed;
        private DateTime _dueDate;

        public Borrower(string aBorrowerName, Book aBook, DateTime aDateBorrowed)
        {
            _borrowerName = aBorrowerName;
            _borrowedBook = aBook;
            _dateBorrowed = aDateBorrowed;
            ConvertToDueDate();
        }

        private void ConvertToDueDate()
        {
            _dueDate = _dateBorrowed.AddDays(14);
        }
        public void DetailedLendInfo()
        {
            Console.WriteLine($"Du låner nå {_borrowedBook.GetName()} by {_borrowedBook.GetAuthor()}. Lånt {_dateBorrowed.ToShortDateString()} av {_borrowerName}, Utløps dato er {_dueDate.ToShortDateString()}.\n");
        }

        public void CheckBorrowerInfo()
        {
            var nameOfBook = _borrowedBook.GetName();
            var authorOfBook = _borrowedBook.GetAuthor();
            Console.WriteLine($"{nameOfBook} by {authorOfBook} is borrowed by {_borrowerName}\n");
        }

        public void CheckIfDueDateHasExpired()
        {
            if (IsExpired())
            {
                Console.WriteLine($"{_borrowerName} har ikke levert boken på fristen: {_dueDate.ToShortDateString()} og et gebyr vil bli sent!");
            }
        }

        private bool IsExpired()
        {
            return DateTime.Now > _dueDate;
        }

        public bool CheckBorrowerBookMatch(string borrowerName, string bookName)
        {
            return _borrowerName == borrowerName && _borrowedBook.GetName() == bookName;
        }

        public void ReturnBookToLibrary()
        {
            _borrowedBook.IncreaseQuantity();
            Console.WriteLine($"{_borrowedBook.GetName()} by {_borrowedBook.GetAuthor()} was returned by {_borrowerName}, at {DateTime.Now}\n");
        }
    }
}
