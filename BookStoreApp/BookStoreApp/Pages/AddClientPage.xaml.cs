using BookStoreApp.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace BookStoreApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        // текущий клиент
        private Client _currentClient = new Client();
        public AddClientPage(Client selectedClient)
        {
            InitializeComponent();
            LoadAndInitData(selectedClient);
        }
        void LoadAndInitData(Client selectedClient)
        {
            // если передано null, то мы добавляем нового клиента
            if (selectedClient != null)
            {
                _currentClient = selectedClient;
            }
            // контекст данных текущий клиент
            DataContext = _currentClient;
            // загрузка в выпадающие списки
            ComboBoxRole.ItemsSource = BookStoreEntities.GetContext().Roles.ToList();
        }
        /// <summary>
        /// проверка полей ввод на корректные данные
        /// </summary>
        /// <returns>текст StringBuilder содержащий ошибки, если они есть</returns>
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // проверка полей на содержимое
            if (string.IsNullOrWhiteSpace(_currentClient.ClientLogin))
                s.AppendLine("Поле «логин» пустое");
            if (string.IsNullOrWhiteSpace(_currentClient.ClientPassword))
                s.AppendLine("Поле «пароль» пустое");
            if (string.IsNullOrWhiteSpace(_currentClient.ClientSurname))
                s.AppendLine("Поле «фамилия» пустое");
            if (string.IsNullOrWhiteSpace(_currentClient.ClientName))
                s.AppendLine("Поле «имя» пустое");
            if (_currentClient.Role == null)
                s.AppendLine("Выберите роль");
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
            // если клиент новый, то его ID == 0
            if (_currentClient.ClientID == 0)
            {
                // добавление нового клиента, 
                // добавляем клиента в БД
                BookStoreEntities.GetContext().Clients.Add(_currentClient);
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
