using System.Windows.Controls;

namespace BookStoreApp.Models
{
    public class Manager
    {
        /// <summary>
        /// Фрейм, в котором отображаются Page
        /// </summary>
        public static Frame MainFrame { get; set; }
        /// <summary>
        /// Текущий пользователь системы
        /// </summary>
        public static Client CurrentUser { get; set; }
    }
}
