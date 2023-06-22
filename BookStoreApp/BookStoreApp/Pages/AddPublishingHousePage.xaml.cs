using BookStoreApp.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPublishingHousePage.xaml
    /// </summary>
    public partial class AddPublishingHousePage : Page
    {
        // текущее издательство
        private PublishingHouse _currentPublishingHouse = new PublishingHouse();
        public AddPublishingHousePage(PublishingHouse selectedPublishingHouse)
        {
            InitializeComponent();
            LoadAndInitData(selectedPublishingHouse);
        }
        void LoadAndInitData(PublishingHouse selectedPublishingHouse)
        {
            // если передано null, то мы добавляем новое издательство
            if (selectedPublishingHouse != null)
            {
                _currentPublishingHouse = selectedPublishingHouse;
            }
            // контекст данных текущего издательства
            DataContext = _currentPublishingHouse;
        }
        /// <summary>
        /// проверка полей ввод на корректные данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (_currentPublishingHouse.PublishingHouseName == null)
                s.AppendLine("Заполните «название»");
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
            // если издательство новое, то его ID == 0
            if (_currentPublishingHouse.PublishingHouseID == 0)
            {
                // добавляем издательство в БД
                BookStoreEntities.GetContext().PublishingHouses.Add(_currentPublishingHouse);
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
