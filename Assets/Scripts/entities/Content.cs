using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class Content
{
    [JsonProperty("id")]
    public string id { get; set; }
    [JsonProperty("title")]
    public string title { get; set; }
    [JsonProperty("description")]
    public string description { get; set; }
    [JsonProperty("thumbnail")]
    public string thumbnail { get; set; }
    [JsonProperty("metaInfo")]
    public MetaInfo metaInfo;

    public static string DecodeEncodedNonAsciiCharacters(string i)
    {
        // Deserialize using class
        // string sample = JsonConvert.DeserializeObject<string>(i.Trim());
        byte[] bytes = Encoding.Unicode.GetBytes(i);
        List<byte> pulito = new List<byte>();
        foreach (byte bait in bytes)
        {
            int tmp = bait;
            if (tmp != 0)
            {
                pulito.Add(bait);
            }
        }
        // byte[] moreBytes = Encoding.Convert(Encoding.Unicode, Encoding.UTF8, bytes);
        string myString = Encoding.UTF8.GetString(pulito.ToArray());
        myString = myString.Replace("\\", "");
        return myString;
    }

    public override bool Equals(object obj)
    {

        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        return title == ((Content)obj).title;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}

[System.Serializable]
public class MetaInfo
{
    [JsonProperty("dash")]
    public string dash { get; set; }

    [JsonProperty("genre")]
    public string genre { get; set; }

    [JsonProperty("duration")]
    public int duration { get; set; }

    [JsonProperty("director")]
    public string director { get; set; }
}