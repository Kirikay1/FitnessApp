using Fitness.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            // TODO: проверка

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);

        }

        public UserController()
        {
            using var fs = new FileStream("users.json", FileMode.Open, FileAccess.Read);

            if (JsonSerializer.Deserialize<User>(fs) is User user)
                User = user;
            else
                throw new InvalidDataException("Не удалось загрузить пользователя");

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
            JsonSerializer.Serialize(fs, User, options);
        }
    }
}
