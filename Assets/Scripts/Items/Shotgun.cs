using UnityEngine;

public class Shotgun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 5f;
    public float impactForce = 250f;
    public float recoilRange = 15f;
    public float recoilForce = 2500f;
    public float fireRate = 2f;

    private float nextTimeToFire = 0f;

    public Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect, enemyImpactEffect;
    public Rigidbody playerRigidbody;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject enemyImpactGameObject = Instantiate(enemyImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(enemyImpactGameObject, 2f);
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
        }
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, recoilRange))
        {
            playerRigidbody.AddForce(-camera.transform.forward * recoilForce);
        }
    }
}