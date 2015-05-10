using System;
using System.Security.Claims;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authorization;
using Carp.Logic.Entities;
using Carp.Data.Abstractions;

namespace Carp.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IUserProvider userProvider) : base(userProvider) { }
        public IActionResult Index()
        {
            if (CurrentUser != null)
            {
                //здесь должна быть логика которая выводит страницу со всем фаршем для 
                //пользователя который уже вошел
                throw new NotImplementedException();
            }
            else
            {
                return Redirect("/index.htm");
            }
        }

    }
}