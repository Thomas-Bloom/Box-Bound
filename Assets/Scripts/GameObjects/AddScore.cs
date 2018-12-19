using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int scoreToGive;
    private GameManager gm;
    private GameObject Barrier_Pass_Sound;

    private bool countdownStarted;

    private void Start()
    {
        Barrier_Pass_Sound = GameObject.Find("Barrier_Pass_Sound");
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(countdownStarted)
        {
            float timeLeft = 1f;
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                countdownStarted = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Barrier_Pass_Sound.GetComponent<AudioSource>().Play();
            StartCoroutine(countdownToEnableCollider());
            
            gm.scoreCount += scoreToGive;
            //gameObject.GetComponent<BoxCollider2D>().enabled = false;

            //countdownStarted = true;
           
        }
    }

    private IEnumerator countdownToEnableCollider()
    {
        //Barrier_Pass_Sound.GetComponent<AudioSource>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        Barrier_Pass_Sound.GetComponent<AudioSource>().enabled = true;
    }
}
