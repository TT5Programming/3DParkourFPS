using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float damage;

    public LayerMask layers;

    public float destroyTime;

    private bool hasDealtDamage = false;

    public Rigidbody rigidbody;

    public void Break()
    {
        Destroy(gameObject, destroyTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        if (contact.thisCollider.GetComponent<Target>() && hasDealtDamage == false)
        {
            Target target = contact.thisCollider.GetComponent<Target>();
            target.TakeDamage(damage);
            hasDealtDamage = true;
        }
        if (contact.otherCollider.GetComponent<Target>() && hasDealtDamage == false)
        {
            Target target = contact.otherCollider.GetComponent<Target>();
            target.TakeDamage(damage);
            hasDealtDamage = true;
        }

        if(contact.thisCollider.gameObject.layer == layers)
        {
            Break();
        }
        if (contact.otherCollider.gameObject.layer == layers)
        {
            Break();
        }
    }
}
