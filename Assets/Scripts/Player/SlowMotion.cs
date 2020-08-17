using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public Camera camera;
    public int defaultFOV, slowMotionFOV;
    public GameObject slowMotionHUD;
    public float slowMoSpeed;


    private void Start()
    {
        slowMotionHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = slowMoSpeed;
            camera.fieldOfView = slowMotionFOV;
            slowMotionHUD.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            camera.fieldOfView = defaultFOV;
            slowMotionHUD.SetActive(false);
        }
    }
}
