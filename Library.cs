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
            if (NoDuplicate(nameOfBook))
            {
                var newBookToAdd = new Book(nameOfBook, authorOfBook, quantityOfBook);
                _booksInInventory.Add(newBookToAdd);
                Console.WriteLine($"Added the book {nameOfBook} by {authorOfBook}\n");
            }
            
        }

        private bool NoDuplicate(string nameOfbook)
        {
            foreach (var book in _booksInInventory)
            {
                if (book.Name == nameOfbook) return true;
            }

            return false;
        }

        public void ShowAll()
        {
            var index = 1;
            foreach (var book in _booksInInventory)
            {
                var name = book.Name;
                var author = book.Author;
                var quantity = book.Quantity;
                Console.WriteLine($"{index}: {name} by {author}, Quantity: {quantity}\n");
                index++;
            }
        }

        public void ShowRecentBooks()
        {
            var recentBooks = _booksInInventory.GetRange(Math.Max(0, _booksInInventory.Count - 5),
                Math.Min(5, _booksInInventory.Count));
            foreach (var book in recentBooks)
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
                    Console.WriteLine($"This is not a valid input int.\nTryAgain!");
                }
            }
        }

        public void ShowAllLendedBooks()
        {
            foreach (var borrower in _borrowedBooks)
            {
                var borrowerName = borrower.BorrowerName;
                var nameOfBook = borrower.BorrowedBook.Name;
                var authorOfBook = borrower.BorrowedBook.Author;
                Console.WriteLine($"{nameOfBook} by {authorOfBook} is borrowed by {borrowerName}\n");
            }
        }

        public void ReturnBorrowedBook(string borrowerName, string bookName)
        {
            foreach (var borrower in _borrowedBooks)
            {
                if (borrower.BorrowerName == borrowerName)
                {
                    if (borrower.BorrowedBook.Name == bookName)
                    {
                        var returnedBook = borrower.BorrowedBook;
                        returnedBook.IncreaseQuantity();
                        _borrowedBooks.Remove(borrower);
                        Console.WriteLine($"{returnedBook.Name} by {returnedBook.Author} was returned by {borrowerName}, at {DateTime.Now}\n");
                        break;
                    }
                    Console.WriteLine($"{bookName} borrowed by {borrowerName} was not found.\n");
                }
            }
        }

        public void CheckExpiryDateForLenders()
        {
            foreach (var borrower in _borrowedBooks)
            {
                if (borrower.IsExpired())
                {
                    Console.WriteLine($"{borrower.BorrowerName} har ikke levert boken på fristen og et gebyr vil bli sent!");
                }
            }
        }
    }
}
