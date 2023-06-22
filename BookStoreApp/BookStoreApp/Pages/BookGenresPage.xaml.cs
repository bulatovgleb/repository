using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookGenresPage.xaml
    /// </summary>
    public partial class BookGenresPage : Page
    {
        public BookGenresPage()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // открытие AddBookGenrePage для добавления новой записи
            Manager.MainFrame.Navigate(new AddBookGenrePage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного раздела из таблицы
            // получаем все выделенные разделы
            var selectedBookGenres = DataGridBookGenres.SelectedItems.Cast<BookGenre>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых разделов один элемент
                    BookGenre x = selectedBookGenres[0];
                    // проверка, есть ли у выбранного жанра книги в таблице «Книги» связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Books.Count > 0)
                        throw new Exception("Есть связанная запись в таблице «Книги», удаление записи невозможно");
                    BookStoreEntities.GetContext().BookGenres.Remove(x);
                    // сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<BookGenre> bookGenres = BookStoreEntities.GetContext().BookGenres.OrderBy(p => p.BookGenreID).ToList();
                    DataGridBookGenres.ItemsSource = null;
                    DataGridBookGenres.ItemsSource = bookGenres;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // событие отображения данного Page
            // обновляем данные каждый раз, когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                DataGridBookGenres.ItemsSource = null;
                // загрузка обновленных данных
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<BookGenre> bookGenres = BookStoreEntities.GetContext().BookGenres.OrderBy(p => p.BookGenreID).ToList();
                DataGridBookGenres.ItemsSource = bookGenres;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // открытие редактирования раздела
            // передача выбранного раздела в AddBookGenrePage
            Manager.MainFrame.Navigate(new AddBookGenrePage((sender as Button).DataContext as BookGenre));
        }
        // отображение номеров строк в DataGrid
        private void DataGridBookGenres_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
