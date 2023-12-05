namespace RapidAPI.Models
{
    public class TranslateViewModel
    {

        
            public string status { get; set; }
            public Data data { get; set; }
        

        public class Data
        {
            public string translatedText { get; set; }
        }

    }
}
