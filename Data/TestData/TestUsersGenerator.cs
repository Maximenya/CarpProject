using Carp.Data.Abstractions;
using Carp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Carp.Data.TestData
{
    public class TestUsersGenerator
    {
        private IUserProvider _provider;
        public TestUsersGenerator(IUserProvider userProvider)
        {
            _provider = userProvider;
        }

        private string[] _testNames = new string[]{
            "Dan Osman",
            "Wolfgang Güllich",
            "Jerry Moffat",
            "Patrick Edlinger",
            "Adam Ondra",
            "Dani Andrada",
            "Chris Sharma",
            "Yvon Chouinard",
            "Hans Florine",
            "Lynn Hill",
            "Alex Honnold",
            "Dean Potter",
            "Yuji Hirayama",
            "François Legrand",
            "Arnaud Petit",
            "Anna Stöhr",
            "Kilian Fishhuber",
            "Дмитрий Шарафутдинов",
            "Юлия Абрамчук"
        };

        public void Generate(int count)
        {
            var rand = new Random();
            for(var i = 0; i< count; i++)
            {
                var testName = _testNames[rand.Next(0, 19)];
                var testUser = new User
                {
                    BirthYear = rand.Next(1960, 2012),
                    Email = testName.Replace(" ", string.Empty).ToLower() + "@carp.org",
                    Gender = (Gender)rand.Next(0, 2),
                    Name = _testNames[rand.Next(0, 19)],
                };
                _provider.Create(testUser);
            }
        }
    }
}
