using Bibiotekav2;

class Loging
{
    public static void LoginNav()
    {
        Console.WriteLine("Welcome to the Login and Register Panel!");

        while (true)
        {
            Box.Border(Navigate.Login);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Register();
                    break;
                case ConsoleKey.D2:
                    Login();
                    break;
                case ConsoleKey.Q:
                    Navigate.Navigation();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void Register()
    {
        Console.WriteLine("\n--- Register ---");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Check if the user already exists
        if (UserExists(username))
        {
            Console.WriteLine("User already exists. Please try again with a different username.");
            return;
        }

        // Store user credentials in a text file
        using (StreamWriter sw = File.AppendText("users.txt"))
        {
            sw.WriteLine(username + "," + password);
        }

        Console.WriteLine("Registration successful. You can now login.");
    }

    static void Login()
    {
        Console.WriteLine("\n--- Login ---");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Check if the user exists
        if (!UserExists(username))
        {
            Console.WriteLine("User does not exist. Please register first.");
            return;
        }

        // Validate user credentials
        if (ValidateCredentials(username, password))
        {
            Console.WriteLine("Welcome, " + username + "!");
            Console.Title = $"Twoja Biblioteka - {username}";
        }
        else
        {
            Console.WriteLine("Incorrect credentials. Please try again.");
        }
    }

    static bool UserExists(string username)
    {
        string[] lines = File.ReadAllLines("users.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 2 && parts[0] == username)
            {
                return true;
            }
        }
        return false;
    }

    static bool ValidateCredentials(string username, string password)
    {
        string[] lines = File.ReadAllLines("users.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 2 && parts[0] == username && parts[1] == password)
            {
                return true;
            }
        }
        return false;
    }
}