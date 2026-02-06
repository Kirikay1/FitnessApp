using Fitness.BL.Controller;

Console.WriteLine("Вас приветствует приложение FitnessApp");

Console.WriteLine("Введите имя пользователя");
var name = Console.ReadLine();

var userController = new UserController(name);
if (userController.IsNewUser)
{
    Console.WriteLine("Пол");
    var gender = Console.ReadLine();
    var birthDate = ParseValue<DateTime>("Дату рождения (dd.MM.yyyy)");
    var weigth = ParseValue<double>("Вес");
    var heigth = ParseValue<double>("Рост");

    userController.SetNewUserData(gender, birthDate, weigth, heigth);
}

Console.WriteLine(userController.CurrentUser);
Console.ReadLine();

static T ParseValue<T>(string name) where T : IParsable<T>
{
    while (true)
    {
        Console.WriteLine($"Введите {name}");
        var input = Console.ReadLine() ?? "";

        if (T.TryParse(input, null, out var value))
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Неверный формат {name}");
        }
    }
}

