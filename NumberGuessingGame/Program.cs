using NumberGuessingGame;

SystemPlayer systemPlayer = new();

while (true)
{
    GameMode gameMode = default;

    Console.WriteLine("Выберите режим игры 0 - Kомпьютер, 1 - Вы");
    switch (Console.ReadLine())
    {
        case "0":
            gameMode = GameMode.AINumber;
            break;
        case "1":
            gameMode = GameMode.PlayerNumber;
            break;
        default:
            Console.WriteLine("Отсутствует указанный режим");
            break;
    }

    systemPlayer.PlayGame(gameMode);
}