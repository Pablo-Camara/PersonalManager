namespace PersonalManager.Data.Models.MetaData
{

    public class MetaInformation
    {
        public bool HasData { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string ImageUrl { get; set; }
        public string SiteName { get; set; }

        public MetaInformation(string url)
        {
            Url = url;
            HasData = false;
        }

    }
}
