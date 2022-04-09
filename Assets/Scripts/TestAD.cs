using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class TestAD : MonoBehaviour , IUnityAdsListener
{
    public static TestAD instance;

    string GameID = "4487839";
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GameID);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // ShowAds();
            RewardAD();
            
        }


    }

    public void ShowAds()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show();

        }
    }
    public void RewardAD()
    {

        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");

        }

    }

    public void OnUnityAdsReady(string placementId)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //Reward the user
        if(showResult == ShowResult.Finished)
        {
            print("Reward User");
        }

        if (showResult == ShowResult.Skipped)
        {
            print("User Skipped the add");
        }
    }
}
