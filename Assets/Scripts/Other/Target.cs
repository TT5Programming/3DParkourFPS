﻿using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject player, katana, deathEffect;
    public GrapplingGun grappleScript;
    public Katana katanaScript;
    public float maxHealth;

    public GameObject createOnDeath;

    public GameObject enemyImpactEffect = null;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == katana.GetComponent<Collider>() && katanaScript.isSwinging == true)
        {
            TakeDamage(katanaScript.damage);
        }
        if (other == player.GetComponent<Collider>() && grappleScript.isHookActive == true)
        {
            grappleScript.StopHookShot();
            Die();
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathEffect != null)
        {
            GameObject deathEffectObject = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(deathEffectObject, 2f);
        }
        if (createOnDeath != null)
        {
            Instantiate(createOnDeath, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
