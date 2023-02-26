using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessenger
{
    // public для сериализации
    [Serializable]
    public class User
    {
        public User(int id, string userName, string passwordHash, DateTime registrationDate, bool isActive)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            RegistrationDate = registrationDate;
            IsActive = isActive;
        }
        public User(string userName, string passwordHash, DateTime registrationDate)
        {
            Id = 0;
            UserName = userName;
            PasswordHash = passwordHash;
            RegistrationDate = registrationDate;
            IsActive = true;
        }

        public User()
        {
            Id = 0;
            UserName = "Server";
            PasswordHash = "";
            RegistrationDate = DateTime.Now;
            IsActive = true;
        }

        public int Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = false;

        public override string ToString()
        {
            string output = $"Account #{Id} ({UserName})\nPassword hash: {PasswordHash}\nRegistration date: {RegistrationDate}\nIs active: {IsActive}";
            return output;
        }
    }

}
