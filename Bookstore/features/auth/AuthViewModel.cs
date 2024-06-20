using Bookstore.common.data.data_sources;
using Bookstore.common.data.entities;
using Bookstore.common.data.services;
using Bookstore.common.presentation;
using System;

namespace Bookstore.features.auth
{
    public class AuthViewModel
    {
        private readonly UserService _userService;
        private readonly UserLocalDataSource _userLocalDS;

        public AuthViewModel(UserLocalDataSource userLocalDataSource, UserService userService) 
        {
            _userLocalDS = userLocalDataSource;
            _userService = userService;
        }

        public void Sigin(string login, string password)
        {
            bool isReg = false;
            Handlers.ConnectionHandler(() => isReg = _userLocalDS.IsRegistration(login));
            if (!isReg) throw new ArgumentException("Данный пользователь не зарегистрирован");

            Handlers.ConnectionHandler(
                () =>
                {
                    User user = _userLocalDS.Select(login, password);
                    SetupProgram(user);
                    Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookCatalogScreen());
                }
            );
        }

        public void Reg(string login, string password)
        {
            bool isReg = true;
            Handlers.ConnectionHandler(() => isReg = _userLocalDS.IsRegistration(login));
            if (isReg) throw new ArgumentException("Данный пользователь уже зарегистрирован");
            if (new CaptchaForm().ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;
            Handlers.ConnectionHandler(
                () =>
                {
                    User user = new User(default, 2, login);
                    user.Id = _userLocalDS.Insert(user, password);
                    SetupProgram(user);
                    Program.Navigator.PushRemove(Program.ScreenFactory.MakeBookCatalogScreen());
                }
            );
        }

        private void SetupProgram(User user)
        {
            Program.Setting.CurrentUser = user;
            Program.Setting.CurrentOrder = new System.Collections.Generic.List<OrderBook>();
        }

        public bool IsValidLogin(string login)
        {
            return _userService.ValidatingLogin(login.Trim());
        }

        public bool IsValidPasswordSigin(string password)
        {
            return _userService.ValidatingPasswordsLength(password);
        }

        public bool IsValidPasswordReg(string password)
        {
            return _userService.ValidatingPassword(password);
        }
    }
}
