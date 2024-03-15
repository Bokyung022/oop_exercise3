using System;
using System.Collections.Generic;

namespace exercise_106
{
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, int pages, int publicationYear)
        {
            Title = title;
            Pages = pages;
            PublicationYear = publicationYear;
        }

        public override string ToString()
        {
            return $"{Title}, {Pages} pages, {PublicationYear}";
        }
    }
}