using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour {
    public float health = 100;
    public Text healthText;
    public GameObject deathEffect;
    SpriteRenderer sprite;

    private void Awake () {
        sprite = GetComponent<SpriteRenderer> ();
    }

    private void Start () {
        healthText.text = "Health: " + health;
    }

    public void TakeDamage (float damage) {
        health -= damage; // health = health - damage;
        healthText.text = "Health: " + health;

        StartCoroutine(EffectDamage());

        if (health <= 0) {
            Die ();
        }
    }

    void Die () {
        Instantiate (deathEffect, this.transform.position, Quaternion.identity);
        Destroy (gameObject);
    }

    IEnumerator EffectDamage() {
        for (int i = 0; i < 3; i++) 
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds (0.05f);

            sprite.color = Color.white;
            yield return new WaitForSeconds (0.05f);
        }
    }
}