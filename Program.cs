using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace W6_E2
{
    
    internal class Program
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }
        static void Main(string[] args)
        {
            string fileName = @"C:\temp\books.json"; //fileName gives provided path to write JSON file
            Book book = new Book { Title = "The Hunger Games", Author = "Suzanne Collins", Year = 2008 }; //Class book with parameters that specify title, author, and year
            Console.WriteLine("Serialize to Json"); //Tells user that serialization is to begin
            SerializeToJson(fileName, book); //Method SerializeToJson takes book object and serializes it to another file called books.json 
            Console.WriteLine("Json serialization completed"); //Tells user that serialization is complete
            Console.WriteLine(); //Space given for better visibility
            Console.WriteLine("Deserialize from Json"); //Tells user that deserialization is to begin
            DeserializeToJson(fileName); //Method DeserializeToJson goes to fileName and takes book's parameters out of file to call in terminal 
            Console.WriteLine("Json file deserialized"); //Tells user that deserialization is complete
            Console.ReadLine(); //Pauses program to allow user to view
        }
        
        public static void SerializeToJson(string fileName, Book book)
        {
            string JSON = JsonSerializer.Serialize(book); //Serializes book object with predetermined parameters
            File.WriteAllText(fileName, JSON); //Writes out book object's parameters to books.json file
        }
        public static void DeserializeToJson(string fileName)
        {
            string JSON = File.ReadAllText(fileName); //Reads all text in file
            Book deserializedBook = JsonSerializer.Deserialize<Book>(JSON); //Calls book class to then deserialize what it read from file (JSON variable)

            Console.WriteLine($"Book Title: {deserializedBook.Title}"); //Outputs deserialized object's title
            Console.WriteLine($"Book Author: {deserializedBook.Author}"); //Outputs deserialized object's author
            Console.WriteLine($"Book Year: {deserializedBook.Year}"); //Outputs deserialized object's year
        }
    }
}
