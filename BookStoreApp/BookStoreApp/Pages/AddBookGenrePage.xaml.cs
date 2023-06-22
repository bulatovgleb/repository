using BookStoreApp.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBookGenrePage.xaml
    /// </summary>
    public partial class AddBookGenrePage : Page
    {
        // текущий жанр книги
        private BookGenre _currentBookGenre = new BookGenre();
        public AddBookGenrePage(BookGenre selectedBookGenre)
        {
            InitializeComponent();
            LoadAndInitData(selectedBookGenre);
        }
        void LoadAndInitData(BookGenre selectedBookGenre)
        {
            // если передано null, то мы добавляем новый жанр книги
            if (selectedBookGenre != null)
            {
                _currentBookGenre = selectedBookGenre;
            }
            // контекст данных текущего жанра книги
            DataContext = _currentBookGenre;
        }
        /// <summary>
        /// проверка полей ввод на корректные данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (_currentBookGenre.BookGenreName == null)
                s.AppendLine("Заполните «название»");
            return s;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            // проверка полей прошла успешно
            // если жанр книги новый, то его ID == 0
            if (_currentBookGenre.BookGenreID == 0)
            {
                // добавляем раздел в БД
                BookStoreEntities.GetContext().BookGenres.Add(_currentBookGenre);
            }
            try
            {
                BookStoreEntities.GetContext().SaveChanges();  // сохраняем изменения в БД
                MessageBox.Show("Запись изменена");
                Manager.MainFrame.GoBack();  // возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
