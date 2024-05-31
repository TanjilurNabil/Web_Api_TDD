using CloudCustomers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTest.Fixtures
{
    public static class UserFixture
    {
        public static List<User> GetTestUsers() => new()
        {
            new User
            {
                Name = "Test User 1",
                Email = "user1@example.com",
                Address = new Address
                {
                    Street = "North Basabo",
                    City = "Dhaka",
                    ZipCode = "1214"
                }
            },

            new User
            {
                Name = "Test User 2",
                Email = "user2@example.com",
                Address = new Address
                {
                    Street = "South Basabo",
                    City = "Dhaka",
                    ZipCode = "1215"
                }
            },

            new User
            {
                Name = "Test User 3",
                Email = "user3@example.com",
                Address = new Address
                {
                    Street = "Gulshan",
                    City = "Dhaka",
                    ZipCode = "1212"
                }
            },

            new User
            {
                Name = "Test User 4",
                Email = "user4@example.com",
                Address = new Address
                {
                    Street = "Banani",
                    City = "Dhaka",
                    ZipCode = "1213"
                }
            }

        };
    }
}
