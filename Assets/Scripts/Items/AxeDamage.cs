using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour
{
    public float damage = 50f;
    private Boomerang boomerang;

    private void Start()
    {
        boomerang = gameObject.GetComponentInParent<Boomerang>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (boomerang.hasFired)
        {
            ContactPoint contact = collision.contacts[0];
            if (contact.thisCollider.GetComponent<Target>())
            {
                Target target = contact.thisCollider.GetComponent<Target>();
                target.TakeDamage(damage);
            }
            if (contact.otherCollider.GetComponent<Target>())
            {
                Target target = contact.otherCollider.GetComponent<Target>();
                target.TakeDamage(damage);
            }
                
            
        }
    }
}
