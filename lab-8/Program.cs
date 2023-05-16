using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool InStock { get; set; }
}

class ProductList
{
    private List<Product> products;
    private string filePath;

    public ProductList(string filePath)
    {
        this.filePath = filePath;
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            products = new List<Product>();
            foreach (string line in lines)
            {
                string[] data = line.Split(';');
                if (data.Length == 5)
                {
                    Product product = new Product
                    {
                        Name = data[0],
                        Id = int.Parse(data[1]),
                        Category = data[2],
                        Price = double.Parse(data[3]),
                        InStock = bool.Parse(data[4])
                    };
                    products.Add(product);
                }
            }
        }
        else
        {
            products = new List<Product>();
        }
    }

    public void SaveData()
    {
        string[] lines = products.Select(p => $"{p.Name};{p.Id};{p.Category};{p.Price};{p.InStock}").ToArray();
        File.WriteAllLines(filePath, lines);
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public void EditProduct(Product product)
    {
        // Assuming you have some kind of identifier (e.g., Id) to find the product to edit
        Product existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            // Update the fields of the existing product
            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.InStock = product.InStock;
        }
        else
        {
            throw new Exception("Product not found");
        }
    }

    public void PrintSortedProducts(string sortBy)
    {
        IEnumerable<Product> sortedProducts;
        switch (sortBy)
        {
            case "name":
                sortedProducts = products.OrderBy(p => p.Name);
                break;
            case "id":
                sortedProducts = products.OrderBy(p => p.Id);
                break;
            case "category":
                sortedProducts = products.OrderBy(p => p.Category);
                break;
            case "price":
                sortedProducts = products.OrderBy(p => p.Price);
                break;
            case "instock":
                sortedProducts = products.OrderBy(p => p.InStock);
                break;
            default:
                throw new Exception("Invalid sort parameter");
        }

        foreach (Product product in sortedProducts)
        {
            Console.WriteLine($"Name: {product.Name}, ID: {product.Id}, Category: {product.Category}, Price: {product.Price}, InStock: {product.InStock}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductList productList = new ProductList("products.txt");

        Console.WriteLine("Product Management System");
        Console.WriteLine("=========================");
        Console.WriteLine("Menu:");
        Console.WriteLine("A - Add a product");
        Console.WriteLine("R - Remove a product");
        Console.WriteLine("E - Edit a product");
        Console.WriteLine("P - Print sorted products");
        Console.WriteLine("X - Exit");
        bool exit = false;
        while (!exit)
        {
            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice.ToUpper())
            {
                case "A":
                    Product newProduct = ReadProductFromInput();
                    productList.AddProduct(newProduct);
                    productList.SaveData();
                    Console.WriteLine("Product added successfully.");
                    break;
                case "R":
                    Product productToRemove = ReadProductFromInput();
                    productList.RemoveProduct(productToRemove);
                    productList.SaveData();
                    Console.WriteLine("Product removed successfully.");
                    break;
                case "E":
                    Product updatedProduct = ReadProductFromInput();
                    productList.EditProduct(updatedProduct);
                    productList.SaveData();
                    Console.WriteLine("Product edited successfully.");
                    break;
                case "P":
                    Console.WriteLine("Sort by (Name/Id/Category/Price/InStock):");
                    string sortBy = Console.ReadLine().ToLower();
                    productList.PrintSortedProducts(sortBy);
                    break;
                case "X":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static Product ReadProductFromInput()
    {
        Console.WriteLine("Enter product details:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Category: ");
        string category = Console.ReadLine();

        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("In Stock (true/false): ");
        bool inStock = bool.Parse(Console.ReadLine());

        return new Product
        {
            Name = name,
            Id = id,
            Category = category,
            Price = price,
            InStock = inStock
        };
    }
}