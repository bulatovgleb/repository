using BookStoreApp.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProviderPage.xaml
    /// </summary>
    public partial class AddProviderPage : Page
    {
        // текущий поставщик
        private Provider _currentProvider = new Provider();
        public AddProviderPage(Provider selectedProvider)
        {
            InitializeComponent();
            LoadAndInitData(selectedProvider);
        }
        void LoadAndInitData(Provider selectedProvider)
        {
            // если передано null, то мы добавляем нового поставщика
            if (selectedProvider != null)
            {
                _currentProvider = selectedProvider;
            }
            // контекст данных текущего поставщика
            DataContext = _currentProvider;
        }
        /// <summary>
        /// проверка полей ввод на корректные данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (_currentProvider.ProviderName == null)
                s.AppendLine("Заполните «название»");
            if (_currentProvider.ProviderAddress == null)
                s.AppendLine("Заполните «адрес»");
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
            // если поставщик новый, то его ID == 0
            if (_currentProvider.ProviderID == 0)
            {
                // добавляем поставщика в БД
                BookStoreEntities.GetContext().Providers.Add(_currentProvider);
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
