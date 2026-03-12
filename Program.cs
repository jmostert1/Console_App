// See https://aka.ms/new-console-template for more information

Console.WriteLine($"Welcome to JPM Bookstore");

Bookstore bookstore = new Bookstore();
string? option = "";


do
{
    Console.WriteLine();
    Console.Write("Options: \n1. View Books \n2. Add Book \n3. Remove Book \n4. Exit\n");
    Console.WriteLine();
    Console.Write("Please select an option: ");
    option = Console.ReadLine();

    if (option == "1")
    {
        Console.WriteLine("Viewing Books...");
        // Code to display books
        bookstore.ViewBooks();
    }
    else if (option == "2")
    {
        Console.WriteLine("Adding a Book...");
        // Code to add a book
        bookstore.AddBook();
    }
    else if (option == "3")
    {
        Console.WriteLine("Removing a Book...");
        // Code to remove a book
        bookstore.Removebook();
    }
    else if (option == "4")
    {
        Console.WriteLine("Exiting...");
      
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.");
    }

} while (option != "4");



///////////////////////////////////////////////////////////////////////////
// All of these basic requirements:

// Variables

// Expressions

// Conditionals

// Loops

// Functions

// Classes

// Structures and Unions

///////////////////////////////////////////////////////////////////////////
// One of these additional requirements:

// Read and write to a file.

// Demonstrate inheritance using the extends and abstract keywords.
///////////////////////////////////////////////////////////////////////////