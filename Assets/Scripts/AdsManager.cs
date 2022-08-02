using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{
    private string gameID = "4828937";

    Action onRewardedSuccess;
    //public string intersitialAd = "Interstitial_Android";
    //public ShowResult newShowResult;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }
    //public bool AdFinished(string placementId, ShowResult showResult)
    //{
    //    showResult = newShowResult;
    //    if (placementId == "Interstitial_Android" && newShowResult == ShowResult.Finished)
    //    {
    //        return true;
    //    }else
    //        return false;
    //}
    public void PlayRewardedVideo(Action onSuccess)
    {
        onRewardedSuccess = onSuccess;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
            Debug.Log("Rewarded ad is not ready !");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR : "+message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("Video finished!!");
            onRewardedSuccess.Invoke();
        }
    }
}
