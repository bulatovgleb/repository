using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для BooksPage.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        private List<Book> books;

        public BooksPage()
        {
            InitializeComponent();
            LoadBooks();
        }
        private void LoadBooks()
        {
            books = BookStoreEntities.GetContext().Books.OrderBy(p => p.BookID).ToList();
            DataGridBooks.ItemsSource = books;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // открытие AddBookPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddBookPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранной книги из таблицы
            // получаем все выделенные книги
            var selectedBooks = DataGridBooks.SelectedItems.Cast<Book>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых книг один элемент
                    Book x = selectedBooks[0];
                    // проверка, есть ли у выбранной книги в таблице «Заказы» связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Orders.Count > 0)
                        throw new Exception("Есть связанная запись в таблице «Заказы», удаление записи невозможно");

                    BookStoreEntities.GetContext().Books.Remove(x);
                    // сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Book> books = BookStoreEntities.GetContext().Books.OrderBy(p => p.BookName).ToList();
                    DataGridBooks.ItemsSource = null;
                    DataGridBooks.ItemsSource = books;
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
                DataGridBooks.ItemsSource = null;
                // загрузка обновленных данных
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Book> books = BookStoreEntities.GetContext().Books.OrderBy(p => p.BookID).ToList();
                DataGridBooks.ItemsSource = books;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // открытие редактирования книги
            // передача выбранной книги в AddBookPage
            Manager.MainFrame.Navigate(new AddBookPage((sender as Button).DataContext as Book));
        }
        // отображение номеров строк в DataGrid
        private void DataGridBooks_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TbSearchID.Text.Trim();
            List<Book> searchResults = new List<Book>();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Введите значение для поиска.");
                return;
            }

            string searchType = (CmbSearchType.SelectedItem as ComboBoxItem)?.Content.ToString();

            switch (searchType)
            {
                case "Поиск по ID":
                    if (int.TryParse(searchTerm, out int searchID))
                    {
                        searchResults = books.Where(b => b.BookID == searchID).ToList();
                    }
                    break;
                case "Поиск по названию":
                    searchResults = books.Where(b => b.BookName.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                case "Поиск по автору":
                    searchResults = books.Where(b => b.Author.AuthorSurname.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                default:
                    MessageBox.Show("Выберите тип поиска.");
                    return;
            }

            DataGridBooks.ItemsSource = searchResults;
        }

        private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Очистить поиск"
            TbSearchID.Clear();
            CmbSearchType.SelectedIndex = 0;
            LoadBooks(); // Восстанавливаем исходный список заказов
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlSheet = null;

            try
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "Books.xlsx";
                xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                xlSheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                xlSheet.Name = "Список книг";

                int row = 1;
                int i = 0;

                // Заголовки столбцов
                xlSheet.Cells[row, 1] = "ID";
                xlSheet.Cells[row, 2] = "Название";
                xlSheet.Cells[row, 3] = "Описание";
                xlSheet.Cells[row, 4] = "Раздел";
                xlSheet.Cells[row, 5] = "Поставщик";
                xlSheet.Cells[row, 6] = "Издательство";
                xlSheet.Cells[row, 7] = "Автор";
                xlSheet.Cells[row, 8] = "ISBN";
                xlSheet.Cells[row, 9] = "Количество";
                xlSheet.Cells[row, 10] = "Цена";

                row++;

                if (DataGridBooks.Items.Count > 0)
                {
                    for (i = 0; i < DataGridBooks.Items.Count; i++)
                    {
                        Book book = DataGridBooks.Items[i] as Book;

                        xlSheet.Cells[row, 1] = book.BookID.ToString();
                        xlSheet.Cells[row, 2] = book.BookName;
                        xlSheet.Cells[row, 3] = book.BookDescription;
                        xlSheet.Cells[row, 4] = book.BookGenre.BookGenreName;
                        xlSheet.Cells[row, 5] = book.Provider.ProviderName;
                        xlSheet.Cells[row, 6] = book.PublishingHouse.PublishingHouseName;
                        xlSheet.Cells[row, 7] = book.Author.AuthorSurname + " " + book.Author.AuthorName + " " + book.Author.AuthorPatronymic;

                        Excel.Range isbnCell = xlSheet.Cells[row, 8];
                        isbnCell.NumberFormat = "0"; // Задаем формат без десятичных
                        isbnCell.Value = book.BookISBN;

                        xlSheet.Cells[row, 9] = book.BookCount.ToString();
                        xlSheet.Cells[row, 10] = book.BookPrice.ToString();

                        row++;
                    }
                }

                xlSheet.Columns.AutoFit();
                xlSheet.Rows.AutoFit();

                xlWorkbook.SaveAs(fileName);
                xlWorkbook.Close();

                MessageBox.Show("Данные успешно экспортированы в Excel.");

                // Открытие файла после успешного экспорта
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка экспорта данных в Excel: " + ex.Message);
            }
            finally
            {
                // Блок finally, который гарантирует выполнение кода при выходе из блока try-catch-finally.

                if (xlSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet);
                // Проверка, что переменная xlSheet не является пустой, а затем освобождение ресурсов, связанных с xlSheet.

                if (xlWorkbook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                // Проверка, что переменная xlWorkbook не является пустой, а затем освобождение ресурсов, связанных с xlWorkbook.

                if (xlApp != null)
                {
                    xlApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                }
                // Проверка, что переменная xlApp не является пустой, а затем вызов метода Quit() для закрытия приложения, связанного с xlApp.
                // Затем освобождение ресурсов, связанных с xlApp.
            }
        }
    }
}
