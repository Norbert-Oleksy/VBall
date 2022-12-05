using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Poruszajsie : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Rigidbody2D rb2D;
	[SerializeField] private Collider2D body;
	[SerializeField] private LayerMask groundMask;

	[Header("Values")]
	[SerializeField] private float moveSpeed = 5.0f;
	[SerializeField] private float jumpForce = 8.0f;

	private bool jump = false;
	private int MoveDir;

	public void Move(int moveDir, bool jump)
	{
		var totalMoveSpeed = moveSpeed;
        if (moveDir > 1)
        {
			moveDir = 1;
        }else if(moveDir < -1)
        {
			moveDir = -1;
		}
		rb2D.position += moveDir * Time.fixedDeltaTime * totalMoveSpeed * Vector2.right;

		if (!IsGrounded())
			return;

		rb2D.velocity = new Vector2(rb2D.velocity.x, 0);

		if (jump)
			rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	private bool IsGrounded()
	{
		var bodyBounds = body.bounds;
		var feetStart = (Vector2)bodyBounds.min;
		var feetEnd = feetStart + Vector2.right * bodyBounds.size.x + Vector2.down * 0.1f;
		return Physics2D.OverlapArea(feetStart, feetEnd, groundMask);
	}

    private void Update()
    {
		var leftDirValue = Input.GetKey(KeyCode.A) ? -1 : 0;
		var rightDirValue = Input.GetKey(KeyCode.D) ? 1 : 0;
		MoveDir = leftDirValue + rightDirValue;
		jump = Input.GetKey(KeyCode.Space);
	}

    private void FixedUpdate()
    {
		Move(MoveDir, jump);
		jump = false;
	}
}
