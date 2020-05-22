using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	Animator animator;

	//CharacterController2D characterController;

	private void Awake() {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") /*&& characterController.m_Grounded*/)
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		animator.SetTrigger("shooting");

		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
