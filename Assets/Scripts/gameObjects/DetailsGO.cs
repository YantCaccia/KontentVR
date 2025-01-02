using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DetailsGO : MonoBehaviour
{

    public Image thumbnail;
    public TMP_Text titolo, descrizione, genere, durata, regia, rating;
    public UnityEvent<string> playContenutoEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PopulateDetails(Content contenuto)
    {
        StartCoroutine(DownloadAndSetImage(contenuto.thumbnail));
        titolo.text = Content.DecodeEncodedNonAsciiCharacters(contenuto.title);
        descrizione.text = Content.DecodeEncodedNonAsciiCharacters(contenuto.description);
        genere.text = contenuto.metaInfo.genre;
        durata.text = contenuto.metaInfo.duration.ToString() + " min";
        regia.text = contenuto.metaInfo.director;
        rating.text = "⭐️⭐️⭐️⭐️";
    }

    public void PlayContent(){
        playContenutoEvent.Invoke(titolo.text);
    }

    IEnumerator DownloadAndSetImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
        {
            Texture2D texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
            thumbnail.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

}
