namespace M3_LibraryAssignment
{
    internal class Book
    {
        private string _name;
        private string _author;
        private int _quantity;

        public Book(string name, string author, int quantity)
        {
            _name = name;
            _author = author;
            _quantity = quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetAuthor()
        {
            return _author;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void WriteBookInfo(int index) 
        {
            Console.WriteLine($"{index}: {_name} by {_author}, _quantity: {_quantity}\n");
        }

        public void IncreaseQuantity()
        {
            _quantity++;
        }
        public void DecreaseQuantity()
        {
            _quantity--;
        }
    }
}
