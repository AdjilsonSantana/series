using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Delete(int id)
        {
            // ListSerie.RemoveAt (id);
            listSerie[id].ToDelete();
        }

        public void Insert(Serie objeto)
        {
            listSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public Serie ReturnById(int id)
        {
            return listSerie[id];
        }

        public void Update(int id, Serie objeto)
        {
            listSerie[id] = objeto;
        }
    }
}