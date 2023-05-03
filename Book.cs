namespace M3_LibraryAssignment
{
    internal class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Quantity { get; private set; }

        public Book(string name, string author, int quantity)
        {
            Name = name;
            Author = author;
            Quantity = quantity;
        }

        public void IncreaseQuantity()
        {
            Quantity++;
        }
        public void DecreaseQuantity()
        {
            Quantity--;
        }
    }
}
