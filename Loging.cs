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
    public static bool IsAdminLogged = false;
    public static string username;


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
        Console.WriteLine("Odkryj magię kropki (.) i zakryj prawdziwe hasło!");
        Console.Write("Nazwa użytkownika: ");
        string username = Console.ReadLine();
        Console.Write("Hasło: ");
        string password = ReadMaskedPassword();

        // Sprawdź, czy użytkownik już istnieje
        if (UserExists(username))
        {
            Console.WriteLine("Wygląda na to, że masz konkurencję! Spróbuj innej nazwy.");
            return;
        }

        // Zaszyfruj hasło 
        string encryptedPassword = EncryptPassword(password);

        // Przechowanie danych użytkownika w słowniku <dictionary>
        users.Add(username, encryptedPassword);

        Console.WriteLine("Sukces! Możesz teraz zalogować się i zacząć eksplorować Nasze biblioteczne bezkresy.");
    }

    static void Login()
    {
        Console.WriteLine("\n--- Logowanie ---");
        Console.WriteLine("Odkryj magię kropki (.) i zakryj prawdziwe hasło!");
        Console.Write("Nazwa użytkownika: ");
        username = Console.ReadLine();
        Console.Write("Hasło: ");
        string password = ReadMaskedPassword();

        if (username == AdminUsername && password == AdminPassword)
        {
            Console.WriteLine("Witaj, " + username + "!");
            IsUserLogged = false;
            IsAdminLogged = true;
            Console.Title = $"Twoja Biblioteka - {username}";
            Navigate.Navigation();
        }
        // Sprawdź, czy użytkownik istnieje
        if (!UserExists(username))
        {
            Console.WriteLine("O nie! Wprowadziłeś nazwę użytkownika, która istnieje tylko w alternatywnej rzeczywistości. Czy jesteś gotowy, aby odkryć nową rzeczywistość poprzez rejestrację? ");
            return;
        }

        // Zaszyfruj hasło do porównania
        string encryptedPassword = EncryptPassword(password);

        // Walidacja użytkownika
        if (ValidateCredentials(username, encryptedPassword) && IsAdminLogged == false)
        {
            Console.WriteLine("Witaj, " + username + "!");
            IsUserLogged = true;
            IsAdminLogged = false;
            Console.Title = $"Twoja Biblioteka - {username}";

            Navigate.Navigation();
        }
        else
        {
            Console.WriteLine("Huston, mamy problem! Twoje dane logowania nie przeszły testu kosmicznego. Spróbuj ponownie");
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
                Console.SetCursorPosition(Console.CursorLeft - passwordBuilder.Length, Console.CursorTop);
                Console.Write(isMasked ? new string('*', passwordBuilder.Length) : passwordBuilder.ToString());
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
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
                passwordBuilder.Append(keyInfo.KeyChar);
                Console.Write(isMasked ? "*" : keyInfo.KeyChar.ToString());
            }
        } while (true);

        return passwordBuilder.ToString();
    }


}