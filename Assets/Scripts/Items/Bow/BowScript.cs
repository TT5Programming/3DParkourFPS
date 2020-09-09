using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowScript : MonoBehaviour
{
    public LayerMask visible;
    
    public KeyCode reload;

    public Text magText, reloadText;

    private bool reloading;

    public float magSize;
    private float bulletsInMag;
    public float timeToReload;

    public float charge;
    private float chargeDefault = 0f;
    private float damage;
    
    Quaternion arrowRotation;

    public float chargeMax;
    public float chargeRate;
    public float chargeMin;

    public float range;

    public GameObject camera;

    public float damageMax;

    public KeyCode fireButton;

    public Transform spawn;
    public Rigidbody arrowObj;

    private void Start()
    {
        bulletsInMag = magSize;
    }

    void Update()
    {
        reloadText.gameObject.SetActive(reloading);
        magText.text = bulletsInMag.ToString() + " / " + magSize.ToString();
        if (!reloading)
        {
            if (Input.GetKey(fireButton) && charge < chargeMax)
            {
                charge += Time.deltaTime * chargeRate;
                Debug.Log(charge.ToString());
            }

            if (Input.GetKeyUp(fireButton))
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range, visible))
                {
                    if (charge <= chargeMin)
                    {
                        charge = chargeMin;
                    }
                    damage = charge / chargeMax * damageMax;
                    Rigidbody arrow = Instantiate(arrowObj, spawn.position, spawn.rotation) as Rigidbody;
                    arrow.AddForce((hit.point - transform.position)/hit.distance * charge, ForceMode.Impulse);
                    ArrowScript arrowScript = arrow.gameObject.GetComponentInChildren<ArrowScript>();
                    arrowScript.damage = damage;
                    charge = 0f;
                    damage = 0f;
                    bulletsInMag--;
                }
                else
                {
                    if (charge <= chargeMin)
                    {
                        charge = chargeMin;
                    }
                    damage = charge / chargeMax * damageMax;
                    Rigidbody arrow = Instantiate(arrowObj, spawn.position, spawn.rotation) as Rigidbody;
                    arrow.AddForce(camera.transform.forward * charge, ForceMode.Impulse);
                    ArrowScript arrowScript = arrow.gameObject.GetComponentInChildren<ArrowScript>();
                    arrowScript.damage = damage;
                    charge = 0f;
                    damage = 0f;
                    bulletsInMag--;
                }
            }
        }
        if (Input.GetKeyDown(reload) || bulletsInMag <= 0)
        {
            reloading = true;
            Invoke("Reload", timeToReload);
        }
    }
    void Reload()
    {
        reloading = false;
        bulletsInMag = magSize;
    }
}
