using BookStoreApp.Models;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage : Page
    {
        // текущая книга
        private Book _currentBook = new Book();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // флаг меняется, если фото книги поменялось
        private bool _photoChanged = false;
        // текущая папка приложения
        private static string _currentDirectory =
            Directory.GetCurrentDirectory() + @"\Images\";
        public AddBookPage(Book selectedBook)
        {

            InitializeComponent();
            LoadAndInitData(selectedBook);
        }
        void LoadAndInitData(Book selectedBook)
        {
            // если передано null, то мы добавляем новую книгу
            if (selectedBook != null)
            {
                _currentBook = selectedBook;
                _filePath = _currentDirectory + _currentBook.BookImage;
            }
            // контекст данных текущей книги
            DataContext = _currentBook;
            _photoName = _currentBook.BookImage;
            // загрузка в выпадающие списки
            ComboBookGenre.ItemsSource = BookStoreEntities.GetContext().BookGenres.ToList();
            ComboBookProvider.ItemsSource = BookStoreEntities.GetContext().Providers.ToList();
            ComboPublishingHouse.ItemsSource = BookStoreEntities.GetContext().PublishingHouses.ToList();
            ComboAuthor.ItemsSource = BookStoreEntities.GetContext().Authors.ToList();
        }
        /// <summary>
        /// Проверка полей ввод на корректыне данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrWhiteSpace(_currentBook.BookName))
                s.AppendLine("Поле «имя» пустое");
            if (string.IsNullOrWhiteSpace(_currentBook.BookDescription))
                s.AppendLine("Поле «описание» пустое");
            if (_currentBook.BookGenre == null)
                s.AppendLine("Выберите «раздел»");
            if (_currentBook.Provider == null)
                s.AppendLine("Выберите «поставщика»");
            if (_currentBook.PublishingHouse == null)
                s.AppendLine("Выберите «издательство»");

            if (!string.IsNullOrWhiteSpace(TextBoxBookCount.Text))
            {
                int x = 0;
                if (!int.TryParse(TextBoxBookCount.Text, out x))
                    s.AppendLine("Количество только целое число");
                else if (x < 0)
                    s.AppendLine("Количество не может быть отрицательным");
            }

            if (!string.IsNullOrWhiteSpace(TextBoxBookPrice.Text))
            {
                double x = 0;
                if (!double.TryParse(TextBoxBookPrice.Text, out x))
                    s.AppendLine("Цена только целое число");
                else if (x < 0)
                    s.AppendLine("Цена не может быть отрицательной");
            }
            return s;
        }
        // подбор имени файла
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
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
            // если книга новая, то его ID == 0
            if (_currentBook.BookID == 0)
            {
                // добавление новой книги, 
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    // путь, куда нужно скопировать файл
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentBook.BookImage = photo;
                }
                // добавляем книгу в БД
                BookStoreEntities.GetContext().Books.Add(_currentBook);
            }
            try
            {
                // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentBook.BookImage = photo;
                }
                BookStoreEntities.GetContext().SaveChanges();  // сохраняем изменения в БД
                MessageBox.Show("Запись изменена");
                Manager.MainFrame.GoBack();  // возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        // загрузка фото
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        // размер файла меньше 2Мб, поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                    _photoChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }
    }
}
