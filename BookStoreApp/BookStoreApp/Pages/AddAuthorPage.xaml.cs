using BookStoreApp.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAuthorPage.xaml
    /// </summary>
    public partial class AddAuthorPage : Page
    {
        // текущий автор
        private Author _currentAuthor = new Author();
        public AddAuthorPage(Author selectedAuthor)
        {
            InitializeComponent();
            LoadAndInitData(selectedAuthor);
        }
        void LoadAndInitData(Author selectedAuthor)
        {
            // если передано null, то мы добавляем нового автора
            if (selectedAuthor != null)
            {
                _currentAuthor = selectedAuthor;
            }
            // контекст данных текущий автор
            DataContext = _currentAuthor;
        }
        /// <summary>
        /// проверка полей ввод на корректные данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrWhiteSpace(_currentAuthor.AuthorSurname))
                s.AppendLine("Поле «фамилия» пустое");
            if (string.IsNullOrWhiteSpace(_currentAuthor.AuthorName))
                s.AppendLine("Поле «имя» пустое");
            if (_currentAuthor.AuthorDateOfBirth == null)
                s.AppendLine("Выберите дату рождения");
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
            // если автор новый, то его ID == 0
            if (_currentAuthor.AuthorID == 0)
            {
                // добавление нового автора, 
                // добавляем автора в БД
                BookStoreEntities.GetContext().Authors.Add(_currentAuthor);
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
