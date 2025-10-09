﻿namespace IteratorsAndComparators
{
    internal class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }


        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }
    }
}
