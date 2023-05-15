using System;

public class Program
{
    public static void Main()
    {
        var cities = new Dictionary<int, string>();
        cities.Add(58000, "Чернівці");
        cities.Add(79000, "Львів");
        cities.Add(61000, "Харків");
        cities.Add(03000, "Київ");
        cities.Add(49000, "Дніпро");
        cities.Add(54000, "Миколаїв");
        cities.Add(49027, "Запоріжжя");
        cities.Add(65003, "Одеса");
        cities.Add(21000, "Вінниця");
        cities.Add(49044, "Маріуполь");

        Console.Write("Введіть поштовий індекс: ");
        int index = int.Parse(Console.ReadLine());

        if (cities.ContainsKey(index))
        {
            Console.WriteLine("Місто з поштовим індексом " + index + " - " + cities[index]);
        }
        else
        {
            Console.WriteLine("Місто з поштовим індексом " + index + " не знайдено");
        }
    }
}