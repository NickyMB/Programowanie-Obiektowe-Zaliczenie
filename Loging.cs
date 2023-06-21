using System;
using Bibiotekav2;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography; // ad1

class Loging
{
    // Słownik <dictionary> przechowujący nazwy użytkowników i hasła
    private static Dictionary<string, string> users = new Dictionary<string, string>();

    // Metoda do odczytywania hasła z konsoli
    public static Dictionary<string, string> GetUsers()
    {
        return users;
    }

    public static bool IsUserLogged = false;
    public static bool IsAdminLogged = false;
    public static string username = "";


    // Dane do logowania administratora 
    private const string AdminUsername = "admin";
    private const string AdminPassword = "admin";
    // panel logowania
    public static void LoginNav()
    {
        Console.Clear();

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
                    Console.WriteLine("Czy na pewno chcesz wyjść? (T/N)");
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.T:
                            Environment.Exit(0);
                            break;
                    }
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Niewłaściwy wybór, wybierz ponownie");
                    break;
            }
        }
    }
    // Funkcja odpowiadajaca za proces rejestracji
    static void Register()
    {
        string loginRegexPattern = @"^[a-zA-Z0-9_]+$";// wyrażenie regularne do sprawdzania nazwy użytkownika i hasła
        Console.WriteLine("\n--- Rejestracja ---");
        Console.WriteLine("Odkryj magię kropki (.) i zakryj prawdziwe hasło!");
        Console.Write("Nazwa użytkownika: ");
        string username = Console.ReadLine();
        // warunek sprawdzający czy nazwa użytkownika zawiera tylko litery, cyfry i znak podkreślenia względem wyrażenia regularnego
        if (!System.Text.RegularExpressions.Regex.IsMatch(username, loginRegexPattern))
        {
            Console.WriteLine("Nazwa użytkownika może zawierać tylko litery, cyfry i znak podkreślenia.");
            return;
        }
        Console.Write("Hasło: ");
        string password = ReadMaskedPassword();
        // warunek sprawdzający czy hasło zawiera tylko litery, cyfry i znak podkreślenia względem wyrażenia regularnego
        if (!System.Text.RegularExpressions.Regex.IsMatch(password, loginRegexPattern))
        {
            Console.WriteLine("Hasło może zawierać tylko litery, cyfry i znak podkreślenia.");
            return;
        }

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
    // Funkcja odpowiadajaca za proces logowania
    static void Login()
    {
        Console.WriteLine("\n--- Logowanie ---");
        Console.WriteLine("Odkryj magię kropki (.) i zakryj prawdziwe hasło!");
        Console.Write("Nazwa użytkownika: ");
        username = Console.ReadLine();
        Console.Write("Hasło: ");
        string password = ReadMaskedPassword();
        // warunek umożliwiajacy administratowoi zalogowanie sie bez rejestracji
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

            // przeskakuj pomiedzy pokazywaniem zakrytego hasla i ukrywaniem go, gdy nacisniety zostanie klawisz "." (kropka)
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