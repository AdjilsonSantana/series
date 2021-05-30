using System;

namespace Series
{
    public class Serie : BaseEntity
    {
        // Atributes

        private Genre Genre {get; set;} 
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}

        //for List instead of DB
        private bool Deleted {get; set;}

        // Methods
 
        public Serie (int id, Genre genre, string title, string description, int year) // constructor
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Year: " + this.Year + Environment.NewLine;
            retorno += "Excluded: " + this.Deleted;

            return retorno;
        }

        public string returnTitle () // encapsulation
        {
            return this.Title;
        }

        public int returnId ()  // encapsulation
        {
            return this.Id;
        }
        
        public void ToDelete()
        {
            this.Deleted = true;
        }
    }
}