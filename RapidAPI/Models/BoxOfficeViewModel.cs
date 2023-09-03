namespace RapidAPI.Models
{
    public class BoxOfficeViewModel
    {

        
        
            public Movie_Results[] movie_results { get; set; }
            public int results { get; set; }
            public string Total_results { get; set; }
            public string status { get; set; }
            public string status_message { get; set; }
        

        public class Movie_Results
        {
            public string title { get; set; }
            public string year { get; set; }
            public string imdb_id { get; set; }
        }

    }
}
