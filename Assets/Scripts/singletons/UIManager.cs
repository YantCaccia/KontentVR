using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{

    public enum Screens
    {
        HOME, SEARCH, PROFILE, PLAYER, DETAILS, SEARCHDETAILS
    }

    public GameObject homeScreen, contentDetailsScreen, searchScreen, profileScreen, videoPlayerScreen, searchDetailsScreen, tabbar;

    public static UIManager Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

    public void ShowDetails(Content contenuto)
    {
        DisableAllScreens();
        DisableAllTabbarButtons();
        contentDetailsScreen.SetActive(true);
        contentDetailsScreen.GetComponent<DetailsGO>().PopulateDetails(contenuto);

    }

    public void ShowSearchDetails()
    {
        DisableAllScreens();
        DisableAllTabbarButtons();
        ChangeScreen(Screens.SEARCHDETAILS);
        
    }

    public void PlayVideo(string url)
    {
        DisableAllScreens();
        tabbar.SetActive(false);
        videoPlayerScreen.SetActive(true);
        videoPlayerScreen.GetComponentInChildren<MediaPlayer>().OpenMedia(new MediaPath(url, MediaPathType.AbsolutePathOrURL), autoPlay: false);
        videoPlayerScreen.GetComponentInChildren<MediaPlayer>().Play();

    }

    public void StopVideo()
    {
        ChangeScreen(Screens.DETAILS);
        tabbar.SetActive(true);
    }

    public void ChangeScreen(Screens screenToDisplay)
    {
        DisableAllScreens();
        switch (screenToDisplay)
        {
            case Screens.HOME:
                homeScreen.SetActive(true);
                break;
            case Screens.SEARCH:
                searchScreen.SetActive(true);
                break;
            case Screens.PROFILE:
                profileScreen.SetActive(true);
                GameManager.Instance.FillProfileCarousel();
                break;
            case Screens.DETAILS:
                contentDetailsScreen.SetActive(true);
                break;
            case Screens.SEARCHDETAILS:
                searchDetailsScreen.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void DisableAllScreens()
    {
        contentDetailsScreen.SetActive(false);
        homeScreen.SetActive(false);
        searchScreen.SetActive(false);
        profileScreen.SetActive(false);
        videoPlayerScreen.SetActive(false);
        searchDetailsScreen.SetActive(false);
    }

    public void DisableAllTabbarButtons()
    {
        NavMenuElementGO[] buttons = tabbar.GetComponentsInChildren<NavMenuElementGO>();
        foreach (NavMenuElementGO toDisable in buttons){
            toDisable.DisableButton();
        }
    }
}
