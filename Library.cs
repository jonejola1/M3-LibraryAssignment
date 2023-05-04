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
                if (book.GetName() == nameOfBook) return true;
            }
            return false;
        }

        public void ShowAll()
        {
            var index = 1;
            foreach (var book in _booksInInventory)
            {
                book.WriteBookInfo(index-1);
                index++;
            }
        }

        public void ShowRecentBooks()
        {
            foreach (var book in _booksInInventory.TakeLast(5))
            {
                var name = book.GetName();
                var author = book.GetName();
                Console.WriteLine($"{name} by {author}\n");
            }
        }

        public void LendBook(string aBorrowerName)
        {
            Console.WriteLine("\nHvilken bok vil du låne?");
            ShowAll();


            Book selectedBook = SelectBookToLend();


            if (selectedBook.GetQuantity() == 0 ) return;
            var lender = new Borrower(aBorrowerName, selectedBook, DateTime.Today);
            _borrowedBooks.Add(lender);
            
            selectedBook.DecreaseQuantity();
            lender.DetailedLendInfo();
        }

        public void ShowAllLendedBooks()
        {
            foreach (var borrower in _borrowedBooks)
            {
                borrower.CheckBorrowerInfo();
            }
        }

        private Book SelectBookToLend()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var selectedBookIndex))
                {
                    if (IsValidBookIndex(selectedBookIndex))
                    {
                        return GetBookToLend(selectedBookIndex);
                    }
                }
            }
        }

        private bool IsValidBookIndex(int selectedBookIndex)
        {
            if (selectedBookIndex >= 1 && selectedBookIndex <= _booksInInventory.Count)
            {
                return true;
            }
            return false;
        }
        private Book GetBookToLend(int bookIndex)
        {
            var selectedBookToLend = _booksInInventory[bookIndex];
            return selectedBookToLend;
        }

        public void ReturnBorrowedBook(string borrowerName, string bookName)
        {
            foreach (var borrower in _borrowedBooks)
            {
                if (!borrower.CheckBorrowerBookMatch(borrowerName, bookName)) continue;
                RemoveBookBorrower(borrower);
                return;
            }
            Console.WriteLine($"{bookName} borrowed by {borrowerName} was not found.\n");
        }

        public void RemoveBookBorrower(Borrower borrower)
        {
            if (_borrowedBooks.Contains(borrower))
            {
                borrower.ReturnBookToLibrary();
                _borrowedBooks.Remove(borrower);
            }
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
