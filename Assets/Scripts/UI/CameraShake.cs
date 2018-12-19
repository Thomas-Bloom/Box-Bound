using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public Camera mainCam;

    private Vector3 camStartPos;
    private float shakeAmount = 0f;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Awake()
    {
        if (mainCam == null)
            mainCam = Camera.main;
    }


    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        camStartPos = mainCam.transform.position;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if(shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        //mainCam.transform.position = camStartPos;
    }
}
