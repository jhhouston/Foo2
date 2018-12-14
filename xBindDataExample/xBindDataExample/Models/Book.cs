using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBindDataExample.Models
{
    public class Book
    {
        //CLR Object (simple class with properties)
        public int BookId { get; set;}
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }

    //ideally you sperate this to another class that you would call. 
    //This class is delegated to create new instances of book and added them to a collection 
    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();
            {
                //This is the info we will BIND our grid to.
                //First Book instance
                books.Add(new Book { BookId = 1, Title = "Vulpate", Author = "Futurum", CoverImage = "Assets/1.png" });
                books.Add(new Book { BookId = 1, Title = "Mazim", Author = "Sequiter Que", CoverImage = "Assets/2.png" });
                books.Add(new Book { BookId = 1, Title = "Elit", Author = "Tempor", CoverImage = "Assets/3.png" });
                books.Add(new Book { BookId = 1, Title = "Feugait Eros Libex", Author = "Option", CoverImage = "Assets/4.png" });
                books.Add(new Book { BookId = 1, Title = "Nonummy Erat", Author = "Accumsan", CoverImage = "Assets/5.png" });
                books.Add(new Book { BookId = 1, Title = "Nostrud", Author = "Legunt Xaepius", CoverImage = "Assets/6.png" });
                books.Add(new Book { BookId = 1, Title = "Per Modo", Author = "Verpo Tation", CoverImage = "Assets/7.png" });
                books.Add(new Book { BookId = 1, Title = "Script Ad", Author = "Jack Tibbles", CoverImage = "Assets/8.png" });
                books.Add(new Book { BookId = 1, Title = "Decima", Author = "Tuffy Tibbles", CoverImage = "Assets/9.png" });
                books.Add(new Book { BookId = 1, Title = "Erat", Author = "Volupat", CoverImage = "Assets/10.png" });
                books.Add(new Book { BookId = 1, Title = "Consequat", Author = "Est Possim", CoverImage = "Assets/11.png" });
                books.Add(new Book { BookId = 1, Title = "Aliquip", Author = "Magna", CoverImage = "Assets/12.png" });

                return books;
            }
        }
    }

}
