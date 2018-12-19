using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

    public UIManager uiManager;
    public GameManager gm;
    public Material playerMat;
    public AudioSource buyButtonSound;

    private Color32 playerColour;

    public GameObject confirmPurchasePanel;

    public Text totalCurrency;
    private int redPrice = 70, greenPrice = 40, orangePrice = 20, purplePrice = 15, pinkPrice = 100, darkPurplePrice = 10;

    public Text redBuyButtonText, greenBuyButtonText, orangeBuyButtonText, darkPurpleButtonText, pinkBuyButtonText, purpleBuyButtonText;
    public Button redBuyButton, greenBuyButton, orangeBuyButton, darkPurpleButton, pinkBuyButton, purpleBuyButton;
    public Button redEquipButton, greenEquipButton, orangeEquipButton, darkPurpleEquipButton, pinkEquipButton, purpleEquipButton;

    private bool redSelected, greenSelected, orangeSelected, darkPurpleSelected, pinkSelected, purpleSelected;
    private bool redPurchased, greenPurchased, orangePurchased, darkPurplePurchased, pinkPurchased, purplePurchased;

    public GameObject purchasedScreen;
    public GameObject notEnoughMoneyScreen;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        totalCurrency.text = "" + PlayerPrefs.GetInt("CoinCount");

        if(redPurchased)
        {
            redBuyButton.interactable = false;
            redBuyButtonText.fontSize = 45;
            redBuyButton.gameObject.SetActive(false);
        }

        // Check to see if they are already purchased
        if (PlayerPrefs.GetInt("RedPurchased") == 1)
        {
            redBuyButton.gameObject.SetActive(false);
            //shopMenu.redEquipButton.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("GreenPurchased") == 1)
        {
            greenBuyButton.gameObject.SetActive(false);
            //shopMenu.greenEquipButton.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("OrangePurchased") == 1)
        {
            orangeBuyButton.gameObject.SetActive(false);
            //shopMenu.orangeEquipButton.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("darkPurplePurchased") == 1)
        {
            darkPurpleButton.gameObject.SetActive(false);
            //shopMenu.darkPurpleEquipButton.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("PinkPurchased") == 1)
        {
            pinkBuyButton.gameObject.SetActive(false);
            //shopMenu.pinkEquipButton.gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("PurplePurchased") == 1)
        {
            purpleBuyButton.gameObject.SetActive(false);
            //shopMenu.pinkEquipButton.gameObject.SetActive(true);
        }
    }

    public void buyButtonPressed()
    {
        confirmPurchasePanel.SetActive(true);

        if (EventSystem.current.currentSelectedGameObject.name.Equals("Red Buy Button"))
        {
            redSelected = true;
            uiManager.HideShop();
            //print("red");
        }

        if (EventSystem.current.currentSelectedGameObject.name.Equals("Green Buy Button"))
        {
            greenSelected = true;
            uiManager.HideShop();
        }

        if (EventSystem.current.currentSelectedGameObject.name.Equals("Orange Buy Button"))
        {
            orangeSelected = true;
            uiManager.HideShop();
        }

        if (EventSystem.current.currentSelectedGameObject.name.Equals("Dark Purple Buy Button"))
        {
            darkPurpleSelected = true;
            uiManager.HideShop();
        }

        if (EventSystem.current.currentSelectedGameObject.name.Equals("Pink Buy Button"))
        {
            pinkSelected = true;
            uiManager.HideShop();
        }

        if (EventSystem.current.currentSelectedGameObject.name.Equals("Purple Buy Button"))
        {
            purpleSelected = true;
            uiManager.HideShop();
        }

    }

    public void checkIfCanBuy()
    {
        if(redSelected)
        {
            if(PlayerPrefs.GetInt("CoinCount") >= redPrice)
            {
                buyButtonSound.Play();
                purchasedScreen.GetComponent<Animator>().Play("MessageZoom");
                redEquipButton.gameObject.SetActive(true);
                print(purchasedScreen.name);
                redPurchased = true;
                PlayerPrefs.SetInt("RedPurchased", 1);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - redPrice); 
                
                closePurchaseScreen();

              
            }

            else
            {
                notEnoughMoneyScreen.GetComponent<Animator>().Play("MessageZoom");

                closePurchaseScreen();

                

            }
        }

        if (greenSelected)
        {
            if (PlayerPrefs.GetInt("CoinCount") >= greenPrice)
            {
                buyButtonSound.Play();
                purchasedScreen.GetComponent<Animator>().Play("MessageZoom");
                greenEquipButton.gameObject.SetActive(true);
                print(purchasedScreen.name);
                greenPurchased = true;
                PlayerPrefs.SetInt("GreenPurchased", 1);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - greenPrice);

                closePurchaseScreen();

       
            }

            else
            {
                notEnoughMoneyScreen.GetComponent<Animator>().Play("MessageZoom");

                closePurchaseScreen();

            }
        }

        if (orangeSelected)
        {
            if (PlayerPrefs.GetInt("CoinCount") >= orangePrice)
            {
                buyButtonSound.Play();
                purchasedScreen.GetComponent<Animator>().Play("MessageZoom");
                orangeEquipButton.gameObject.SetActive(true);
                print(purchasedScreen.name);
                orangePurchased = true;
                PlayerPrefs.SetInt("OrangePurchased", 1);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - orangePrice);

                closePurchaseScreen();
            }

            else
            {
                notEnoughMoneyScreen.GetComponent<Animator>().Play("MessageZoom");

                closePurchaseScreen();
            }
        }

        if (darkPurpleSelected)
        {
            if (PlayerPrefs.GetInt("CoinCount") >= darkPurplePrice)
            {
                buyButtonSound.Play();
                purchasedScreen.GetComponent<Animator>().Play("MessageZoom");
                darkPurpleEquipButton.gameObject.SetActive(true);
                print(purchasedScreen.name);
                darkPurplePurchased = true;
                PlayerPrefs.SetInt("darkPurplePurchased", 1);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - darkPurplePrice);

                closePurchaseScreen();
            }

            else
            {
                notEnoughMoneyScreen.GetComponent<Animator>().Play("MessageZoom");

                closePurchaseScreen();
            }
        }

        if (pinkSelected)
        {
            if (PlayerPrefs.GetInt("CoinCount") >= pinkPrice)
            {
                buyButtonSound.Play();
                purchasedScreen.GetComponent<Animator>().Play("MessageZoom");
                pinkEquipButton.gameObject.SetActive(true);
                print(purchasedScreen.name);
                pinkPurchased = true;
                PlayerPrefs.SetInt("PinkPurchased", 1);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - pinkPrice);

                closePurchaseScreen();
            }

            else
            {
                notEnoughMoneyScreen.GetComponent<Animator>().Play("MessageZoom");

                closePurchaseScreen();
            }
        }

        if (purpleSelected)
        {
            if (PlayerPrefs.GetInt("CoinCount") >= purplePrice)
            {
                buyButtonSound.Play();
                purchasedScreen.GetComponent<Animator>().Play("MessageZoom");
                purpleEquipButton.gameObject.SetActive(true);
                print(purchasedScreen.name);
                purplePurchased = true;
                PlayerPrefs.SetInt("PurplePurchased", 1);
                PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") - purplePrice);

                closePurchaseScreen();
            }

            else
            {
                notEnoughMoneyScreen.GetComponent<Animator>().Play("MessageZoom");

                closePurchaseScreen();
            }
        }

    }

    public void closePurchaseScreen()
    {
        confirmPurchasePanel.GetComponent<Animator>().Play("Shrink_UI");
        confirmPurchasePanel.SetActive(false);
        //confirmPurchasePanel.SetActive(false);
        redSelected = false;
        greenSelected = false;
        orangeSelected = false;
        darkPurpleSelected = false;
        pinkSelected = false;
        uiManager.showShop();
    }

    public void equipBlue()
    {
        playerColour = new Color32(0, 181, 255, 255);
        playerMat.color = playerColour;
    }

    public void equipRed()
    {
        playerColour = new Color32(203, 27, 27, 255);
        playerMat.color = playerColour;
    }

    public void equipGreen()
    {
        playerColour = new Color32(91, 203, 27, 255);
        playerMat.color = playerColour;
    }

    public void equipOrange()
    {
        playerColour = new Color32(248, 159, 0, 255);
        playerMat.color = playerColour;
    }

    public void equipPurple()
    {
        playerColour = new Color32(129, 0, 158, 255);
        playerMat.color = playerColour;
    }

    public void equipPink()
    {
        playerColour = new Color32(223, 43, 155, 255);
        playerMat.color = playerColour;
    }

    public void equipDarkPurple()
    {
        playerColour = new Color32(134, 0, 74, 255);
        playerMat.color = playerColour;
    }
}
