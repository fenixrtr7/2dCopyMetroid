using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float attack = 10;
	private void OnCollisionEnter2D(Collision2D other) { // other -> objeto con collision
		if (other.gameObject.CompareTag("Player")) // Si el objeto el tag es "Player"
		{
			// Si es el PLayer ejecuta este código
			other.gameObject.GetComponent<Life>().TakeDamage(attack);
		}
	}
}
