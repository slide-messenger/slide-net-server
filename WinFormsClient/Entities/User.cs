using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Entities
{
    // public для сериализации
    [Serializable]
    public class User
    {
        public int UserId { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime RegDate { get; set; } = DateTime.MinValue;
        public bool RemoveState { get; set; } = false;
        public User() { }
        public User(string firstName, string lastName, string userName, string passwordHash,
            DateTime regDate, int userId = 0, bool removeState = false)
        {
            // если создаем нового пользователя
            if (userId == 0)
            {
                FirstName = char.ToUpper(firstName[0]) + firstName[1..];
                LastName = char.ToUpper(lastName[0]) + lastName[1..];
                UserName = userName.ToLower();
                PasswordHash = passwordHash.ToLower();
            }
            // если извлекаем из базы данных SQL
            else
            {
                FirstName = firstName;
                LastName = lastName;
                UserName = userName;
                PasswordHash = passwordHash;
            }
            RegDate = regDate;
            UserId = userId;
            RemoveState = removeState;
        }
        public override string ToString()
        {
            string output = $@"Имя: {FirstName} {LastName}
Имя пользователя: {UserName}
Личная ссылка: uid={UserId}
Зарегистрирован: {RegDate}";
            return output;
        }
    }
}
