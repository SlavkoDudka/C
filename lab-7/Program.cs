using System;
using System.Collections;
using System.Collections.Generic;

namespace JournalApplication
{
    public class Journal : IComparable<Journal>
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public int SalesRating { get; set; }

        public Journal(string title, string publisher, double price, int pages, int salesRating)
        {
            Title = title;
            Publisher = publisher;
            Price = price;
            Pages = pages;
            SalesRating = salesRating;
        }

        public int CompareTo(Journal other)
        {
            return Price.CompareTo(other.Price);
        }
    }

    public class JournalComparer : IComparer<Journal>
    {
        public int Compare(Journal x, Journal y)
        {
            int result = x.Pages.CompareTo(y.Pages);
            if (result == 0)
            {
                result = x.SalesRating.CompareTo(y.SalesRating);
            }
            return result;
        }
    }

    public class JournalCollection : IEnumerable<Journal>
    {
        private List<Journal> journals;

        public JournalCollection(List<Journal> journalList)
        {
            journals = journalList;
        }

        public IEnumerator<Journal> GetEnumerator()
        {
            journals.Sort((x, y) => x.SalesRating.CompareTo(y.SalesRating));
            return journals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal[] journalArray = new Journal[]
            {
                new Journal("Журнал 1", "Видавництво 1", 9.99, 100, 5),
                new Journal("Журнал 2", "Видавництво 2", 12.99, 80, 8),
                new Journal("Журнал 3", "Видавництво 3", 7.99, 120, 3),
                new Journal("Журнал 4", "Видавництво 1", 14.99, 90, 7),
                new Journal("Журнал 5", "Видавництво 2", 10.99, 110, 6),
                new Journal("Журнал 6", "Видавництво 3", 11.99, 95, 4),
                new Journal("Журнал 7", "Видавництво 1", 8.99, 105, 9),
                new Journal("Журнал 8", "Видавництво 2", 13.99, 75, 2),
                new Journal("Журнал 9", "Видавництво 3", 6.99, 130, 1),
                new Journal("Журнал 10", "Видавництво 1", 15.99, 85, 10)
            };
            Console.WriteLine("Список журналів за ціною:");
            Array.Sort(journalArray);
            foreach (var journal in journalArray)
            {
                Console.WriteLine($"Назва: {journal.Title}, Ціна: {journal.Price}");
            }

            Console.WriteLine();

            Console.WriteLine("Список журналів за кількістю сторінок та рейтингом продажів:");
            Array.Sort(journalArray, new JournalComparer());
            foreach (var journal in journalArray)
            {
                Console.WriteLine($"Назва: {journal.Title}, Сторінки: {journal.Pages}, Рейтинг продажів: {journal.SalesRating}");
            }

            Console.WriteLine();

            Console.WriteLine("Список журналів за рейтингом продажів:");
            JournalCollection journalCollection = new JournalCollection(new List<Journal>(journalArray));
            foreach (var journal in journalCollection)
            {
                Console.WriteLine($"Назва: {journal.Title}, Рейтинг продажів: {journal.SalesRating}");
            }

            Console.ReadLine();
        }
    }
}
