using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Models
{
    //[Table("CustomTableName")] Used to use a custom table name
    public class PasswordModel
    {
        [PrimaryKey,AutoIncrement]
        public int PasswordID { get; set; }

        public string Title { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
