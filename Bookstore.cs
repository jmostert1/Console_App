//Manage options
using System;
using System.Text.Json;


class Bookstore
{
    // This class can be expanded to include properties and methods related to the bookstore

    private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "books.json");

    public void ViewBooks()
    {
        //Read all the info
        string json = File.ReadAllText(filePath);

        //convert json and add to our list
        //the deserializer takes the variables in Book.cs and tries to match them to the raw text. The must match perfectly especially with capitals etc.
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json)!;

        //Write now to console with loop
        Console.WriteLine("Books in the Store:");

        //(class, variable, list)
        foreach (Book book in books)
        {
            Console.WriteLine($"{book.id}, {book.title}, {book.author}, {book.genre}, {book.price}, {book.stock}");
        }


    }

    public void AddBook()
    {
        //Code to add a book
        //ask user for book details
        Console.Write("Enter book title: ");
        string title = Console.ReadLine()!;
        Console.Write("Enter book author: ");
        string author = Console.ReadLine()!;
        Console.Write("Enter book genre: ");
        string genre = Console.ReadLine()!;
        Console.Write("Enter book price: ");
        double price = Convert.ToDouble(Console.ReadLine()!);
        Console.Write("Enter book stock: ");
        int stock = Convert.ToInt32(Console.ReadLine()!);

        //add to book.json
        //read the existing books
        string json = File.ReadAllText(filePath);
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json)!;

        //create a new book object
        //new instance because we are creating a new book
        Book newBook = new Book
        {
            id = books.Count + 1, // Generate a new ID based on the count of existing books
            title = title,
            author = author,
            genre = genre,
            price = price,
            stock = stock
        };
        //add to list
        books.Add(newBook);
        //convert json
        json = JsonSerializer.Serialize(books);
        //write to file
        File.WriteAllText(filePath, json);
    }


    public void Removebook()
    {
        //Code to remove a book
        //ask user which book to remove
        Console.Write("Enter the ID of the book to remove: ");
        int idToRemove = Convert.ToInt32(Console.ReadLine()!);


        //read existing
        string json = File.ReadAllText(filePath);
        List<Book> books = JsonSerializer.Deserialize<List<Book>>(json)!;

        //short lamda way of writing the foreach loop
        //foreach (Book b in books)
        {
            //     if (b.id == idToRemove)
            //     {
            //         bookToRemove = b;
            //         break;
            //     }
            // }
            Book? bookToRemove = books.Find(b => b.id == idToRemove);


            if (bookToRemove != null)
            {
                //remove from list
                books.Remove(bookToRemove);
                //convert json
                json = JsonSerializer.Serialize(books);
                //write to file
                File.WriteAllText(filePath, json);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

        }



    }
}