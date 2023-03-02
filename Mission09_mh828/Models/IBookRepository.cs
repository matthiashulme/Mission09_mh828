using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mh828.Models
{
    public class IBookRepository
    {
        public interface IBookRepository
        {
            IQueryable<Book> Books { get; }
        }
    }
}
