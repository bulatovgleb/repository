using BookStoreApp.Models;
using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace BookStoreApp.Windows
{
    public partial class RegisterWindow : Window
    {
        private BookStoreEntities _context;

        public RegisterWindow()
        {
            InitializeComponent();
            _context = BookStoreEntities.GetContext();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Создание нового экземпляра окна входа
            LoginWindow loginWindow = new LoginWindow();

            // Открытие окна входа
            loginWindow.Show();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка полей на содержимое
                StringBuilder errors = CheckFields();
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                // Проверка на уже существующий логин
                if (_context.Clients.Any(c => c.ClientLogin == TbLogin.Text))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                    return;
                }

                // Создание нового клиента
                Client newClient = new Client
                {
                    ClientLogin = TbLogin.Text,
                    ClientPassword = TbPass.Password,
                    ClientSurname = TextBoxClientSurname.Text,
                    ClientName = TextBoxClientName.Text,
                    ClientPatronymic = TextBoxClientPatronymic.Text,
                    ClientAddress = TextBoxClientAddress.Text,
                    ClientPhoneNumber = TextBoxClientPhoneNumber.Text,
                    RoleID = 3
                };

                // Добавление нового клиента в базу данных
                _context.Clients.Add(newClient);

                // Сохранение изменений
                _context.SaveChanges();

                MessageBox.Show("Регистрация успешна");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            // Проверка полей на содержимое
            if (string.IsNullOrWhiteSpace(TbLogin.Text))
                s.AppendLine("Заполните «Логин»");
            if (string.IsNullOrWhiteSpace(TbPass.Password))
                s.AppendLine("Заполните «Пароль»");
            if (string.IsNullOrWhiteSpace(TextBoxClientSurname.Text))
                s.AppendLine("Заполните «Фамилию»");
            if (string.IsNullOrWhiteSpace(TextBoxClientName.Text))
                s.AppendLine("Заполните «Имя»");
            if (string.IsNullOrWhiteSpace(TextBoxClientPatronymic.Text))
                s.AppendLine("Заполните «Отчество»");
            if (string.IsNullOrWhiteSpace(TextBoxClientAddress.Text))
                s.AppendLine("Заполните «Адрес»");
            if (string.IsNullOrWhiteSpace(TextBoxClientPhoneNumber.Text))
                s.AppendLine("Заполните «Телефон»");

            return s;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие окна регистрации
            this.Close();
        }
    }
}
