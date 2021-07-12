using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private string gameId = "4214613";
    public string surfacingId = "bannerPlacement";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(surfacingId);
    }
}
