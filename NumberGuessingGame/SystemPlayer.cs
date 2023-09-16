namespace NumberGuessingGame;

public class SystemPlayer
{
    private readonly Random _random = new();

    private int _attempts; //колличестпо попыток
    private int _guess; //предпологаемое число 

    public void PlayGame(GameMode gameMode)
    {
        switch (gameMode)
        {
            case GameMode.PlayerNumber:
                GuessPlayerNumber();
                break;
            case GameMode.AINumber:
                GuessAINumber();
                break;
            default: throw new InvalidOperationException("Неизвестный режим игры");
        }
    }

    private void GuessAINumber()
    {
        int secretNumber = _random.Next(1, 101);

        Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
        Console.WriteLine("Я загадал число от 1 до 100. Попробуйте угадать.");

        while (_guess != secretNumber)
        {
            Console.Write("Введите вашу догадку: ");
            string input = Console.ReadLine();

            _attempts++;

            if (!int.TryParse(input, out _guess))
            {
                Console.WriteLine("Введите только целое число.");
                continue;
            }

            if (_guess < secretNumber)
            {
                Console.WriteLine("Мое число больше.");
            }
            else if (_guess > secretNumber)
            {
                Console.WriteLine("Мое число меньше.");
            }
            else
            {
                Console.WriteLine($"Поздравляю! Вы угадали число {secretNumber} за {_attempts} попыток.");
            }
        }
    }

    private void GuessPlayerNumber()
    {
        Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
        Console.WriteLine("Загадай число от 1 до 100.");
        bool isTarget = false;
        int min = 0;
        int max = 100;
        int currentMin = min;
        int currentMax = max;
        float mid;

        while (!isTarget)
        {
            mid = (currentMin + currentMax) / 2;
            _guess = (int)Math.Round(mid, MidpointRounding.AwayFromZero);
            Console.WriteLine($"Думаю что это число:{_guess}");
            string answer = Console.ReadLine();
            if (answer.Equals("Да", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ура!");
                isTarget = true;
            }
            else if (answer.Equals("Меньше", StringComparison.OrdinalIgnoreCase))
            {
                currentMax = Math.Max(_guess - 1, min);
            }
            else if (answer.Equals("Больше", StringComparison.OrdinalIgnoreCase))
            {
                currentMin = Math.Min(_guess + 1, max);
            }

            if (currentMin == currentMax && !isTarget)
            {
                Console.WriteLine($"Это число точно такое {_guess}");
                break;
            }
        }
    }
}