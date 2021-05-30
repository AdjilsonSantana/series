using System;

namespace Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {

            string userOption = GetUserOption();
        
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ToListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        SeeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default: 
                        throw new ArgumentOutOfRangeException();

                }
                
                userOption = GetUserOption();
            }

            Console.WriteLine ("Thanks for use ours app!");
        }

        private static void SeeSerie()
        {
            Console.Write ("Insert the serie id: ");
            int seeSerieIdEntry = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(seeSerieIdEntry);

            Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.WriteLine ("Delete a serie");
            Console.Write ("Serie id: ");
            int deteleSerieEntry = int.Parse(Console.ReadLine());

            Console.Write ("Do you really want to delete serie number {0} ? (Y/N) ",deteleSerieEntry );
            string answer = Console.ReadLine().ToUpper();

            while (answer != "Y")
            {
                if (answer != "N")
                {
                    Console.WriteLine ("Wrong character! Please press Y or N.");
                    return;
                }
                else
                {
                    return;
                }

            }

            repository.Delete(deteleSerieEntry);
            
        }

        private static void UpdateSerie()
        {
            Console.Write ("Which serie want you update? (id) ");
            int updateSerieEntryId = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre)))
            {

                Console.WriteLine ("{0} - {1}", i, Enum.GetName(typeof(Genre), i));

            }

            Console.Write ("Insert the Genre from the option above: ");
            int genreEntry = int.Parse(Console.ReadLine());

            Console.Write ("Insert the serie title: ");
            string titleEntry = Console.ReadLine();

            Console.Write ("Insert the year of the serie: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write ("Description of the serie: ");
            string descriptionEntry = Console.ReadLine();

            Serie updateSerie = new Serie (id: updateSerieEntryId,
                                           genre: (Genre) genreEntry,
                                           title: titleEntry,
                                           year: yearEntry,
                                           description: descriptionEntry );

            
            repository.Update(updateSerieEntryId, updateSerie);

        }

        private static void InsertSerie()
        {
            Console.WriteLine ("Insert a new serie");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {

                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));

            }

            Console.Write ("Insert the Genre from the option above: ");
            int genreEntry = int.Parse(Console.ReadLine());

            Console.Write ("Insert the serie title: ");
            string titleEntry = Console.ReadLine();

            Console.Write ("Insert the year of the serie: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write ("Description of the serie: ");
            string descriptionEntry = Console.ReadLine();

            Serie newSerie = new Serie (id: repository.NextId(),
                                        genre: (Genre)genreEntry,
                                        title: titleEntry,
                                        year: yearEntry,
                                        description: descriptionEntry);

            
            repository.Insert(newSerie);
        }

        private static void ToListSeries()
        {
            Console.WriteLine ("List series");

            var list = repository.Lista(); 

            if (list.Count == 0)
            {
                Console.WriteLine("No series stored!");
                return;
            }
            foreach (var serie in list)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.returnId(), serie.returnTitle());
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine ();
            Console.WriteLine ("Choose the option you want: ");

            Console.WriteLine ("1- List series");
            Console.WriteLine ("2- Insert a new serie");
            Console.WriteLine ("3- Update series");
            Console.WriteLine ("4- Delete serie");
            Console.WriteLine ("5- See serie");
            Console.WriteLine ("C- Clean screen");
            Console.WriteLine ("X- sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
            
        }
    }
}
