using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
// using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{

    public static Page page;
    public static List<Carousel> caroselli;
    public List<CarouselGO> caroselliGO;

    public SearchGO searchGO;
    public CarouselGO profileCarousel;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        caroselli = new List<Carousel>();
        StartCoroutine(getRequest("http://wpdev.kinedev.it/wp-content/api/getApi2.php?data=mngk&type=get-page&id=testpage"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        uwr.certificateHandler = new CertificateWhore();
        uwr.SetRequestHeader("Application", "feb7a85ece0ad8a76fa5bad1780d3d37");
        uwr.SetRequestHeader("Authorization", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoiYXBwLWNoYWxsZW5nZS0yMDIzLTI0IiwiZXhwIjoxNzAyOTc3MDExLCJpc3MiOiIxMyIsImlhdCI6MTcwMjg5MDYxMX0.nH4YFG-EOvTvVncJ5yvApV_5lFHbRr9ukDhVBoTJLIs");
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            string recJson = uwr.downloadHandler.text;
            Debug.Log("Received: " + recJson);

            Dictionary<string, object> responseAsJSON = JsonConvert.DeserializeObject<Dictionary<string, object>>(recJson);

            page = JsonConvert.DeserializeObject<Page>(responseAsJSON.GetValueOrDefault("data").ToString());

            foreach (Carousel carousel in page.carousels)
            {
                caroselli.Add(carousel);
            }
            FillCarouselliGO();
        }
    }

    private void FillCarouselliGO()
    {
        for (int i = 0; i < caroselliGO.Count; i++)
        {
            // it has to be #carouselOnCMS >= #carouselDispalyedOnMainPage
            caroselliGO[i].PopulateContentGO(caroselli[i]);
        }
        // FillProfileCarousel();
    }

    public void FillProfileCarousel()
    {
        Carousel tmp = new Carousel();
        tmp.title = "Recenti";
        tmp.items = caroselli[0].items;
        tmp.id = caroselli[0].id;
        tmp.type = caroselli[0].type;
        profileCarousel.PopulateContentGO(tmp);
    }

    public void onPlayContenutoEvent(string title)
    {
        foreach (Carousel carousel in caroselli)
        {
            foreach (Content item in carousel.items)
            {
                if (item.title == title)
                {
                    UIManager.Instance.PlayVideo(item.metaInfo.dash);
                    return;
                }
            }
        }
    }


    public void SearchPage(UnityEngine.UI.Text ricerca)
    {
        if (ricerca.text != null && ricerca.text != "")
        {
            UIManager.Instance.ShowSearchDetails();
            List<Content> contenuti = FilterContent(ricerca.text);
            searchGO.PopulateSearchGO(ricerca.text, contenuti);
        }
    }

    public void SearchPage(string ricerca)
    {
        UIManager.Instance.ShowSearchDetails();
        List<Content> contenuti = FilterContent(ricerca);
        searchGO.PopulateSearchGO(ricerca, contenuti);
    }

    private List<Content> FilterContent(string ricerca)
    {
        List<Content> contenuti = new List<Content>();
        foreach (Carousel carosello in caroselli)
        {
            foreach (Content content in carosello.items)
            {
                if (string.Equals(content.metaInfo.genre, ricerca, StringComparison.OrdinalIgnoreCase) || content.title.IndexOf(ricerca, StringComparison.OrdinalIgnoreCase) >= 0)
                    if (!contenuti.Contains(content))
                    contenuti.Add(content);
            }
        }

        return contenuti;
    }
}
