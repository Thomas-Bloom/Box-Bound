using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

[System.Serializable]
public class mainMenuElements
{
    public GameObject gameTitle;
    public GameObject tapToStart;
    public GameObject leaderboardsButton;
    public GameObject shopButton;
    public GameObject twitterButton;
    public GameObject twoFingerText;
    public GameObject line;
}

[System.Serializable]
public class inGameUI
{
    //public GameObject pauseButton;
    public Text Score;
}

[System.Serializable]
public class deathMenu
{
    public GameObject title;
    public GameObject homeButton;
    public Text score;
    public Text bestScore;
    public GameObject background;
    public Text coinCount;
}

[System.Serializable]
public class pauseMenu
{
    public GameObject title;
    public GameObject resumeButton;
    public GameObject homeButton;
    public Text coinCount;
}

[System.Serializable]
public class shopMenu
{
    public GameObject title;
    public GameObject coinCount;

    public GameObject blueEquipButton;
    public GameObject blueImage;

    public GameObject redPrice;
    public GameObject redImage;
    public GameObject redBuyButton;
    public GameObject redEquipButton;

    public GameObject greenPrice;
    public GameObject greenImage;
    public GameObject greenBuyButton;
    public GameObject greenEquipButton;

    public GameObject orangePrice;
    public GameObject orangeImage;
    public GameObject orangeBuyButton;
    public GameObject orangeEquipButton;

    public GameObject DarkPurplePrice;
    public GameObject DarkpurpleImage;
    public GameObject DarkpurpleBuyButton;
    public GameObject DarkpurpleEquipButton;

    public GameObject pinkPrice;
    public GameObject pinkImage;
    public GameObject pinkBuyButton;
    public GameObject pinkEquipButton;

    public GameObject purplePrice;
    public GameObject purpleImage;
    public GameObject purpleBuyButton;
    public GameObject purpleEquipButton;

    public GameObject homeButton;
}


public class UIManager : MonoBehaviour
{
    public Collider2D[] tapToStartArea;

    public GameManager gm;
    public mainMenuElements mainMenuObjects;
    public inGameUI gameUI;
    public deathMenu deathMenu;
    public pauseMenu pauseMenu;
    public GameObject deathMenuGeneral;
    public GameObject pauseMenuObject;
    public GameObject shopGeneral;
    public GameObject gameUIGeneral;
    public shopMenu shopMenu;
    public Text countdownText;
    public PlayerController player;
    public CameraController mainCam;

    private bool startCountdown;
    public float countdownTimer;
    public GameObject countdownBackground;

    private void Start()
    {
        deathMenu.bestScore.text = "" + PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition = new Vector2(wp.x, wp.y);


            if ((tapToStartArea[0] == Physics2D.OverlapPoint(touchPosition)))
            {
                gm.playerIsActive = true;
                gameUIGeneral.SetActive(true);
                tapToStartArea[0].gameObject.SetActive(false);
                HideMainMenu();
                //gameUI.pauseButton.SetActive(true);
                gameUI.Score.gameObject.SetActive(true);
            }
        }

        gameUI.Score.text = "" + gm.scoreCount;
        deathMenu.score.text = "" + gm.scoreCount;
        deathMenu.bestScore.text = "" + PlayerPrefs.GetInt("HighScore");

        pauseMenu.coinCount.text = "" + PlayerPrefs.GetInt("CoinCount");
        deathMenu.coinCount.text = "" + PlayerPrefs.GetInt("CoinCount");

        if (startCountdown)
        {
            countdownBackground.SetActive(true);
            HidePauseUI();
            pauseMenuObject.SetActive(false);
            //pauseMenu.title.GetComponent<Animator>().Play("Shrink_UI");
            //pauseMenu.resumeButton.GetComponent<Animator>().Play("Shrink_UI");
            //pauseMenu.homeButton.GetComponent<Animator>().Play("Shrink_UI");


            //countdownText.gameObject.SetActive(true);

            countdownTimer -= Time.deltaTime;

            if (countdownTimer < 3 && countdownTimer > 2.3)
            {
                countdownText.text = "3";
            }

            if (countdownTimer > 2 && countdownTimer < 2.2)
            {
                countdownText.text = "2";
            }

            if (countdownTimer > 1 && countdownTimer < 1.2)
            {
                countdownText.text = "1";
            }

            if (countdownTimer >= 0 && countdownTimer <= 0.3)
            {
                gm.isPaused = false;
                mainCam.moveSpeed = 5f;
                countdownText.text = "";
                player.GetComponent<Rigidbody2D>().simulated = true;
                startCountdown = false;               
                countdownTimer = 3f;
                countdownBackground.SetActive(false);
            }

        }

        
    }

    public void LeaderboardsMenu()
    {
        print("Leaderboards");
    }

    public void shopButton()
    {
        HideMainMenu();
        tapToStartArea[0].gameObject.SetActive(false);
        //tapToStartArea[1].gameObject.SetActive(false);
        shopGeneral.SetActive(true);
    }

    public void InstagramButton()
    {
        Application.OpenURL("https://www.instagram.com/bloomydev/");
    }

    void HideMainMenu()
    {
        mainMenuObjects.gameTitle.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.gameTitle.SetActive(false);

        mainMenuObjects.leaderboardsButton.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.leaderboardsButton.SetActive(false);

        mainMenuObjects.tapToStart.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.tapToStart.SetActive(false);

        mainMenuObjects.twitterButton.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.twitterButton.SetActive(false);

        mainMenuObjects.shopButton.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.shopButton.SetActive(false);

        mainMenuObjects.twoFingerText.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.twoFingerText.SetActive(false);

        mainMenuObjects.line.GetComponent<Animator>().Play("Shrink_UI");
        mainMenuObjects.line.SetActive(false);
    }

    void showMainMenu()
    {
        mainMenuObjects.gameTitle.SetActive(true);
        mainMenuObjects.leaderboardsButton.SetActive(true);
        mainMenuObjects.tapToStart.SetActive(true);
        mainMenuObjects.twitterButton.SetActive(true);
        mainMenuObjects.shopButton.SetActive(true);
        mainMenuObjects.twoFingerText.SetActive(true);
        mainMenuObjects.line.SetActive(true);


    }


    void HideGameUI()
    {
       // gameUI.pauseButton.GetComponent<Animator>().Play("Shrink_UI");

        gameUI.Score.GetComponent<Animator>().Play("Shrink_UI");
    }

    /*
    public void openDeathMenu()
    {
        deathMenu.title.SetActive(true);
        deathMenu.homeButton.SetActive(true);
        //deathMenu.score.SetActive(true);
        deathMenu.background.SetActive(true);
    }
    */

    void HidePauseUI()
    {
        pauseMenu.title.GetComponent<Animator>().Play("Shrink_UI");
        //pauseMenu.title.SetActive(false);

        pauseMenu.resumeButton.GetComponent<Animator>().Play("Shrink_UI");
        //pauseMenu.resumeButton.SetActive(false);

        pauseMenu.homeButton.GetComponent<Animator>().Play("Shrink_UI");
        //pauseMenu.homeButton.SetActive(false);
    }

    public void HomeButtonInGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButtonMainMenu()
    {
        HideShop();
        showMainMenu();
    }

    public void shopHomeButton()
    {
        HideShop();
        
    }

    public void ResumeGame()
    {
        startCountdown = true;

    }

    public void HideShop()
    {
        //shopMenu.title.SetActive(false);

        //shopMenu.coinCount.SetActive(false);

        //shopMenu.homeButton.SetActive(false);

        // BLUE
        shopMenu.blueEquipButton.SetActive(false);
        shopMenu.blueImage.SetActive(false);

        // RED
        shopMenu.redPrice.SetActive(false);
        shopMenu.redImage.SetActive(false);
        shopMenu.redBuyButton.SetActive(false);
        shopMenu.redEquipButton.SetActive(false);

        //shopGeneral.SetActive(false);

        // GREEN
        shopMenu.greenPrice.SetActive(false);
        shopMenu.greenImage.SetActive(false);
        shopMenu.greenBuyButton.SetActive(false);
        shopMenu.greenEquipButton.SetActive(false);

        // ORANGE
        shopMenu.orangePrice.SetActive(false);
        shopMenu.orangeImage.SetActive(false);
        shopMenu.orangeBuyButton.SetActive(false);
        shopMenu.orangeEquipButton.SetActive(false);

        // Purple
        shopMenu.purplePrice.SetActive(false);
        shopMenu.purpleImage.SetActive(false);
        shopMenu.purpleBuyButton.SetActive(false);
        shopMenu.purpleEquipButton.SetActive(false);

        // Dark Purple
        shopMenu.DarkPurplePrice.SetActive(false);
        shopMenu.DarkpurpleImage.SetActive(false);
        shopMenu.DarkpurpleBuyButton.SetActive(false);
        shopMenu.DarkpurpleEquipButton.SetActive(false);

        // Pink
        shopMenu.pinkPrice.SetActive(false);
        shopMenu.pinkImage.SetActive(false);
        shopMenu.pinkBuyButton.SetActive(false);
        shopMenu.pinkEquipButton.SetActive(false);


    }

    public void showShop()
    {
        shopMenu.title.SetActive(true);

        shopMenu.coinCount.SetActive(true);

        shopMenu.homeButton.SetActive(true);

        // BLUE
        shopMenu.blueEquipButton.SetActive(true);
        shopMenu.blueImage.SetActive(true);

        // RED
        shopMenu.redPrice.SetActive(true);
        shopMenu.redImage.SetActive(true);
        shopMenu.redBuyButton.SetActive(true);
        shopMenu.redEquipButton.SetActive(true);

        // GREEN
        shopMenu.greenPrice.SetActive(true);
        shopMenu.greenImage.SetActive(true);
        shopMenu.greenBuyButton.SetActive(true);
        shopMenu.greenEquipButton.SetActive(true);

        // ORANGE
        shopMenu.orangePrice.SetActive(true);
        shopMenu.orangeImage.SetActive(true);
        shopMenu.orangeBuyButton.SetActive(true);
        shopMenu.orangeEquipButton.SetActive(true);

        // Purple
        shopMenu.purplePrice.SetActive(true);
        shopMenu.purpleImage.SetActive(true);
        shopMenu.purpleBuyButton.SetActive(true);
        shopMenu.purpleEquipButton.SetActive(true);

        // Dark Purple
        shopMenu.DarkPurplePrice.SetActive(true);
        shopMenu.DarkpurpleImage.SetActive(true);
        shopMenu.DarkpurpleBuyButton.SetActive(true);
        shopMenu.DarkpurpleEquipButton.SetActive(true);

        // Pink
        shopMenu.pinkPrice.SetActive(true);
        shopMenu.pinkImage.SetActive(true);
        shopMenu.pinkBuyButton.SetActive(true);
        shopMenu.pinkEquipButton.SetActive(true);

    }


}
