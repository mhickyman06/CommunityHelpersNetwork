using System;
 namespace HelpersNetwork.Models
{    public class YouTubeVideoDetails
    {
        public int InbuiltId { get; set; }
        public string VideoId { get; set; }
        public string VideoUrl { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }
        public string ChannelTitle { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime? PublicationDate { get; set; }


    }
}