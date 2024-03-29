﻿namespace M3_LibraryAssignment
{
    internal class Program
    {
        static void Main()
        {
            var books = new List<Book>
            {
                new Book("To Kill a Mockingbird", "Harper Lee", 10),
                new Book("1984", "George Orwell", 8),
                new Book("The Catcher in the Rye", "J.D. Salinger", 5),
                new Book("Brave New World", "Aldous Huxley", 7),
                new Book("Pride and Prejudice", "Jane Austen", 12),
                new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", 6),
                new Book("The Great Gatsby", "F. Scott Fitzgerald", 9),
                new Book("The Lord of the Rings", "J.R.R. Tolkien", 15),
                new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 11),
                new Book("The Hunger Games", "Suzanne Collins", 8),
                new Book("To the Lighthouse", "Virginia Woolf", 4),
                new Book("Beloved", "Toni Morrison", 6),
                new Book("The Color Purple", "Alice Walker", 0),
                new Book("The Handmaid's Tale", "Margaret Atwood", 5),
                new Book("The Road", "Cormac McCarthy", 7),
                new Book("The Alchemist", "Paulo Coelho", 10),
                new Book("The Kite Runner", "Khaled Hosseini", 8),
                new Book("The Da Vinci Code", "Dan Brown", 12),
                new Book("The Picture of Dorian Gray", "Oscar Wilde", 6),
                new Book("The Sun Also Rises", "Ernest Hemingway", 4),
                new Book("The Adventures of Tom Sawyer", "Mark Twain", 9),
                new Book("The Secret Garden", "Frances Hodgson Burnett", 7),
                new Book("Wuthering Heights", "Emily Bronte", 5),
                new Book("The Hobbit", "J.R.R. Tolkien", 10),
                new Book("The Girl with the Dragon Tattoo", "Stieg Larsson", 6),
                new Book("The Book Thief", "Markus Zusak", 8),
                new Book("The Joy Luck Club", "Amy Tan", 3),
                new Book("Gone with the Wind", "Margaret Mitchell", 9),
                new Book("The Time Traveler's Wife", "Audrey Niffenegger", 5),
                new Book("The Catcher in the Rye", "J.D. Salinger", 7),
                new Book("Little Women", "Louisa May Alcott", 6),
                new Book("The Outsiders", "S.E. Hinton", 4),
                new Book("The Adventures of Huckleberry Finn", "Mark Twain", 9),
                new Book("The Chronicles of Narnia", "C.S. Lewis", 12),
                new Book("The Shining", "Stephen King", 7),
                new Book("The Stand", "Stephen King", 10),
                new Book("A Tale of Two Cities", "Charles Dickens", 11),
                new Book("Les Miserables", "Victor Hugo", 13),
                new Book("The Count of Monte Cristo", "Alexandre Dumas", 8),
            };
            var borrowedBooks = new List<Borrower>
            {
                new Borrower("Pål", new Book("Spice & Wolf: The Coin of the Sun I, Vol 15", "Isuna Hasekura", 1),  DateTime.Today),
                new Borrower("Sarah", books[5], DateTime.Today.AddDays(-14)),
                new Borrower("John", books[3], DateTime.Today.AddDays(-7)),
                new Borrower("Michael", books[11], DateTime.Today.AddDays(-10)),
                new Borrower("Emily", books[21], DateTime.Today.AddDays(-20)),
                new Borrower("David", books[28], DateTime.Today.AddDays(-4)),
                new Borrower("Jessica", books[31], DateTime.Today.AddDays(-8)),
                new Borrower("James", books[35], DateTime.Today.AddDays(-12)),
                new Borrower("Rachel", books[29], DateTime.Today.AddDays(-16)),
                new Borrower("William", books[22], DateTime.Today.AddDays(-6)),
                new Borrower("Amanda", books[34], DateTime.Today.AddDays(-18))
            };

            var library = new Library(books, borrowedBooks);
            library.ShowRecentBooks();
            library.AddBook("Harry Potter", "J.K.Rowling", 5);
            library.ShowRecentBooks();
            library.ShowAllLendedBooks();
            library.LendBook("Per");
            library.ShowAll();

            library.GetExpiredDateForLenders();

            library.ReturnBorrowedBook("John", "Brave New World");
            library.ReturnBorrowedBook("Per", "Test To fail");

            library.ShowAllLendedBooks();

            /*
            Terjes anbefaling:
            Bibliotek
            Har liste over bøker
            Antall eksemplarer
            Liste over låntakere
            Hvilke bøker er utlånt
            Innleveringsfrist 
            Når man låner, frist = nå + 14 dager
            Hva om ulike bøker har ulik frist?
            Lage purreliste - alle bøker som er utlånt og skulle vært levert tilbake
            var l = new Library()
            var book1 = l.AddBook("vfkghfkjh") 
            var per = l.AddLender("Per")
            per.Loan(book1)
            l.Show()
            vise hvilke bøker som er lånt ut til hvem inkl. frist
            */

        }
    }
}