using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class GooglePlayManager : MonoBehaviour {

    #region DEFAULT_UNITY_CALLBACKS
    // Use this for initialization
    void Start ()
    {
        //PlayGamesPlatform.DebugLogEnabled = true;

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name.Equals("Developer"))
        {
            PlayGamesPlatform.Activate();
            SignIn();
        }
	}
    #endregion

    void SignIn()
    {
        Social.localUser.Authenticate((bool success) => {
            if(success)
            {
                print("Login Successful");
            }

            else
            {
                print("Login NOT Successful");
            }
        });
    }

    public void showLeaderboard()
    {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkI7YLwzMoREAIQAg");
    }

}
