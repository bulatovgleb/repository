using System.IO;

// пространство имен такое же как и у BookStoreEntities из папки Models
namespace BookStoreApp.Models
{
    // класс Book public - публичный
    // partial - частичный, т.е. его часть в другом файле
    public partial class Book
    {
        /// <summary>
        /// Возвращает абсолютный путь к изображению
        /// </summary>
        public string GetPhoto
        {
            get
            {
                if (BookImage is null)
                    return Directory.GetCurrentDirectory() + @"\Images\picture.png";
                return Directory.GetCurrentDirectory() + @"\Images\" + BookImage.Trim();
            }
        }
        /// <summary>
        /// Количество товара на складе
        /// </summary>
        public string GetCountInStock
        {
            get
            {
                return $"в наличии на складе {BookCount}";
            }
        }
    }
}

