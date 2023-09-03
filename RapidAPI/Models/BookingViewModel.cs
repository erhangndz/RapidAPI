namespace RapidAPI.Models
{
    public class BookingViewModel
    {

       
            public int count { get; set; }
            public Mappagefields mapPageFields { get; set; }
            public Result[] results { get; set; }
    

        public class Mappagefields
        {
            public Boundingbox boundingBox { get; set; }
            public Propertyannotation[] propertyAnnotations { get; set; }
        }

        public class Boundingbox
        {
            public float neLat { get; set; }
            public float neLon { get; set; }
            public float swLat { get; set; }
            public float swLon { get; set; }
        }

        public class Propertyannotation
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public int mainPhotoId { get; set; }
            public string photoMainUrl { get; set; }
            public string[] photoUrls { get; set; }
            public int position { get; set; }
            public int rankingPosition { get; set; }
            public string countryCode { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public Pricebreakdown priceBreakdown { get; set; }
            public string currency { get; set; }
            public Checkin checkin { get; set; }
            public Checkout checkout { get; set; }
            public string checkoutDate { get; set; }
            public string checkinDate { get; set; }
            public float reviewScore { get; set; }
            public string reviewScoreWord { get; set; }
            public int reviewCount { get; set; }
            public int qualityClass { get; set; }
            public bool isFirstPage { get; set; }
            public int accuratePropertyClass { get; set; }
            public int propertyClass { get; set; }
            public int ufi { get; set; }
            public string wishlistName { get; set; }
            public int optOutFromGalleryChanges { get; set; }
        }

        public class Pricebreakdown
        {
            public Grossprice grossPrice { get; set; }
            public Strikethroughprice strikethroughPrice { get; set; }
            public Benefitbadge[] benefitBadges { get; set; }
            public object[] taxExceptions { get; set; }
        }

        public class Grossprice
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Strikethroughprice
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Benefitbadge
        {
            public string variant { get; set; }
            public string text { get; set; }
            public string identifier { get; set; }
            public string explanation { get; set; }
        }

        public class Checkin
        {
            public string fromTime { get; set; }
            public string untilTime { get; set; }
        }

        public class Checkout
        {
            public string untilTime { get; set; }
            public string fromTime { get; set; }
        }

    }
}
