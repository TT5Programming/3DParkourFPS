using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 15;

    private float nextTimeToFire = 0f;
    
    public Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect, enemyImpactEffect;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>= nextTimeToFire)
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
}