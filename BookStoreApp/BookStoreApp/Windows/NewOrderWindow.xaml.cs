using BookStoreApp.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookStoreApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        Client _currentClient;
        Order _currentOrder;
        public NewOrderWindow()
        {
            InitializeComponent();
            LoadDataAndInit();
        }

        /// <summary>
        /// Загрузка и инициализация полей
        /// </summary>
        void LoadDataAndInit()
        {
            // источник данных корзина
            ListBoxOrderProducts.ItemsSource = Basket.GetBasket;
            // текущий пользователь
            _currentClient = Manager.CurrentUser;
            if (_currentClient != null)
            {
                TextBlockOrderNumber.Text = $"Заказ на имя " +
                    $"{ _currentClient.ClientSurname} {_currentClient.ClientName} {_currentClient.ClientPatronymic}";
            }
            else
            {
                TextBlockOrderNumber.Text = $"Заказ";
            }
            TextBlockTotalCost.Text = $"Итого {Basket.GetTotalCost:C}";
            TextBlockOrderCreateDate.Text = DateTime.Today.ToLongDateString();
            TextBlockOrderDeliveryDate.Text = DateTime.Today.AddDays(3).ToLongDateString();

            TextBlockTotalCost.Text = $"   Итого {Basket.GetTotalCost:C}";
        }

        private void BtnOkClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (ListBoxOrderProducts.SelectedIndex >= 0)
                {
                    var x = (ListBoxOrderProducts.SelectedValue as Book);
                    Basket.DeleteProductFromBasket(x);
                    ListBoxOrderProducts.Items.Refresh();
                    TextBlockTotalCost.Text = $"Итого: {Basket.GetTotalCost:C}";
                }
            }
        }
        // проверка данных в поле количество
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) // при нажатии на кнопку Enter
            {
                TextBox textBox = sender as TextBox;
                int k = ListBoxOrderProducts.SelectedIndex;
                Book book = textBox.Tag as Book;

                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    int x = 0;
                    if (!int.TryParse(textBox.Text, out x))
                    {
                        MessageBox.Show("Количество только число");
                        return;
                    }
                    x = Convert.ToInt32(textBox.Text);
                    if (x < 0)
                    {
                        MessageBox.Show("Количество не может быть отрицательным");
                    }
                    else if (x > book.BookCount)
                    {
                        MessageBox.Show("Количество не может быть больше, чем количество товаров на складе");
                    }
                    else if (x == 0)
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {book.BookName} из корзины???",
                            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.OK)
                        {
                            Basket.DeleteProductFromBasket(book);
                            ListBoxOrderProducts.Items.Refresh();
                            ListBoxOrderProducts.SelectedIndex = k;
                        }
                    }
                    else
                    {
                        Basket.SetCount(book, x);
                        ListBoxOrderProducts.Items.Refresh();
                        ListBoxOrderProducts.SelectedIndex = k;
                    }
                }
            }
            if (e.Key == Key.Escape) // клавиша ESC
            {
                int k = ListBoxOrderProducts.SelectedIndex;
                ListBoxOrderProducts.Items.Refresh();
                ListBoxOrderProducts.SelectedIndex = k;
            }
            TextBlockTotalCost.Text = $"   Итого {Basket.GetTotalCost:C}";
        }

        // в поле количество можно вводить только цифры
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        // кнопка оформить покупку
        private void BtnBuyItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentClient == null) { throw new Exception("В гостевом режиме нельзя сделать заказ"); }
                MessageBoxResult messageBoxResult = MessageBox.Show($"Оформить покупку?",
                    "Оформление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    // формируем данные в таблицу Order (товары заказа)
                    foreach (var item in Basket.GetBasket)
                    {
                        Order order = new Order();
                        order.ClientID = _currentClient.ClientID;
                        order.BookID = item.Key.BookID;
                        order.OrderCount = item.Value.Count;
                        order.OrderCreateDate = DateTime.Now;
                        order.OrderDeliveryDate = DateTime.Now.AddDays(3);
                        order.OrderStatusID = 1;
                        Book book = BookStoreEntities.GetContext().Books.FirstOrDefault(p => p.BookID == item.Key.BookID);
                        if (item.Value.Count >= book.BookCount)
                            book.BookCount = 0;
                        else book.BookCount -= item.Value.Count;
                        BookStoreEntities.GetContext().Orders.Add(order);
                        _currentOrder = order;
                    }
                    BookStoreEntities.GetContext().SaveChanges();  // сохраняем изменения в БД
                                                                   // показываем талон заказа в новом окне 
                    OrderTicketWindow orderTicketWindow = new OrderTicketWindow(_currentOrder);
                    orderTicketWindow.ShowDialog();
                    // очищаем корзину
                    Basket.ClearBasket();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
