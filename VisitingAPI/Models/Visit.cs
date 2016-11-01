using System;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VisitingAPI.Models
{
    public class Visit
    {
        [JsonProperty(PropertyName = "Id")]
        public ObjectId Id { get; set; }
        [JsonProperty(PropertyName = "SiteUrl", Required = Required.Always)]
        public string SiteUrl { get; set; }
        [JsonProperty(PropertyName = "IpAddress"), Required(ErrorMessage = "IP address is required", AllowEmptyStrings = false)]
        public string IpAddress { get; set; }
        [JsonProperty(PropertyName = "State"), Required(ErrorMessage = "State is required", AllowEmptyStrings = false)]
        public string State { get; set; }
        [JsonProperty(PropertyName = "DateTimeOfVisit")]
        public DateTime DateTimeOfVisit { get; set; }
    }
}