using Carp.Data.Abstractions;
using Carp.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carp.Controllers
{
    public class UserController: BaseController
    {
        private IUserProvider _userProvider;

        public UserController(IUserProvider userProvider) : base(userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            if(CurrentUser != null)
            {
                throw new InvalidOperationException(
                    "GUI should not give user a chance to login if it's already logged in");
            }

            var user = _userProvider.Authenticate(loginUser.Email, loginUser.Password);
            if(user != null)
            {
                CurrentUser = user;
                return RedirectToAction("Index", "Home");
            }

            var message = new Message("Email либо Пароль не верны, проверьте вводимые данные. Если вы забыли пароль перейдите к восстановлению (ссылка)") { Status = MessageStatus.Error};

            return View("Message", message);
         }

        [HttpPost]
        public IActionResult Register(RegisterUser registerUser)
        {
            if (CurrentUser != null)
            {
                throw new InvalidOperationException(
                    "GUI should not give user a chance to register new user if there's already a user logged in");
            }

            var userId = _userProvider.Find(registerUser.Email);
            if (userId > 0)
            {
                var message = new Message("Пользователь с таким email уже заренистрирован, попробуйте войти (ссылка)") { Status = MessageStatus.Error };
                return View("Message", message);
            }

            userId = _userProvider.Create(registerUser.ToUser());

            var newUser = _userProvider.Get(userId);
            CurrentUser = newUser;
            ViewBag.NewUser = true;
            return RedirectToAction("Index", "Home");
        }
    }
}
