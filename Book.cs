using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_LibraryAssignment
{
    internal class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Quantity { get; private set; }

        public Book(string aName, string aAuthor, int aQuantity)
        {
            Name = aName;
            Author = aAuthor;
            Quantity = aQuantity;
        }

        public void DecreaseQuantity()
        {
            this.Quantity--;
        }
    }
}
