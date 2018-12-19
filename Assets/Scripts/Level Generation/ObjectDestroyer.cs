using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour
{

    public GameObject platformDestroyerPoint;
    public string destroyPoint;

    // Use this for initialization
    void Start()
    {
        platformDestroyerPoint = GameObject.Find(destroyPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < platformDestroyerPoint.transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
