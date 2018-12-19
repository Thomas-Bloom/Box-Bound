using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public CameraController mainCam;
    public UIManager ui;
    public AudioSource deathSound;

    private CameraShake camShake;

    public ParticleSystem deathParticles;
    public Material playerMat;

    public bool playerIsActive;
    public bool isPaused;
    private bool playerDead;

    public int scoreCount;
    public int bestScore;
    public int coinCount;


    void Start ()
    {
        //print(PlayerPrefs.GetInt("NumberOfDeaths"));
        //Advertisement.Initialize(gameID);

        camShake = FindObjectOfType<CameraShake>();
        ParticleSystem.MainModule deathParticleSettings = deathParticles.main;
        deathParticleSettings.startColor = playerMat.color;

        if(!playerIsActive)
        {
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.jumpSound.enabled = false;
        }
	}
	
	void Update ()
    {
        //if(PlayerPrefs.GetInt("NumberOfDeaths") >= 3)
        //{
        //    ShowAd();
        //    PlayerPrefs.SetInt("NumberOfDeaths", 0);
        //}

        if (playerIsActive)
        {
            player.GetComponent<Rigidbody2D>().simulated = true;
            player.jumpSound.enabled = true;
        }
    
	    if(playerDead)
        {
            float cameraSlowDownSpeed = 3f;

            mainCam.moveSpeed -= cameraSlowDownSpeed * Time.deltaTime;

            if (mainCam.moveSpeed <= 0)
            {
                mainCam.moveSpeed = 0f;
            }
        }

        if(isPaused)
        {
            mainCam.moveSpeed = 0f;
            player.GetComponent<Rigidbody2D>().simulated = false;
            ui.pauseMenuObject.SetActive(true);
        }

        

	}

    public void killPlayer()
    {
        deathSound.Play();
        //PlayerPrefs.SetInt("NumberOfDeaths", PlayerPrefs.GetInt("NumberOfDeaths") + 1);
        //print("Dead: " + PlayerPrefs.GetInt("NumberOfDeaths"));


        if (scoreCount >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", scoreCount);

            Social.ReportScore(scoreCount, "CgkI7YLwzMoREAIQAg", (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    print("Score posted successfully");
                }

                else
                {
                    print("Score unable to be posted");
                }
            });

        }



        camShake.Shake(0.225f, 0.225f);
        player.gameObject.layer = 0;
        player.gameObject.SetActive(false);
        Instantiate(deathParticles, player.transform.position, Quaternion.identity);

        playerDead = true;


        StartCoroutine("timeBeforeDeathMenu");
       // ui.gameUI.pauseButton.GetComponent<Animator>().Play("Shrink_UI");
        ui.gameUI.Score.gameObject.GetComponent<Animator>().Play("Shrink_UI");
    }

    IEnumerator timeBeforeDeathMenu()
    {
        yield return new WaitForSeconds(0.5f);
        ui.deathMenuGeneral.SetActive(true);
    }

    /*
    public void ShowAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    */
}
