using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
   public int lightCount, gameObjectLength;
    public GameObject lightGameObject;
    private GameObject newLight;

   int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        while (i < lightCount)
        {
            newLight = Instantiate(lightGameObject) as GameObject;
            newLight.transform.localScale = lightGameObject.transform.lossyScale;
            newLight.transform.SetParent(gameObject.transform);
            newLight.transform.localPosition = new Vector3(0.5f, 0.99f,(i+0.5f)/(gameObject.transform.localScale.z/lightCount));
            i++;
        }
    }
}
