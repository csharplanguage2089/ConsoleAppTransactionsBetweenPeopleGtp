internal class Program
{
    private static void Main(string[] args)
    {
        /*
         * В этом примере мы не используем внешние классы, а просто работаем с массивами и стандартными методами ввода-вывода из пространства имен System.
         * Программа начинается с определения массивов peopleNames и peopleMoney, которые содержат имена людей и их начальные суммы денег соответственно.
         * Затем следует бесконечный цикл while (true), в котором выводится информация о денежных средствах каждого человека и запрашивается ввод данных от пользователя.
         * Введенные данные проверяются на валидность и, если они корректны, происходит перевод денежных средств между людьми. Если у отправителя недостаточно денег для проведения транзакции, выводится соответствующее сообщение.
         * Цикл повторяется снова, и процесс продолжается до тех пор, пока пользователь не решит завершить программу.
         */
        string[] peopleNames = { "Andrey", "Anna", "Smith" };
        int[] peopleMoney = { 100, 100, 100 };

        int count = 0;

        while (true)
        {
            Console.WriteLine("Cash information at the beginning of the iteration:");
            for (int i = 0; i < peopleNames.Length; i++)
            {
                Console.WriteLine($"{peopleNames[i]} has {peopleMoney[i]} money.");
            }

            if (count > 0)
            {
                Console.WriteLine("Try again?");
                string endProgram = Console.ReadLine();
                if (endProgram == "n") { return; }
            }
            count++;

            string fromWhom = GetValidName("From whom?", peopleNames);
            string toWhom = GetValidName("To whom?", peopleNames);

            int amount = GetValidAmount("How much to give out?", peopleMoney[Array.IndexOf(peopleNames, fromWhom)]);

            int fromWhomIndex = Array.IndexOf(peopleNames, fromWhom);
            int toWhomIndex = Array.IndexOf(peopleNames, toWhom);

            if (fromWhomIndex != -1 && toWhomIndex != -1)
            {
                if (peopleMoney[fromWhomIndex] >= amount)
                {
                    peopleMoney[fromWhomIndex] -= amount;
                    peopleMoney[toWhomIndex] += amount;
                    Console.WriteLine("Transaction successful!");
                }
                else
                {
                    Console.WriteLine("Not enough money to perform the transaction.");
                }
            }
            else
            {
                Console.WriteLine("Invalid names entered.");
            }
        }
    }

    /// <summary>
    /// Метод GetValidName принимает сообщение и массив допустимых имен. Он запрашивает ввод от пользователя и проверяет, является ли введенное имя допустимым. Если имя недопустимо, выводится сообщение об ошибке и запрашивается повторный ввод.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="validNames"></param>
    /// <returns></returns>
    private static string GetValidName(string message, string[] validNames)
    {
        string name;
        bool isValidName = false;

        do
        {
            Console.WriteLine(message);
            name = Console.ReadLine();

            if (Array.IndexOf(validNames, name) != -1)
            {
                isValidName = true;
            }
            else
            {
                Console.WriteLine("Invalid name entered. Please try again.");
            }
        } while (!isValidName);

        return name;
    }

    /// <summary>
    /// Метод GetValidAmount принимает сообщение и максимальное значение суммы денег, которое можно выдать. Он запрашивает ввод от пользователя и проверяет, является ли введенное значение допустимым. Если значение недопустимо (не является положительным числом или превышает максимальное значение), выводится сообщение об ошибке и запрашивается повторный ввод.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="maxAmount"></param>
    /// <returns></returns>
    private static int GetValidAmount(string message, int maxAmount)
    {
        int amount;
        bool isValidAmount = false;

        do
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out amount) && amount > 0 && amount <= maxAmount)
            {
                isValidAmount = true;
            }
            else
            {
                Console.WriteLine("Invalid amount entered. Please enter a positive number within the available balance.");
            }
        } while (!isValidAmount);

        return amount;
    }
}
