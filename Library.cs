namespace M3_LibraryAssignment
{
    internal class Library
    {
        private List<Book> _booksInInventory;

        private List<Borrower> _borrowedBooks;

        public Library(List<Book> aBooks, List<Borrower> aBorrowedBooks)
        {
            _booksInInventory = aBooks;
            _borrowedBooks = aBorrowedBooks;
        }

        public void AddBook(string nameOfBook, string authorOfBook, int quantityOfBook)
        {
            if (IsDuplicate(nameOfBook)) return;
            var newBookToAdd = new Book(nameOfBook, authorOfBook, quantityOfBook);
            _booksInInventory.Add(newBookToAdd);
            Console.WriteLine($"Added the book {nameOfBook} by {authorOfBook}\n");

        }

        private bool IsDuplicate(string nameOfBook)
        {
            foreach (var book in _booksInInventory)
            {
                if (book.Name == nameOfBook) return true;
            }
            return false;
        }

        public void ShowAll()
        {
            var index = 1;
            foreach (var book in _booksInInventory)
            {
                book.WriteBookInfo(index);
                index++;
            }
        }

        public void ShowRecentBooks()
        {
            foreach (var book in _booksInInventory.TakeLast(5))
            {
                var name = book.Name;
                var author = book.Author;
                Console.WriteLine($"{name} by {author}\n");
            }
        }

        public void LendBook(string aBorrowerName)
        {
            Console.WriteLine("\nHvilken bok vil du låne?");
            ShowAll();


            int selectedBookIndex = SelectBookToLend();


            var selectedBook = _booksInInventory[selectedBookIndex - 1];
            if (selectedBook.Quantity == 0 ) return;
            var lender = new Borrower(aBorrowerName, selectedBook, DateTime.Today);
            _borrowedBooks.Add(lender);
            
            selectedBook.DecreaseQuantity();
            lender.DetailedLendInfo();
        }

        private int SelectBookToLend()
        {
            while (true)
            {
                int selectedBookIndex;
                var input = Console.ReadLine();
                if (int.TryParse(input, out selectedBookIndex))
                {
                    if (selectedBookIndex >= 1 && selectedBookIndex <= _booksInInventory.Count)
                    {
                       return selectedBookIndex;
                    }
                }
            }
        }

        public void ShowAllLendedBooks()
        {
            foreach (var borrower in _borrowedBooks)
            {
                borrower.CheckBorrowerInfo();
            }
        }

        public void ReturnBorrowedBook(string borrowerName, string bookName)
        {
            foreach (var borrower in _borrowedBooks)
            {
                if (borrower.BorrowerName == borrowerName && borrower.BorrowedBook.Name == bookName)
                {
                    var returnedBook = borrower.BorrowedBook;
                    returnedBook.IncreaseQuantity();
                    _borrowedBooks.Remove(borrower);
                    Console.WriteLine($"{returnedBook.Name} by {returnedBook.Author} was returned by {borrowerName}, at {DateTime.Now}\n");
                    break; 
                }
            }
            Console.WriteLine($"{bookName} borrowed by {borrowerName} was not found.\n");
        }

        public void GetExpiredDateForLenders()
        {
            foreach (var borrower in _borrowedBooks)
            {
                borrower.CheckIfDueDateHasExpired();
            }
        }
    }
}
