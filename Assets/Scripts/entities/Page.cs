using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Page
{
    [JsonProperty("id")]
    public int id { get; set; }
    [JsonProperty("alias")]
    public string alias { get; set;}
    [JsonProperty("nome")]
    public string name { get; set;}
    [JsonProperty("content")]
    public List<Carousel> carousels { get; set;} = new List<Carousel>();
    
}
