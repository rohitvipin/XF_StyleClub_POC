using System;
using Newtonsoft.Json;

namespace XF_StyleClub_POC.Models
{
    public class Product
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("VideoUrl")]
        public string VideoUrl { get; set; }

        [JsonProperty("WebsiteUrl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("OwnerImageUrl")]
        public string OwnerImageUrl { get; set; }

        [JsonProperty("OwnerName")]
        public string OwnerName { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }
    }
}