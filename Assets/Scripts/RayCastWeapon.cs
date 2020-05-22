using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour {

	public Transform firePoint;
	public int damage = 40;
	public GameObject impactEffect;
	public LineRenderer lineRenderer;

	CharacterController2D characterController;
	PlayerMovement playerMovement;
	Animator animator;
	public bool isShooting;

	private void Awake() {
		characterController = GetComponent<CharacterController2D>();
		playerMovement = GetComponent<PlayerMovement>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Si esta tocando el suelo...
		if (Input.GetButtonDown("Fire1") && characterController.m_Grounded)
		{
			// ... dispara
			StartCoroutine(Shoot());
		}

		if (isShooting)
		{
			playerMovement.horizontalMove = 0;
		}
	}

	IEnumerator Shoot ()
	{
		isShooting = true;
		animator.SetBool("IsShooting",isShooting);

		yield return new WaitForSeconds(0.3f);

		RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

		if (hitInfo)
		{
			Life lifeEnemy = hitInfo.transform.GetComponent<Life>();
			if (lifeEnemy != null)
			{
				lifeEnemy.TakeDamage(damage);
			}

			Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, hitInfo.point);
		} else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
		}

		lineRenderer.enabled = true;

		yield return 0;

		lineRenderer.enabled = false;

		isShooting = false;
		animator.SetBool("IsShooting",isShooting);
	}
}
