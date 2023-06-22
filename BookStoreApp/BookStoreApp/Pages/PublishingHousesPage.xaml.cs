using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PublishingHousesPage.xaml
    /// </summary>
    public partial class PublishingHousesPage : Page
    {
        public PublishingHousesPage()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // открытие AddPublishingHousePage для добавления новой записи
            Manager.MainFrame.Navigate(new AddPublishingHousePage(null));
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранной роли из таблицы
            // получаем всех выделенных ролей
            var selectedPublishingHouses = DataGridPublishingHouses.SelectedItems.Cast<PublishingHouse>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись?",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            // если пользователь нажал ОК, пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых ролей один элемент
                    PublishingHouse x = selectedPublishingHouses[0];
                    // проверка, есть ли у выбранного издательства в таблице «Книги» связанные записи
                    // если да, то выбрасывается исключение и удаление прерывается
                    if (x.Books.Count > 0)
                        throw new Exception("Есть связанная запись в таблице «Книги», удаление записи невозможно");
                    BookStoreEntities.GetContext().PublishingHouses.Remove(x);
                    // сохраняем изменения
                    BookStoreEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<PublishingHouse> publishingHouses = BookStoreEntities.GetContext().PublishingHouses.OrderBy(p => p.PublishingHouseID).ToList();
                    DataGridPublishingHouses.ItemsSource = null;
                    DataGridPublishingHouses.ItemsSource = publishingHouses;
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
                DataGridPublishingHouses.ItemsSource = null;
                // загрузка обновленных данных
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<PublishingHouse> publishingHouses = BookStoreEntities.GetContext().PublishingHouses.OrderBy(p => p.PublishingHouseID).ToList();
                DataGridPublishingHouses.ItemsSource = publishingHouses;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // открытие редактирования роли
            // передача выбранной роли в AddPublishingHousePage
            Manager.MainFrame.Navigate(new AddPublishingHousePage((sender as Button).DataContext as PublishingHouse));
        }
        // отображение номеров строк в DataGrid
        private void DataGridPublishingHouses_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
