using System;
using System.Collections.Generic;

namespace BookStoreApp.Models
{
    /// <summary>
    /// Класс корзина, содержит список покупок
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// Value словаря - количество товара и стоимость
        /// </summary>
        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }
        }
        /// <summary>
        /// Словарь хранит товар в качестве ключа и BuyItem в качестве значения
        /// </summary>
        public static Dictionary<Book, BuyItem> GetBasket { get; } = new Dictionary<Book, BuyItem>();

        // очистка корзины
        public static void ClearBasket()
        {
            GetBasket.Clear();
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="product">Добавляемый товар</param>
        public static void AddProductInBasket(Book book)
        {
            // если такой товар есть в корзине
            if (GetBasket.ContainsKey(book))
            {
                // увеличиваем его количество на +1
                int k = GetBasket[book].Count + 1;
                // пересчистваем стоимость
                double p = Convert.ToDouble(book.BookPrice) * k;
                GetBasket[book] = new BuyItem { Count = k, Total = p };
            }
            else
            {
                // добавляем новый товар в корзину в количесьве 1 шт
                double p = Convert.ToDouble(book.BookPrice);
                GetBasket[book] = new BuyItem { Count = 1, Total = p };
            }
        }
        /// <summary>
        /// Изменяет количество товара product в корзине
        /// </summary>
        /// <param name="product">Товар</param>
        /// <param name="count">количество товара</param>
        public static void SetCount(Book book, int count)
        {
            if (GetBasket.ContainsKey(book))
            {
                int k = count;
                double p = Convert.ToDouble(book.BookPrice) * k;
                GetBasket[book] = new BuyItem { Count = k, Total = p };
                // если количество 0 или меньше 0 удаляем товар из корзины
                if (k <= 0)
                {
                    GetBasket.Remove(book);
                }
            }
        }

        /// <summary>
        /// Удаляем товар product из корзины
        /// </summary>
        /// <param name="product">Удаляемый товар</param>
        public static void DeleteProductFromBasket(Book book)
        {
            if (GetBasket.ContainsKey(book))
            {
                GetBasket.Remove(book);
            }
        }

        /// <summary>
        /// Cтоимость всех товаров в корзине
        /// </summary>
        public static double GetTotalCost
        {
            get
            {
                double sum = 0;
                foreach (var item in GetBasket)
                {
                    sum += item.Value.Total;
                }
                return sum;
            }
        }
        /// <summary>
        /// Количество товаров в корзине
        /// </summary>
        public static int GetCount
        {
            get
            {
                return GetBasket.Count;
            }
        }
    }
}
