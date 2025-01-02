using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SearchGO : MonoBehaviour
{
    public List<ContentSearchGO> contentsGO;
    public ContentSearchGO contentGO;
    private ContentSearchGO content;
    public TMP_Text titolo;

    public ScrollRect scroll; 
    public RectTransform scrollContent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    public void PopulateSearchGO(string ricerca, List<Content> contenuti)
    {
        contentsGO.ForEach(obj => Destroy(obj.gameObject));
        contentsGO.Clear();
        if(contenuti == null || contenuti.Count==0){
            titolo.text = "Nessun risultato per " + ricerca;
        }else{
            titolo.text = "Risultati per " + ricerca;

            for(int i=0; i<contenuti.Count; i++){
                contentsGO.Add(Instantiate(contentGO,scrollContent));
                contentsGO[i].PopulateContentSearchGO(contenuti[i]);
           }
        }
        scroll.verticalNormalizedPosition = 1;
    }

    public void onDisplayContentDetails(Content contenuto){
        UIManager.Instance.ShowDetails(contenuto);
    }

}
