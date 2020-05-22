using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField] private float move = 10; // SerializeField 

    Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;



    bool m_FacingRight = true;

    // Time
    [SerializeField] float timeChange = 1f;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time
        currentTime += Time.deltaTime;

        // Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, rigid.velocity.y);

			// And then smoothing it out and applying it to the character
			rigid.velocity = Vector3.SmoothDamp(rigid.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (currentTime >= timeChange && !m_FacingRight)
			{
                // Reset Time
                currentTime = 0;
                move = -move;
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (currentTime >= timeChange && m_FacingRight)
			{
                // Reset Time
                currentTime = 0;
                move = move * -1;

				// ... flip the player.
				Flip();
			}
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}


}
