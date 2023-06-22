using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {
        public AuthorsPage()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // открытие AddAuthorPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddAuthorPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного автора из таблицы
            // получаем всех выделенных авторов
            var selectedAuthors = DataGridAuthors.SelectedItems.Cast<Author>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых авторов один элемент
                    Author x = selectedAuthors[0];
                    // проверка, есть ли у выбранного автора книги в таблице «Книги» связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Books.Count > 0)
                        throw new Exception("Есть связанная запись в таблице «Книги», удаление записи невозможно");
                    BookStoreEntities.GetContext().Authors.Remove(x);
                    // сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Author> authors = BookStoreEntities.GetContext().Authors.OrderBy(p => p.AuthorID).ToList();
                    DataGridAuthors.ItemsSource = null;
                    DataGridAuthors.ItemsSource = authors;
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
                DataGridAuthors.ItemsSource = null;
                // загрузка обновленных данных
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Author> authors = BookStoreEntities.GetContext().Authors.OrderBy(p => p.AuthorID).ToList();
                DataGridAuthors.ItemsSource = authors;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // открытие редактирования автора
            // передача выбранного автора в AddAuthorPage
            Manager.MainFrame.Navigate(new AddAuthorPage((sender as Button).DataContext as Author));
        }
        // отображение номеров строк в DataGrid
        private void DataGridAuthors_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
