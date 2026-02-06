using Fitness.BL.Controller;

Console.WriteLine("Вас приветствует приложение FitnessApp");

Console.WriteLine("Введите имя пользователя");
var name = Console.ReadLine();

Console.WriteLine("Введите пол");
var gender = Console.ReadLine();

Console.WriteLine("Введите дату рождения");
var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: переписать

Console.WriteLine("Введите вес");
var weigth = double.Parse(Console.ReadLine()); //TODO: переписать

Console.WriteLine("Введите свой рост");
var heigth = double.Parse(Console.ReadLine()); //TODO: переписать

var userController = new UserController(name, gender, birthDate, weigth, heigth);
userController.Save();