using SeriesRegistration.Classes;
using SeriesRegistration.Interfaces;
using System.Collections.Generic;

namespace SeriesRegistration
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();

        public void Delete(int id)
        {
            listSerie[id].Delete();
        }

        public void Insert(Serie serie)
        {
            listSerie.Add(serie);
        }

        public List<Serie> List()
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

        public void Update(int id, Serie serie)
        {
            listSerie[id] = serie;
        }
    }
}
