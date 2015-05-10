using Carp.Data.Abstractions;
using Carp.Logic.Entities;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Security.Claims;


namespace Carp.Controllers
{
    public class BaseController: Controller
    {
        public BaseController(IUserProvider provider)
        {

        }

        private IUserProvider _userProvider;

        private User _cachedUser;
        protected User CurrentUser
        {
            get
            {
                if(_cachedUser == null )
                {
                    if (Context.User != null && Context.User.Identity.IsAuthenticated)
                    {
                        var userId = int.Parse(Context.User.Claims.Where(c => c.Type == ClaimType.UserId.ToString()).Single().Value);
                        _cachedUser = _userProvider.Get(userId);
                    }
                }

                return _cachedUser;    
            }
            set
            {
                _cachedUser = value;
            }
        }

        protected void SignIn(User user)
        {
            var claims = user.Claims;
            if(claims.Where(c=>c.Type == ClaimType.UserId.ToString()).Count() == 0)
            {
                claims.Add(new Claim(ClaimType.UserId.ToString(), user.Id.ToString()));
            }

            CurrentUser = user;

            Response.SignIn(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));
        }

        protected void SignOut()
        {
            CurrentUser = null;
            Response.SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        
    }
}
