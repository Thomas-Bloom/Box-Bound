using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour {

    public GameManager gm;
    private AudioSource coinCollectSound;

    private void Start()
    {
        coinCollectSound = GameObject.Find("Coin_Collect").GetComponent<AudioSource>();
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            coinCollectSound.Play();
            PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + 1);
            //gm.coinCount += 1;
            this.gameObject.SetActive(false);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
