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
    public partial class OrdersPage : Page
    {
        private List<Order> orders; // Хранит список заказов для использования в сортировке и поиске

        public OrdersPage()
        {
            InitializeComponent();
            LoadOrders(); // Загружаем список заказов при инициализации страницы
        }

        // Метод загрузки заказов и привязки к DataGrid
        private void LoadOrders()
        {
            orders = BookStoreEntities.GetContext().Orders.OrderBy(p => p.OrderID).ToList();
            DataGridOrders.ItemsSource = orders;
        }

        // Отображение номеров строк в DataGrid
        private void DataGridOrders_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Открытие AddOrderPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddOrderPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Удаление выбранного заказа из таблицы
            // Получаем все выделенные заказы
            var selectedOrders = DataGridOrders.SelectedItems.Cast<Order>().ToList();
            // Вывод сообщения с вопросом "Удалить запись?"
            MessageBoxResult messageBoxResult = MessageBox.Show("Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // Если пользователь нажал "ОК", пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // Берем из списка удаляемых заказов один элемент
                    Order x = selectedOrders[0];
                    BookStoreEntities.GetContext().Orders.Remove(x);
                    // Сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена");
                    LoadOrders(); // Перезагружаем список заказов после удаления
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Событие отображения данной страницы
            // Обновляем данные каждый раз, когда активируется эта страница
            if (Visibility == Visibility.Visible)
            {
                LoadOrders(); // Перезагружаем список заказов
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Открытие редактирования заказа
            // Передача выбранного заказа в AddOrderPage
            Manager.MainFrame.Navigate(new AddOrderPage((sender as Button).DataContext as Order));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = TbSearchID.Text.Trim();
            List<Order> searchResults = new List<Order>();

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
                        searchResults = orders.Where(o => o.OrderID == searchID).ToList();
                    }
                    break;
                case "Поиск по фамилии клиента":
                    searchResults = orders.Where(o => o.Client.ClientSurname.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                case "Поиск по дате подачи заявки":
                    if (DateTime.TryParse(searchTerm, out DateTime searchDate))
                    {
                        searchResults = orders.Where(o => o.OrderCreateDate.Date == searchDate.Date).ToList();
                    }
                    break;
                case "Поиск по номеру телефона":
                    searchResults = orders.Where(o => o.Client.ClientPhoneNumber.ToLower().Contains(searchTerm.ToLower())).ToList();
                    break;
                default:
                    MessageBox.Show("Выберите тип поиска.");
                    return;
            }

            DataGridOrders.ItemsSource = searchResults;
        }

        private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Очистить поиск"
            TbSearchID.Clear();
            CmbSearchType.SelectedIndex = 0;
            LoadOrders(); // Восстанавливаем исходный список заказов
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = null;
            Excel.Worksheet xlSheet = null;

            try
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "Orders.xlsx";
                xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                xlSheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                xlSheet.Name = "Список заявок";

                int row = 1;
                int i = 0;

                // Заголовки столбцов
                xlSheet.Cells[row, 1] = "ID";
                xlSheet.Cells[row, 2] = "Фамилия";
                xlSheet.Cells[row, 3] = "Имя";
                xlSheet.Cells[row, 4] = "Отчество";
                xlSheet.Cells[row, 5] = "Адрес";
                xlSheet.Cells[row, 6] = "Номер телефона";
                xlSheet.Cells[row, 7] = "Название книги";
                xlSheet.Cells[row, 8] = "Количество";
                xlSheet.Cells[row, 9] = "Дата создания";
                xlSheet.Cells[row, 10] = "Дата доставки";
                xlSheet.Cells[row, 11] = "Статус";

                row++;

                if (DataGridOrders.Items.Count > 0)
                {
                    for (i = 0; i < DataGridOrders.Items.Count; i++)
                    {
                        Order order = DataGridOrders.Items[i] as Order;

                        xlSheet.Cells[row, 1] = order.OrderID.ToString();
                        xlSheet.Cells[row, 2] = order.Client.ClientSurname;
                        xlSheet.Cells[row, 3] = order.Client.ClientName;
                        xlSheet.Cells[row, 4] = order.Client.ClientPatronymic;
                        xlSheet.Cells[row, 5] = order.Client.ClientAddress;
                        xlSheet.Cells[row, 6] = order.Client.ClientPhoneNumber;
                        xlSheet.Cells[row, 7] = order.Book.BookName;
                        xlSheet.Cells[row, 8] = order.OrderCount.ToString();
                        xlSheet.Cells[row, 9] = order.OrderCreateDate.ToString("dd.MM.yyyy");
                        xlSheet.Cells[row, 10] = order.OrderDeliveryDate.ToString("dd.MM.yyyy");
                        xlSheet.Cells[row, 11] = order.OrderStatu.OrderStatusName;
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
