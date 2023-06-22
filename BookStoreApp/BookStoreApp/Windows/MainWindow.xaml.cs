using BookStoreApp.Models;
using BookStoreApp.Pages;
using System;
using System.Windows;

namespace BookStoreApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Client _currentUser; //текущий пользователь в системе
        public MainWindow()
        {
            InitializeComponent();
            LoadData();

        }
        /// <summary>
        /// загружаем данные и инициализируем переменные
        /// </summary>
        void LoadData()
        {
            _currentUser = Manager.CurrentUser;
            if (_currentUser != null)
            {
                TextBlockName.Text = $"Вы вошли как: {_currentUser.ClientSurname} {_currentUser.ClientName} {_currentUser.ClientPatronymic}";
            }
            MainFrame.Navigate(new CatalogPage());
            Manager.MainFrame = MainFrame;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            // показать владельца формы
            Owner.Show();
            // или если надо, то можно закрыть приложение  командой
            // App.Current.Shutdown();
        }
        //событие попытки закрытия окна,
        // если пользователь выберет Cancel, то форму не закроем
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти?",
                "Выйти", MessageBoxButton.OKCancel,
                MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        // Событие отрисовки страницы
        // Скрываем или показываем кнопку Назад 
        // Скрываем или показываем кнопки Для перехода к остальным страницам
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            // проверяем кто вошел систему
            if (_currentUser == null || _currentUser.RoleID == 3) // клиент или гость
            {

                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditBooks.Visibility = Visibility.Collapsed;
                    BtnEditClients.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                    BtnEditPublishingHouses.Visibility = Visibility.Collapsed;
                    BtnEditProviders.Visibility = Visibility.Collapsed;
                    BtnEditBookGenres.Visibility = Visibility.Collapsed;
                    BtnEditAuthors.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditBooks.Visibility = Visibility.Collapsed;
                    BtnEditClients.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                    BtnEditPublishingHouses.Visibility = Visibility.Collapsed;
                    BtnEditProviders.Visibility = Visibility.Collapsed;
                    BtnEditBookGenres.Visibility = Visibility.Collapsed;
                    BtnEditAuthors.Visibility = Visibility.Collapsed;
                }
                return;
            }
            if (_currentUser.RoleID == 2) // менеджер
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditBooks.Visibility = Visibility.Collapsed;
                    BtnEditClients.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                    BtnEditPublishingHouses.Visibility = Visibility.Collapsed;
                    BtnEditProviders.Visibility = Visibility.Collapsed;
                    BtnEditBookGenres.Visibility = Visibility.Collapsed;
                    BtnEditAuthors.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditBooks.Visibility = Visibility.Visible;
                    BtnEditClients.Visibility = Visibility.Visible;
                    BtnEditOrders.Visibility = Visibility.Visible;
                    BtnEditPublishingHouses.Visibility = Visibility.Visible;
                    BtnEditProviders.Visibility = Visibility.Visible;
                    BtnEditBookGenres.Visibility = Visibility.Visible;
                    BtnEditAuthors.Visibility = Visibility.Visible;
                }
                return;
            }
            if (_currentUser.RoleID == 1) // админ
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditBooks.Visibility = Visibility.Collapsed;
                    BtnEditClients.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                    BtnEditPublishingHouses.Visibility = Visibility.Collapsed;
                    BtnEditProviders.Visibility = Visibility.Collapsed;
                    BtnEditBookGenres.Visibility = Visibility.Collapsed;
                    BtnEditAuthors.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditBooks.Visibility = Visibility.Visible;
                    BtnEditClients.Visibility = Visibility.Visible;
                    BtnEditOrders.Visibility = Visibility.Visible;
                    BtnEditPublishingHouses.Visibility = Visibility.Visible;
                    BtnEditProviders.Visibility = Visibility.Visible;
                    BtnEditBookGenres.Visibility = Visibility.Visible;
                    BtnEditAuthors.Visibility = Visibility.Visible;
                }
                return;
            }
        }

        private void BtnEditBooks_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BooksPage());
        }

        private void BtnEditClients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsPage());
        }

        private void BtnEditOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OrdersPage());
        }

        private void BtnEditPublishingHouses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PublishingHousesPage());
        }

        private void BtnEditProviders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProvidersPage());
        }

        private void BtnEditBookGenres_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BookGenresPage());
        }

        private void BtnEditAuthors_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuthorsPage());
        }
        // кнопка назад
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try { Manager.MainFrame.GoBack(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
