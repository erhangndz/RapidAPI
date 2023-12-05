namespace RapidAPI.Models
{
    public class MoviesSeriesViewModel
    {

        
            public Search[] search { get; set; }
            public int total { get; set; }
            public bool response { get; set; }
        

        public class Search
        {
            public string id { get; set; }
            public string title { get; set; }
            public int? year { get; set; }
            public int score { get; set; }
            public int? score_average { get; set; }
            public string type { get; set; }
            public string imdbid { get; set; }
            public int? tmdbid { get; set; }
            public int traktid { get; set; }
            public int tvdbid { get; set; }
        }

    }
}
