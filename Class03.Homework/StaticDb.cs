using Class03.Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Class03.Homework
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Author = "Robert Greene",
                Title = "Mastery"
            },
            new Book()
            {
                Author = "Robert Cialdini",
                Title = "Influence"
            },
            new Book()
            {
                Author = "Osho",
                Title = "Courage: The Art of Living Dangerously"
            },
            new Book()
            {
                Author = "Cal Newport",
                Title = "Deep Work"
            },
            new Book()
            {
                Author = "James Clear",
                Title = "Atomic Habits"
            },
            new Book()
            {
                Author = "Tony Robbins",
                Title = "Awake the Giant Within"
            },
        };
    }
}
