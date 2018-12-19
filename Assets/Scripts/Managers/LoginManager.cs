using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{

	void Start ()
    {
        StartCoroutine(countdownToLoadMenu());
    }

    private IEnumerator countdownToLoadMenu()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Level");
    }

}
