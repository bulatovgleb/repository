using System.Data.Entity; // нужно добавить для контекста

// пространство имен такое же как и у BookStoreEntities из папки Models
namespace BookStoreApp.Models
{
    // класс BookStoreEntities public - публичный
    // partial - частичный, т.е. его часть в другом файле
    // унаследован от класса DbContext
    public partial class BookStoreEntities : DbContext
    {
        private static BookStoreEntities _context;
        /// <summary>
        /// Метод возвращающий контекст подключения
        /// </summary>
        /// <returns></returns>
        public static BookStoreEntities GetContext()
        {
            if (_context == null)
            {
                _context = new BookStoreEntities();
            }
            return _context;
        }
    }
}