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
        public DateTime RegDate { get; set; } = DateTime.MinValue;
        public bool RemoveState { get; set; } = false;
        public User() { }
        public User(string firstName, string lastName, string userName)
        {
            firstName = firstName.ToLower();
            lastName = lastName.ToLower();
            FirstName = char.ToUpper(firstName[0]) + firstName[1..];
            LastName = char.ToUpper(lastName[0]) + lastName[1..];
            UserName = userName.ToLower();
        }
        public User(int userId, string firstName, string lastName, string userName,
            DateTime regDate, bool removeState)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
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
