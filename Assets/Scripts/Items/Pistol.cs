using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{

    public KeyCode reload;

    public Text magText;

    private bool hasFired;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 1f;

    private float nextTimeToFire = 0f;

    public bool reloading;

    public float magSize;
    private float bulletsInMag;
    public float timeToReload;

    public Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect, enemyImpactEffect;

    private void Start()
    {
        bulletsInMag = magSize;
    }

    void Update()
    {
        magText.text = bulletsInMag.ToString() + " / " + magSize.ToString();
        if (bulletsInMag > 0f && !reloading)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
                hasFired = true;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                if (hasFired == false)
                {
                    Shoot();
                }
            }
            hasFired = false;
        }
        if (Input.GetKeyDown(reload))
        {
            reloading = true;
            Invoke("Reload", timeToReload);
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        bulletsInMag--;

        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                if (target.enemyImpactEffect != null)
                {
                    GameObject enemyImpactGameObject = Instantiate(target.enemyImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(enemyImpactGameObject, 2f);
                }
            }
            else
            {
                GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGameObject, 2f);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            if (hit.transform.gameObject.GetComponent<BreakableWindow>() != null)
            {
                hit.transform.gameObject.GetComponent<BreakableWindow>().breakWindow();
            }

        }
    }

    void Reload()
    {
        reloading = false;
        bulletsInMag = magSize;
    }
}