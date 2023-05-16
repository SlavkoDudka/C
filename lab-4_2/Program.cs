using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string databaseFile = "database.txt";
        List<Item> items = LoadDatabase(databaseFile);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - Вивести всю інформацію");
            Console.WriteLine("2 - Додати запис");
            Console.WriteLine("3 - Редагувати запис");
            Console.WriteLine("4 - Видалити запис");
            Console.WriteLine("5 - Пошук за словом");
            Console.WriteLine("6 - Сортування за номером сторінки");
            Console.WriteLine("Enter - Вихід");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.WriteLine();

            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    DisplayItems(items);
                    break;
                case ConsoleKey.D2:
                    AddItem(items);
                    break;
                case ConsoleKey.D3:
                    EditItem(items);
                    break;
                case ConsoleKey.D4:
                    DeleteItem(items);
                    break;
                case ConsoleKey.D5:
                    SearchItem(items);
                    break;
                case ConsoleKey.D6:
                    SortItems(items);
                    break;
                case ConsoleKey.Enter:
                    SaveDatabase(items, databaseFile);
                    return;
            }

            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey();
        }
    }

    static List<Item> LoadDatabase(string filePath)
    {
        List<Item> items = new List<Item>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length == 3)
                {
                    string word = parts[0];
                    string pageNumbers = parts[1];
                    int wordCount = int.Parse(parts[2]);

                    Item item = new Item(word, pageNumbers, wordCount);
                    items.Add(item);
                }
            }
        }

        return items;
    }

    static void SaveDatabase(List<Item> items, string filePath)
    {
        string[] lines = items.Select(item => $"{item.Word};{item.PageNumbers};{item.WordCount}").ToArray();
        File.WriteAllLines(filePath, lines);
    }

    static void DisplayItems(List<Item> items)
    {
        Console.WriteLine("Список записів:");

        foreach (Item item in items)
        {
            Console.WriteLine($"Слово: {item.Word}, Номера сторінок: {item.PageNumbers}, Кількість слів на сторінці: {item.WordCount}");
        }
    }

    static void AddItem(List<Item> items)
    {
        Console.WriteLine("Додавання нового запису:");

        try
        {
            Console.Write("Слово: ");
            string word = Console.ReadLine();

            Console.Write("Номера сторінок (через кому): ");
            string pageNumbers = Console.ReadLine();

            Console.Write("Кількість слів на сторінці: ");
            int wordCount = int.Parse
            (Console.ReadLine());
            Item item = new Item(word, pageNumbers, wordCount);
            items.Add(item);

            Console.WriteLine("Запис успішно додано.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    static void EditItem(List<Item> items)
    {
        Console.WriteLine("Редагування запису:");

        try
        {
            Console.Write("Введіть порядковий номер запису для редагування: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < items.Count)
            {
                Item item = items[index];

                Console.WriteLine($"Редагування запису #{index + 1}:");
                Console.WriteLine($"Поточне слово: {item.Word}");
                Console.Write("Нове слово (або Enter, щоб залишити без змін): ");
                string newWord = Console.ReadLine();

                Console.WriteLine($"Поточні номера сторінок: {item.PageNumbers}");
                Console.Write("Нові номера сторінок (або Enter, щоб залишити без змін): ");
                string newPageNumbers = Console.ReadLine();

                Console.WriteLine($"Поточна кількість слів на сторінці: {item.WordCount}");
                Console.Write("Нова кількість слів на сторінці (або Enter, щоб залишити без змін): ");
                string newWordCountInput = Console.ReadLine();
                int newWordCount;

                if (string.IsNullOrWhiteSpace(newWordCountInput))
                {
                    newWordCount = item.WordCount;
                }
                else
                {
                    newWordCount = int.Parse(newWordCountInput);
                }

                if (!string.IsNullOrWhiteSpace(newWord))
                {
                    item.Word = newWord;
                }

                if (!string.IsNullOrWhiteSpace(newPageNumbers))
                {
                    item.PageNumbers = newPageNumbers;
                }

                item.WordCount = newWordCount;

                Console.WriteLine("Запис успішно відредаговано.");
            }
            else
            {
                Console.WriteLine("Запис з таким порядковим номером не існує.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    static void DeleteItem(List<Item> items)
    {
        Console.WriteLine("Видалення запису:");

        try
        {
            Console.Write("Введіть порядковий номер запису для видалення: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < items.Count)
            {
                Item item = items[index];
                items.Remove(item);

                Console.WriteLine("Запис успішно видалено.");
            }
            else
            {
                Console.WriteLine("Запис з таким порядковим номером не існує.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    static void SearchItem(List<Item> items)
    {
        Console.WriteLine("Пошук за словом:");

        Console.Write("Введіть слово для пошуку: ");
        string
        searchWord = Console.ReadLine();
        List<Item> searchResults = items.Where(item => item.Word.Contains(searchWord)).ToList();

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Результати пошуку:");

            foreach (Item item in searchResults)
            {
                Console.WriteLine($"Слово: {item.Word}, Номера сторінок: {item.PageNumbers}, Кількість слів на сторінці: {item.WordCount}");
            }
        }
        else
        {
            Console.WriteLine("Записів з таким словом не знайдено.");
        }
    }

    static void SortItems(List<Item> items)
    {
        Console.WriteLine("Сортування за номером сторінки:");
        items.Sort((item1, item2) => item1.PageNumbers.CompareTo(item2.PageNumbers));
        Console.WriteLine("Записи успішно відсортовано за номером сторінки.");
    }
}

class Item
{
    private string word;
    private string pageNumbers;
    private int wordCount;
    public string Word
    {
        get { return word; }
        set { word = value; }
    }

    public string PageNumbers
    {
        get { return pageNumbers; }
        set { pageNumbers = value; }
    }

    public int WordCount
    {
        get { return wordCount; }
        set { wordCount = value; }
    }

    public Item(string word, string pageNumbers, int wordCount)
    {
        Word = word;
        PageNumbers = pageNumbers;
        WordCount = wordCount;
    }
}