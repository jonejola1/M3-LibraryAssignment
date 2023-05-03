namespace M3_LibraryAssignment
{
    internal class Lender
    {
        public string BorrowerName{ get; private set; }
        public Book BorrowedBook { get; private set; }
        public DateTime DateBorrowed { get; }
        public DateTime DueDate { get; private set; }

        public Lender(string aBorrowerName, Book book, DateTime aDateBorrowed)
        {
            BorrowerName = aBorrowerName;
            BorrowedBook = book;
            DateBorrowed = aDateBorrowed;
            ConvertToDueDate();
        }

        private void ConvertToDueDate()
        {
            DueDate = DateBorrowed.AddDays(14);
        }
    }
}
