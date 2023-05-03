namespace M3_LibraryAssignment
{
    internal class Borrower
    {
        public string BorrowerName{ get; private set; }
        public Book BorrowedBook { get; private set; }
        private DateTime DateBorrowed { get; }
        private DateTime DueDate { get; set; }

        public Borrower(string aBorrowerName, Book aBook, DateTime aDateBorrowed)
        {
            BorrowerName = aBorrowerName;
            BorrowedBook = aBook;
            DateBorrowed = aDateBorrowed;
            ConvertToDueDate();
        }

        private void ConvertToDueDate()
        {
            DueDate = DateBorrowed.AddDays(14);
        }
        public void DetailedLendInfo()
        {
            Console.WriteLine($"Du låner nå {BorrowedBook.Name} by {BorrowedBook.Author}. Lånt {DateBorrowed.ToShortDateString()} av {BorrowerName}, Utløps dato er {DueDate.ToShortDateString()}.\n");
        }

        public bool IsExpired()
        {
            return DateTime.Now > DueDate;
        }
    }
}
