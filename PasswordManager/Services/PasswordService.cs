using PasswordManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    internal class PasswordService : IPasswordService
    {
        private SQLiteAsyncConnection _dbConnection;
        public PasswordService()
        {
            SetUpDB();
        }

        private async void SetUpDB()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Password.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
               await  _dbConnection.CreateTableAsync<PasswordModel>();
            }
        }

        public Task<int> AddPassword(PasswordModel passwordModel)
        {
          return  _dbConnection.InsertAsync(passwordModel);
        }

        public Task<int > DeletePassword(PasswordModel passwordModel)
        {
            return _dbConnection.DeleteAsync(passwordModel);
        }

        public async Task<List<PasswordModel>> GetPasswordList()
        {
            var passwordList = await _dbConnection.Table<PasswordModel>().ToListAsync();
            return passwordList;
        }

        public Task<int> UpdatePassword(PasswordModel passwordModel)
        {
            return _dbConnection.UpdateAsync(passwordModel);
        }
    }
}
