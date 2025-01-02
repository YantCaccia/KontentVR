using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarouselGO : MonoBehaviour
{

    public Carousel carousel;
    public ContentGO content1, content2, content3, content4;
    public TMP_Text titolo;

    // Start is called before the first frame update
    void Start()
    {
        titolo = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PopulateContentGO(Carousel carousel)
    {
        this.carousel = carousel;
        titolo.text = carousel.title;
        content1.PopulateContent(carousel.items[0]);
        content2.PopulateContent(carousel.items[1]);
        content3.PopulateContent(carousel.items[2]);
        content4.PopulateContent(carousel.items[3]);
    }

    public void onDisplayContentDetails(Content contenuto){
        UIManager.Instance.ShowDetails(contenuto);
    }

}
