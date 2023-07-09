namespace Divar_Crawler.DTOs
{
    public class BoxPostDto
    {
        public string Titles { get; set; }
        public string Description { get; set; }
        public string BottomDescription { get; set; }
        public string ImageName { get; set; }
        public string Link { get; set; }
        public string SiteName { get; set; }
        public List<string> ImageUrls { get; internal set; }
    }
}
