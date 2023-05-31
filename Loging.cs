using System;
using Bibiotekav2;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography; // ad1

class Loging
{
    private static Dictionary<string, string> users = new Dictionary<string, string>();
    public static bool IsUserLogged = false;

    // Admin credentials
    private const string AdminUsername = "admin";
    private const string AdminPassword = "admin";

    public static void LoginNav()
    {
        Console.WriteLine("Witamy w panelu Logowania/Rejestracji!");

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
                    if (IsUserLogged == true)
                        Navigate.Navigation();
                    else
                        Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niewłaściwy wybór, wybierz ponownie");
                    break;
            }
        }
    }

    static void Register()
    {
        Console.WriteLine("\n--- Rejestracja ---");
        Console.WriteLine("Użyj kropki (.) jeśli chcesz ukryć lub pokazać hasło.");
        Console.Write("Nazwa użytkownika: ");
        string username = Console.ReadLine();
        Console.Write("Hasło: ");
        string password = ReadMaskedPassword();

        // Check if the user already exists
        if (UserExists(username))
        {
            Console.WriteLine("Użytkownik o podanej nazwie już istnieje. Spróbuj innej nazwy.");
            return;
        }

        // Zaszyfruj hasło 
        string encryptedPassword = EncryptPassword(password);

        // przechowanie danych użytkownika w słowniku <dictionary>
        users.Add(username, encryptedPassword);

        Console.WriteLine("Rejestracja przebiegła pomyślnie. Zaloguj się.");
    }

    static void Login()
    {
        Console.WriteLine("\n--- Logowanie ---");
        Console.WriteLine("Użyj kropki (.) jeśli chcesz ukryć lub pokazać hasło.");
        Console.Write("Nazwa użytkownika: ");
        string username = Console.ReadLine();
        Console.Write("Hasło: ");
        string password = ReadMaskedPassword();

        if (username == AdminUsername && password == AdminPassword)
        {
            Console.WriteLine("Witaj, " + username + "!");
            IsUserLogged = true;
            Console.Title = $"Twoja Biblioteka - {username}";
            Navigate.Navigation();
        }
        // Check if the user exists
        if (!UserExists(username))
        {
            Console.WriteLine("Użytkownik o podanej nazwie nie istnieje. Zarejestruj się.");
            return;
        }

        // zaszyfruj dla porównania
        string encryptedPassword = EncryptPassword(password);

        // walidacja użytkownika
        if (ValidateCredentials(username, encryptedPassword))
        {
            Console.WriteLine("Witaj, " + username + "!");
            IsUserLogged = true;
            Console.Title = $"Twoja Biblioteka - {username}";

            Navigate.Navigation();
        }
        else
        {
            Console.WriteLine("Niewłaściwe dane logowania. Spróbuj ponownie.");
        }
    }

    static bool UserExists(string username)
    {
        return users.ContainsKey(username);
    }

    static bool ValidateCredentials(string username, string encryptedPassword)
    {
        if (users.TryGetValue(username, out string password))
        {
            return password == encryptedPassword;
        }
        return false;
    }

    static string EncryptPassword(string password)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    static string ReadMaskedPassword()
    {
        StringBuilder passwordBuilder = new StringBuilder();
        ConsoleKeyInfo keyInfo;
        bool isMasked = true;

        do
        {
            keyInfo = Console.ReadKey(true);

            // Toggle between showing the masked password and hiding it when the "." (dot) key is pressed
            if (keyInfo.KeyChar == '.')
            {
                isMasked = !isMasked;
                continue;
            }

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (keyInfo.Key == ConsoleKey.Backspace && passwordBuilder.Length > 0)
            {
                passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                if (isMasked)
                {
                    passwordBuilder.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else
                {
                    Console.Write(keyInfo.KeyChar);
                }
            }
        } while (true);

        return passwordBuilder.ToString();
    }
}
