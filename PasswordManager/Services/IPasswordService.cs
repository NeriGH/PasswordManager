using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public interface IPasswordService
    {
        Task<List<PasswordModel>> GetPasswordList();

        Task<int> AddPassword(PasswordModel passwordModel);

        Task<int> DeletePassword(PasswordModel passwordModel);
        Task<int> UpdatePassword(PasswordModel passwordModel);
    }
}
