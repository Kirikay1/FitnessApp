using System;
using System.Text.Json.Serialization;


namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region Свойства
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weigth { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Heigth { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weigth"> Вес. </param>
        /// <param name="heigth"> Рост. </param>
        public User(string name, Gender gender, DateTime birthDate, double weigth, double heigth)
        {

            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустым или null", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }

            if (weigth <= 0)
            {
                throw new ArgumentException("Вес должен быть больше 0", nameof(weigth));
            }

            if (heigth <= 0)
            {
                throw new ArgumentException("Рост должен быть больше 0", nameof(heigth));

            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weigth = weigth;
            Heigth = heigth;
        }
        [JsonConstructor]
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
