using Carp.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using Carp.Logic.Entities;

namespace Carp.Data.TestData
{
    public class TestUserProvider : IUserProvider
    {
        /// <summary>
        /// Источник тестовых данных Usera
        /// 
        /// </summary>
        private static IList<User> _users = new List<User>();

        /// <summary>
        /// только для ткстов все пользователи с тестовым паролем 111111 (6 единиц) 
        /// будут авторизованы с любым другим - нет
        /// </summary>
        /// <param name="email">емейл</param>
        /// <param name="password">пароль</param>
        /// <returns></returns>
        public User Authenticate(string email, string password)
        {
            if (password == "111111")
            {
                return _users.Where(u => u.Email == email).SingleOrDefault();

            }
            return null;
        }

        public int Create(User user)
        {
            if (user.Id != 0)
            {
                throw new InvalidOperationException("Id of new created user can only be = 0");
            }

            var newId = _users.Max(u => u.Id) + 1;

            var newUser = new User(newId)
            {
                Email = user.Email,
                BirthYear = user.BirthYear,
                Gender = user.Gender,
                Name = user.Name
            };

            _users.Add(newUser);

            return newUser.Id;
        }

        public void Delete(int id)
        {
            _users.Remove(_users.Where(u => u.Id == id).Single());
        }

        public int Find(string email)
        {
            var user = _users.Where(u => u.Email.ToLower() == email.ToLower()).SingleOrDefault();
            return user != null ? user.Id : 0;
        }

        public User Get(int id)
        {
            return _users.Where(u => u.Id == id).Single();
        }

        public void Update(User user)
        {
            if (user.Id == 0)
            {
                throw new InvalidOperationException("Id of updated user cannot be = 0");
            }

            var oldUser = _users.Where(u => u.Id == user.Id).Single();

            _users.Remove(oldUser);
            _users.Add(user);
        }
    }
}
