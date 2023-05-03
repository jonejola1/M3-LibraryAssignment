using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_LibraryAssignment
{
    internal class Library
    {
        private List<Book> _booksInInventory;

        private List<Lender> _lendedBooks;

        public Library(List<Book> aBooks, List<Lender> aLendedBooks)
        {
            _booksInInventory = aBooks;
            _lendedBooks = aLendedBooks;
        }

        public void ShowLendedBooks()
        {
            foreach (var book in _lendedBooks)
            {
                var personName = book.BorrowerName;
                var name = book.BorrowedBook.Name;
                var author = book.BorrowedBook.Author;
                Console.WriteLine($"{name} by {author} is lended by {personName}");
                
            }
        }
        public void AddBook(string aName, string aAuthor, int aQuantity)
        {
            var newBook = new Book(aName, aAuthor, aQuantity);
            _booksInInventory.Add(newBook);
            Console.WriteLine($"Added the book {aName} by {aAuthor}\n");
        }

        public void ShowAll()
        {
            var index = 1;
            foreach (var book in _booksInInventory)
            {
                var name = book.Name;
                var author = book.Author;
                var quantity = book.Quantity;
                Console.WriteLine($"{index}: {name} by {author}, Quantity: {quantity}");
                index++;
            }
        }

        public void LendBook(string aFirstName)
        {
            Console.WriteLine("\nHvilken bok vil du låne?");
            ShowAll();
            var Book = Console.ReadLine();
            var BookIndex = _booksInInventory[Convert.ToInt32(Book) -1];
            BookIndex.DecreaseQuantity();
            var Lender = new Lender(aFirstName, BookIndex, DateTime.Today);
            _lendedBooks.Add(Lender);
            Console.WriteLine($"Du låner nå {BookIndex.Name} by {BookIndex.Author}. Lånt {Lender.DateBorrowed.ToShortDateString()} av {Lender.BorrowerName}, Utløps dato er {Lender.DueDate.ToShortDateString()}");
        }

        public void ShowRecentBooks()
        {
            var recentBooks = _booksInInventory.GetRange(Math.Max(0, _booksInInventory.Count - 5),
                Math.Min(5, _booksInInventory.Count));
            foreach (var book in recentBooks)
            {
                Console.WriteLine($"{book.Name} by {book.Author}");
            }
            
            
        }
    }
}
