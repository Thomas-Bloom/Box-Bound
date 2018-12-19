using UnityEngine;
using System.Collections;


public class Generator : MonoBehaviour
{
    public Transform generationPoint;
    private float distanceBetween;


    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int objectSelector;
    private float[] objectHeight;

    public ObjectPooler[] theObjectPools;

    private float minHorizontal;
    public Transform maxHorizontalPoint;
    private float maxHorizontal;
    public float maxHorizontalChange;
    public float horizontalChange;


    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        objectHeight = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            if(theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>())
            {
                objectHeight[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.y;
            }

            if (theObjectPools[i].pooledObject.GetComponent<CircleCollider2D>())
            {
                objectHeight[i] = theObjectPools[i].pooledObject.GetComponent<CircleCollider2D>().radius;
            }


        }

        minHorizontal = transform.position.x;
        maxHorizontal = maxHorizontalPoint.position.x;

    }


    void Update()
    {
        if (transform.position.y < generationPoint.position.y)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            objectSelector = Random.Range(0, theObjectPools.Length);

            //float heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange) - 0.2f;
            horizontalChange = transform.position.x + Random.Range(maxHorizontalChange, -maxHorizontalChange);

            /*
            if (horizontalChange < 0 && horizontalChange > -0.6)
            {
                horizontalChange = 0.6f;
            }
            */

            if (horizontalChange > maxHorizontal)
            {
                horizontalChange = maxHorizontal;
            }
            else if (horizontalChange < minHorizontal)
            {
                horizontalChange = minHorizontal;
            }

            //transform.position = new Vector3(transform.position.x + (objectHeight[objectSelector] / 2) + distanceBetween, horizontalChange, transform.position.z);
            transform.position = new Vector3(horizontalChange, transform.position.y + (objectHeight[objectSelector] / 2) + distanceBetween, transform.position.z);

            //Instantiate(/*thePlatform*/ thePlatforms[objectSelector], transform.position, transform.rotation);


            GameObject newPlatform = theObjectPools[objectSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //transform.position = new Vector3(transform.position.x + (objectHeight[objectSelector] / 2), transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, transform.position.y + (objectHeight[objectSelector] / 2), transform.position.z);


        }
    }
}
