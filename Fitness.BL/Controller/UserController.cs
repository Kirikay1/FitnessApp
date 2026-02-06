using Fitness.BL.Model;
using System;
using System.Text.Json;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }


        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            if (!File.Exists("users.json"))
                return new List<User>();

            using var fs = new FileStream("users.json", FileMode.Open, FileAccess.Read);

            return JsonSerializer.Deserialize<List<User>>(fs) ?? new List<User>();

        }

        public void SetNewUserData(string genderName, DateTime bitrhDate, double weigth = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = bitrhDate;
            CurrentUser.Weigth = weigth;
            CurrentUser.Heigth = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using var fs = new FileStream("users.json", FileMode.Create, FileAccess.Write, FileShare.None);
            JsonSerializer.Serialize(fs, Users, options);
        }
    }
}
