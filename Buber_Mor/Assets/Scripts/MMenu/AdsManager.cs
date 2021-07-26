using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    public int howMany = 0;
    private BannerView bannerAD;
    string officialBanner = "ca-app-pub-3713044553948028/7023951344";
    string testBanner = "ca-app-pub-3940256099942544/6300978111";

    private void Awake()
    {
        howMany = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AD");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        RequestBanner();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


        bannerAD = new BannerView(officialBanner, AdSize.SmartBanner, AdPosition.Bottom); //!!!!!!!!!!!!!!!!!!

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerAD.LoadAd(request);
        
        
        howMany++;//number of loaded ads


        //Detects if there are more than 1 ad loaded at a time, if so it destroys all loaded ads and requests a new one.
        if (howMany > 1)
        {
            bannerAD.Destroy();
            howMany = 0;
            RequestBanner();
        }
    }
}
