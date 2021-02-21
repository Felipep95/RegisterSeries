using System;

namespace SeriesRegistration.Classes
{
    public class Serie : BaseEntity
    {
        // Attributes
        private Genre _genre { get; set; }
        private string _title { get; set; }
        private string _description { get; set; }
        private int _year { get; set; }
        private bool _deleted { get; set; }


        // Methods
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            _id = id;
            _genre = genre;
            _title = title;
            _description = description;
            _year = year;
            _deleted = false;
        }

        public override string ToString()
        {
            string strReturn = "";
            strReturn += "Genre: " + _genre + Environment.NewLine;
            strReturn += "Title: " + _title + Environment.NewLine;
            strReturn += "Description: " + _description + Environment.NewLine;
            strReturn += "Start Year: " + _year + Environment.NewLine;
            strReturn += "Deleted: " + _deleted;
            
            return strReturn;
        }

        public string returnTitle()
        {
            return _title;
        }

        public int returnId()
        {
            return _id;
        }

        public bool returnDeleted()
        {
            return _deleted;
        }

        public void Delete()
        {
            _deleted = true;
        }
    }
}
