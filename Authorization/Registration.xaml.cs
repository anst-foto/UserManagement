using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Authorization
{
    public partial class Registration : Window
    {
        private bool _isNotEmptyLogin;
        private bool _isNotEmptyPassword;
        private bool _isEqualPasswords;
        private bool _isNotEmptyEmail;
        private bool _isCheckPassword;
        
        public Registration()
        {
            InitializeComponent();

            _isNotEmptyLogin = false;
            _isEqualPasswords = false;
            _isNotEmptyPassword = false;
            _isNotEmptyEmail = false;
            _isCheckPassword = false;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void HyperSignIn_OnClick(object sender, RoutedEventArgs e)
        {
            var authForm = new MainWindow();
            authForm.Show();
            
            Close();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonClear_OnClick(object sender, RoutedEventArgs e)
        {
            InputLogin.Clear();
            InputPassword_1.Clear();
            InputPassword_2.Clear();
            InputEmail.Clear();

            LabelShow.Text = string.Empty;
        }

        private void InputPassword_1_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckEmptyPasswords();
            
            CorrectedInput();
        }

        private void InputPassword_2_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckEmptyPasswords();
            
            CorrectedInput();
        }

        private void CheckEmptyPasswords()
        {
            if (InputPassword_1.Password == string.Empty && InputPassword_2.Password == string.Empty)
            {
                LabelShow.Foreground = Brushes.Red;
                LabelShow.Text = string.Empty;

                _isNotEmptyPassword = false;
            }
            else
            {
                _isNotEmptyPassword = true;
                
                CheckEqualPasswords();
            }
        }

        private void CheckEqualPasswords()
        {
            if (InputPassword_1.Password == InputPassword_2.Password)
            {
                LabelShow.Foreground = Brushes.Green;
                LabelShow.Text = "Пароли совпадают";

                _isEqualPasswords = true;
            }
            else
            {
                LabelShow.Foreground = Brushes.Red;
                LabelShow.Text = "Пароли не совпадают";

                _isEqualPasswords = false;
            }

        }

        private void InputLogin_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _isNotEmptyLogin = InputLogin.Text != string.Empty;
            
            CorrectedInput();
        }

        private void CorrectedInput()
        {
            if (_isNotEmptyLogin && _isEqualPasswords && _isNotEmptyPassword && _isNotEmptyEmail)
            {
                ButtonRegistration.IsEnabled = true;
            }
            else
            {
                ButtonRegistration.IsEnabled = false;
            }
        }

        private void InputEmail_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _isNotEmptyEmail = InputEmail.Text != string.Empty;
            
            CorrectedInput();
        }
    }
}