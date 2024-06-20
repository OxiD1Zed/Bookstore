using Bookstore.common.presentation;
using System;
using System.Windows.Forms;

namespace Bookstore.features.auth
{
    public partial class AuthScreen : UserControl
    {
        private readonly AuthViewModel _viewModel;

        public AuthScreen(AuthViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonReg_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (!_viewModel.IsValidLogin(textBoxLogin.Text))
            {
                errorValidatingLogin.SetError(textBoxLogin, "Некорректный логин (пример: example@mail.ru)");
                isValid = false;
            }
            else
            {
                errorValidatingLogin.Clear();
            }

            if (!_viewModel.IsValidPasswordReg(textBoxPassword.Text))
            {
                errorValidatingPassword.SetError(textBoxPassword, "Пароль должен содержать:\nСимвол в верхнем регистре\nСимвол в нижнем регистре\nЦирфу\nСпециальный символ\n8 символов");
                isValid = false;
            }
            else
            {
                errorValidatingPassword.Clear();
            }

            if (isValid)
            {
                Handlers.ViewHandler(() => _viewModel.Reg(textBoxLogin.Text, textBoxPassword.Text));
            }
        }

        private void ButtonSigin_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (!_viewModel.IsValidLogin(textBoxLogin.Text))
            {
                errorValidatingLogin.SetError(textBoxLogin, "Некорректный логин (пример: example@mail.ru)");
                isValid = false;
            }
            else 
            {
                errorValidatingLogin.Clear();
            }

            if(!_viewModel.IsValidPasswordSigin(textBoxPassword.Text))
            {
                errorValidatingPassword.SetError(textBoxPassword, "Пароль содержит минимум 8 символов");
                isValid = false;
            }
            else
            {
                errorValidatingPassword.Clear();
            }

            if(isValid)
            {
                Handlers.ViewHandler(() => _viewModel.Sigin(textBoxLogin.Text, textBoxPassword.Text));
            }
        }
    }
}
