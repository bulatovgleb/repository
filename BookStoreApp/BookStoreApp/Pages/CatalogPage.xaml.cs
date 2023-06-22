using BookStoreApp.Models;
using BookStoreApp.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        int _itemcount = 0; // 
        Book _selectedBook = null;
        public CatalogPage()
        {
            InitializeComponent();
            LoadAndInitData();
        }
        void LoadAndInitData()
        {
            // загрузка данных в ComboBoxBookGenre + добавление дополнительной строки
            var bookGenres = BookStoreEntities.GetContext().BookGenres.OrderBy(p => p.BookGenreName).ToList();
            bookGenres.Insert(0, new BookGenre
            {
                BookGenreName = "все"
            }
            );
            ComboBoxBookGenre.ItemsSource = bookGenres;
            ComboBoxBookGenre.SelectedIndex = 0;

            // загрузка данных в ComboBoxPublishingHouse + добавление дополнительной строки
            var publishingHouses = BookStoreEntities.GetContext().PublishingHouses.OrderBy(p => p.PublishingHouseName).ToList();
            publishingHouses.Insert(0, new PublishingHouse
            {
                PublishingHouseName = "все"
            }
            );
            ComboBoxPublishingHouse.ItemsSource = publishingHouses;
            ComboBoxPublishingHouse.SelectedIndex = 0;

            // загрузка данных в ComboBoxAuthor + добавление дополнительной строки
            var authors = BookStoreEntities.GetContext().Authors.OrderBy(p => p.AuthorSurname).ToList();
            authors.Insert(0, new Author
            {
                AuthorSurname = "все"
            }
            );
            ComboBoxAuthor.ItemsSource = authors;
            ComboBoxAuthor.SelectedIndex = 0;

            // загрузка данных в ListBoxBooks сортируем по названию
            ListBoxBooks.ItemsSource = BookStoreEntities.GetContext().Books.OrderBy(p => p.BookName).ToList();
            _itemcount = ListBoxBooks.Items.Count;
            // скрываем кнопки корзины
            BtnBasket.Visibility = Visibility.Collapsed;
            TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
            Basket.ClearBasket();
        }
        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            // получаем текущие данные из бд
            var currentGoods = BookStoreEntities.GetContext().Books.OrderBy(p => p.BookName).ToList();
            // выбор тех товаров, в названии которых есть поисковая строка
            currentGoods = currentGoods.Where(p => p.BookName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.BookPrice).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.BookPrice).ToList();
            }
            // выбор только тех книг, которые принадлежат данному разделу книг
            if (ComboBoxBookGenre.SelectedIndex > 0)
                currentGoods = currentGoods.Where(p => p.BookGenreID == (ComboBoxBookGenre.SelectedItem as BookGenre).BookGenreID).ToList();
            // выбор только тех книг, которые принадлежат данному издательству книг
            if (ComboBoxPublishingHouse.SelectedIndex > 0)
                currentGoods = currentGoods.Where(p => p.PublishingHouseID == (ComboBoxPublishingHouse.SelectedItem as PublishingHouse).PublishingHouseID).ToList();
            // выбор только тех книг, которые принадлежат данному автору книг
            if (ComboBoxAuthor.SelectedIndex > 0)
                currentGoods = currentGoods.Where(p => p.AuthorID == (ComboBoxAuthor.SelectedItem as Author).AuthorID).ToList();

            // в качестве источника данных присваиваем список данных
            ListBoxBooks.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
        }
        private string GetCorrectForm(int count)
        {
            int remainder100 = count % 100;
            int remainder10 = count % 10;

            if (remainder100 >= 11 && remainder100 <= 19)
                return "товаров";
            if (remainder10 == 1)
                return "товар";
            if (remainder10 >= 2 && remainder10 <= 4)
                return "товара";

            return "товаров";
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // контекстное меню по нажатию правой кнопки мыши
            // если товар не выбран, завершаем работу
            if (_selectedBook == null)
                return;
            // добавляем товар в корзину
            Basket.AddProductInBasket(_selectedBook);
            // отображаем кнопку и текстовое поле
            if (Basket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Text = $"В корзине {Basket.GetCount} {GetCorrectForm(Basket.GetCount)}";
            }
        }
        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // получаем все выделенные товары
            _selectedBook = null;
            var selected = ListBoxBooks.SelectedItems.Cast<Book>().ToList();
            if (selected.Count == 0) return;
            _selectedBook = selected[0];
        }
        private void BtnBasket_Click(object sender, RoutedEventArgs e)
        {
            // кнопка Корзина
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            newOrderWindow.ShowDialog();
            if (Basket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBasket.Visibility = Visibility.Collapsed;
                TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            }
        }
        private void ComboBoxBookGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void ComboBoxPublishingHouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // обновление данных после каждой активации окна
            if (Visibility == Visibility.Visible)
            {
                BookStoreEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListBoxBooks.ItemsSource = BookStoreEntities.GetContext().Books.OrderBy(p => p.BookName).ToList();
            }

        }
        // поиск товаров, которые содержат данную поисковую строку
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        // сортировка товаров 
        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboBoxAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
    }
}
