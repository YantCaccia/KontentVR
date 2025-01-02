using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContentSearchGO : MonoBehaviour
{
    public Image image_ref;
    public TMP_Text titolo;

    public Content content;

    public UnityEvent<Content> displayContentDetails;
    public Button button;

    internal void PopulateContentSearchGO(Content content)
    {

        this.content = content;
        StartCoroutine(DownloadImage(content.thumbnail));
        titolo.text= content.title;
    }

    void Start()
    {
        button.onClick.AddListener(() => DisplayContentDetails(content));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError){
            Debug.Log(request.error);
        }else {
            Texture2D texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
            image_ref.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    public void DisplayContentDetails(Content contenuto){
        displayContentDetails.Invoke(contenuto);
        UIManager.Instance.ShowDetails(contenuto);
    }
}