using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;
    Animator anim;
    AudioSource audioSource;
    public ParticleSystem particleJump;
    float horizontal;
	bool isJump;
    public float speed = 8, jumpForce = 5, jumpRaycastDistance = 1f;
	public LayerMask groundMask;
	public ManagerAudio managerAudio;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

		isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
		//Crunch();

		Debug.DrawRay(transform.position, Vector2.down * jumpRaycastDistance, Color.red);
    }

    void Jump()
    {
        // JUMP
        if (Input.GetAxisRaw("Jump") > 0 && IsTouchingTheGround() && isJump == false)
        {
            audioSource.clip = managerAudio.arrayAudio[1];
            audioSource.Play();
            particleJump.Play();

			isJump = true;
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

		if (IsTouchingTheGround())
		{
			anim.SetBool("isJump", false);
		}
		else if (!IsTouchingTheGround())
		{
			anim.SetBool("isJump", true);
		}
    }

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Ground"))
		{
			isJump = false;
		}
	}

    void Run()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        //Debug.Log("Valor al caminar: " + horizontal);

        rigid.velocity = new Vector2(horizontal, rigid.velocity.y);

        // FLIP
        if (horizontal < 0)
        {
			anim.SetBool("isRun", true);
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
			anim.SetBool("isRun", true);
            sprite.flipX = false;
        }
		else
		{
			anim.SetBool("isRun", false);
		}
    }

	bool IsTouchingTheGround()
    {
        // Uso de raycast
        if(Physics2D.Raycast(this.transform.position, Vector2.down, jumpRaycastDistance, groundMask))
        {
            return true;
        }else
        {
            return false;
        }
    }


}
