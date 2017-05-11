using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Threading.Tasks;

namespace VocableMVC.Models.Entities
{
    public partial class VHDBContext : DbContext
    {
        public async Task AddUserDetails(string firstName, string lastName, string id)
        {
            var user = new Users
            {
                Aspid = id,
                FirstName = firstName,
                LastName = lastName
            };

            Add(user);
            await SaveChangesAsync();

        }
    }
}