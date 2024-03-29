using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private BannerView bannerAD;
    //private int width;
    string officialBanner = "ca-app-pub-3713044553948028/7023951344";

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AD");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        //width = Screen.width;
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
        if (bannerAD != null)
        {
            bannerAD.Destroy();
        }

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif
        AdSize adaptiveSize = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerAD = new BannerView(officialBanner, adaptiveSize,AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerAD.LoadAd(request);
    }
}
