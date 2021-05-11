using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Authorization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            InputLogin.Clear();
            InputPassword.Clear();

            LabelShow.Text = string.Empty;
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckEnabledButtonAuthorization()
        {
            if (InputLogin.Text != string.Empty && InputPassword.Password != string.Empty)
            {
                ButtonAuthorization.IsEnabled = true;
            }
            else
            {
                ButtonAuthorization.IsEnabled = false;
            }
        }
        private void InputLogin_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEnabledButtonAuthorization();
        }

        private void InputPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckEnabledButtonAuthorization();
        }

        private void ButtonAuthorization_OnClick(object sender, RoutedEventArgs e)
        {
            var login = "123";
            var password = "123";

            var inputLogin = InputLogin.Text;
            var inputPassword = InputPassword.Password;

            if (inputLogin == login && inputPassword == password)
            {
                LabelShow.Foreground = Brushes.Green;
                LabelShow.Text = "Авторизация прошла успешно";
            }
            else
            {
                LabelShow.Foreground = Brushes.Red;
                LabelShow.Text = "Неверный логин или пароль";
            }
        }

        private void HyperSignUp_OnClick(object sender, RoutedEventArgs e)
        {
            var regForm = new Registration();
            regForm.Show();
            
            Close();
        }
    }
}