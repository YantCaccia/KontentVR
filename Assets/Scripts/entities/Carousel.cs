using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Carousel {
    [JsonProperty("id")]
    public string id { get; set;}
    [JsonProperty("title")]
    public string title { get; set;}
    [JsonProperty("type")]
    public string type { get; set;}
    //public string orientation { get; set;}
    [JsonProperty("items")]
    public List<Content> items { get; set;} = new List<Content>();

}
