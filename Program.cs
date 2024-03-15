using exercise_106;
using PaymentPractice;
using System;
using log4net;

namespace PaymentPractice
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void WriteBooksToCsv(List<Book> books)
        {
            using (StreamWriter file = new StreamWriter("books.csv"))
            {
                file.WriteLine("Title, Pages, Publication Year");
                foreach (var book in books)
                {
                    file.WriteLine($"{book.Title},{book.Pages},{book.PublicationYear}");
                }
            }
        }

        static List<Book> ReadBooksFromCsv()
        {
            List<Book> books = new List<Book>();
            using (StreamReader file = new StreamReader("books.csv"))
            {
                string line;
                bool header = true;
                while ((line = file.ReadLine()) != null)
                {
                    if (header)
                    {
                        header = false;
                        continue;
                    }

                    string[] parts = line.Split(',');
                    string title = parts[0];
                    int pages = int.Parse(parts[1]);
                    int publicationYear = int.Parse(parts[2]);
                    books.Add(new Book(title, pages, publicationYear));
                }
            }
            return books;
        }

        static void Main(string[] args)
        {
            log4net.Util.LogLog.InternalDebugging = true;

            // Initialize log4net
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

            List<Book> books = new List<Book>();

            Console.WriteLine("Log4net configured.");

            while (true)
            {
                Console.Write("Name: ");
                string title = Console.ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    break;
                }

                Console.Write("Pages: ");
                int pages = int.Parse(Console.ReadLine());

                Console.Write("Publication year: ");
                int year = int.Parse(Console.ReadLine());

                books.Add(new Book(title, pages, year));
            }

            WriteBooksToCsv(books);

            Console.Write("What information will be printed? ");
            string input = Console.ReadLine();
            if (input == "everything")
            {
                foreach (Book book in books)
                {
                    // Log book information
                    log.Info(book);
                }
            }
            else if (input == "title")
            {
                foreach (Book book in books)
                {
                    // Log book title
                    log.Info(book.Title);
                }
            }
        }
    }
}