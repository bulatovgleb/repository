using BookStoreApp.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        // текущий заказ
        private Order _currentOrder = new Order();
        public AddOrderPage(Order selectedOrder)
        {
            InitializeComponent();
            LoadAndInitData(selectedOrder);
        }
        void LoadAndInitData(Order selectedOrder)
        {
            // если передано null, то мы добавляем новый заказ
            if (selectedOrder != null)
            {
                _currentOrder = selectedOrder;
            }
            // контекст данных текущий заказ
            DataContext = _currentOrder;
            // загрузка в выпадающие списки
            ComboBoxBook.ItemsSource = BookStoreEntities.GetContext().Books.ToList();
            ComboBoxClient.ItemsSource = BookStoreEntities.GetContext().Clients.ToList();
            ComboBoxOrderStatus.ItemsSource = BookStoreEntities.GetContext().OrderStatus.ToList();
        }
        /// <summary>
        /// проверка полей ввод на корректные данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (_currentOrder.Client == null)
                s.AppendLine("Выберите «заказ»");
            if (_currentOrder.Book == null)
                s.AppendLine("Выберите «книгу»");

            if (!string.IsNullOrWhiteSpace(TextBoxOrderCount.Text))
            {
                int x = 0;
                if (!int.TryParse(TextBoxOrderCount.Text, out x))
                    s.AppendLine("Количество только число");
                else if (x < 0)
                    s.AppendLine("Количество не может быть отрицательным");
            }
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
            // если заказ новый, то его ID == 0
            if (_currentOrder.OrderID == 0)
            {
                // добавляем заказ в БД
                BookStoreEntities.GetContext().Orders.Add(_currentOrder);
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
