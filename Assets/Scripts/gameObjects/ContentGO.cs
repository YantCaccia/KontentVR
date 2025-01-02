using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ContentGO : MonoBehaviour
{

    public Content content;
    public Image image_ref;
    public Button button;
    public UnityEvent<Content> displayContentDetails;

    // Start is called before the first frame update
    void Start()
    {
        image_ref = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => DisplayContentDetails(content));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PopulateContent(Content content)
    {
        this.content = content;
        StartCoroutine(DownloadImage(content.thumbnail));

    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else {
            Texture2D texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
            image_ref.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    public void DisplayContentDetails(Content contenuto){
        displayContentDetails.Invoke(contenuto);
    }

}
