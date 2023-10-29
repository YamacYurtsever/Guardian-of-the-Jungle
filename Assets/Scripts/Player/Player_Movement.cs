using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Movement : MonoBehaviour
{
	public float runSpeed = 100f;

	private Rigidbody2D rb;
	private float horizontalMove;
	private bool isFacingRight = true;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		Move(horizontalMove * Time.fixedDeltaTime);
	}

	public void Move(float move)
	{
		rb.velocity = new Vector2(move, rb.velocity.y);

		if (move > 0 && !isFacingRight)
			Flip();
		else if (move < 0 && isFacingRight)
			Flip();
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
