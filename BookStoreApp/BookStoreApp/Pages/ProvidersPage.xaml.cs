using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProvidersPage.xaml
    /// </summary>
    public partial class ProvidersPage : Page
    {
        public ProvidersPage()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // открытие AddProviderPage для добавления новой записи
            Manager.MainFrame.Navigate(new AddProviderPage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного поставщика из таблицы
            // получаем всех выделенных поставщиков
            var selectedProviders = DataGridProviders.SelectedItems.Cast<Provider>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых поставщиков один элемент
                    Provider x = selectedProviders[0];
                    // проверка, есть ли у выбранного поставщика в таблице «Книги» связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Books.Count > 0)
                        throw new Exception("Есть связанная запись в таблице «Книги», удаление записи невозможно");
                    BookStoreEntities.GetContext().Providers.Remove(x);
                    // сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Provider> providers = BookStoreEntities.GetContext().Providers.OrderBy(p => p.ProviderID).ToList();
                    DataGridProviders.ItemsSource = null;
                    DataGridProviders.ItemsSource = providers;
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
                DataGridProviders.ItemsSource = null;
                // загрузка обновленных данных
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Provider> providers = BookStoreEntities.GetContext().Providers.OrderBy(p => p.ProviderID).ToList();
                DataGridProviders.ItemsSource = providers;
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // открытие редактирования поставщика
            // передача выбранного поставщика в AddProviderPage
            Manager.MainFrame.Navigate(new AddProviderPage((sender as Button).DataContext as Provider));
        }
        // отображение номеров строк в DataGrid
        private void DataGridProviders_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
