namespace RapidAPI.Models
{
    public class TwitterViewModel
    {

       
            public string creation_date { get; set; }
            public string user_id { get; set; }
            public string username { get; set; }
            public string name { get; set; }
            public int follower_count { get; set; }
            public int following_count { get; set; }
            public int favourites_count { get; set; }
            public object is_private { get; set; }
            public bool is_verified { get; set; }
            public bool is_blue_verified { get; set; }
            public string location { get; set; }
            public string profile_pic_url { get; set; }
            public string profile_banner_url { get; set; }
            public string description { get; set; }
            public object external_url { get; set; }
            public int number_of_tweets { get; set; }
            public bool bot { get; set; }
            public int timestamp { get; set; }
            public bool has_nft_avatar { get; set; }
            public object category { get; set; }
            public bool default_profile { get; set; }
            public bool default_profile_image { get; set; }
            public object listed_count { get; set; }
        

    }
}
