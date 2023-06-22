using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
        }
        // отображение номеров строк в DataGrid
        private void DataGridClients_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // открытие AddClientPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddClientPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного клиента из таблицы
            // получаем всех выделенных клиентов
            var selectedClients = DataGridClients.SelectedItems.Cast<Client>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых клиентов один элемент
                    Client x = selectedClients[0];
                    // проверка, есть ли у выбранного клиента в таблице «Заказы» связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Orders.Count > 0)
                        throw new Exception("Есть связанная запись в таблице «Заказы», удаление записи невозможно");
                    BookStoreEntities.GetContext().Clients.Remove(x);
                    // сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Client> clients = BookStoreEntities.GetContext().Clients.OrderBy(p => p.ClientID).ToList();
                    DataGridClients.ItemsSource = null;
                    DataGridClients.ItemsSource = clients;
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
                DataGridClients.ItemsSource = null;
                // загрузка обновленных данных
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Client> clients = BookStoreEntities.GetContext().Clients.OrderBy(p => p.ClientID).ToList();
                DataGridClients.ItemsSource = clients;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // открытие редактирования клиента
            // передача выбранного клиента в AddClientPage
            Manager.MainFrame.Navigate(new AddClientPage((sender as Button).DataContext as Client));
        }
    }
}
