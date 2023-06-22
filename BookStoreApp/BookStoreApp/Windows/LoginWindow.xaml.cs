using BookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BookStoreApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            TbLogin.Text = "bulatov";
            TbPass.Password = "password4";
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Client> clients = BookStoreEntities.GetContext().Clients.ToList();
                Client client = clients.FirstOrDefault(p => p.ClientPassword == TbPass.Password && p.ClientLogin == TbLogin.Text);
                if (client != null)
                {
                    Manager.CurrentUser = client;
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Owner = this;
                    this.Hide(); // скрываем форму авторизации
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        // код кнопки Cancel
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        // попытка закрыть приложение
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // на экране отображается форма с двумя кнопками
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите закрыть приложение?",
           "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        private void BtnGuestMode_Click(object sender, RoutedEventArgs e)
        {
            // вход в режиме гостя
            Manager.CurrentUser = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = this;
            this.Hide();
            mainWindow.Show();
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Создание нового экземпляра окна регистрации
            RegisterWindow registerWindow = new RegisterWindow();

            // Открытие окна регистрации
            registerWindow.Show();

            // Скрытие текущего окна входа
            this.Hide();
        }
    }
}
