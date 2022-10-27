using UnityEngine;
using UnityEngine.Advertisements;

public class unityadslevels : MonoBehaviour, IUnityAdsInitializationListener
{
    public static unityadslevels instance;
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;
    [SerializeField] rewardads reewardedads;





    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        reewardedads.LoadAd();


    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }






}