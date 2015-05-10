using Carp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carp.Data.Abstractions
{
    public interface IUserProvider
    {
        User Authenticate(string email, string password);

        int Find(string email);

        User Get(int id);

        int Create(User user);

        void Update(User user);

        void Delete(int id);
    }
}