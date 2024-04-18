using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOperation : MonoBehaviour
{

	// Animator コンポーネント
	private Animator animator;

	// 設定したフラグの名前
	private const string key_isJump = "jump";
	private Rigidbody my_body;

	// Start is called before the first frame update
	void Start()
	{
		this.animator = GetComponent<Animator>();
		my_body = GetComponent<Rigidbody>();

	}
	float speed = 2.0f;
	void Update()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");
		//Debug.Log("h=" + h + " v=" + v);
		if (Mathf.Abs(h) > 0.01f || Mathf.Abs(v) > 0.01f)
		{
			if (v < 0)
			{
				v = v / 1.5f;
			}
			var localVelocity = new Vector3(0, 0, v);
			var worldVelocity = transform.TransformDirection(localVelocity);
			my_body.velocity = worldVelocity * speed;

			//向き操作
			if (h > 0)
			{
				transform.Rotate(0, 0.1f, 0);  // 右に0.1度回転
			}
			else if (h < 0)
			{
				transform.Rotate(0, -0.1f, 0);  // 左に0.1度回転
			}
			//アニメーション操作
			//Debug.Log("x=" + my_body.velocity.x + " z=" + my_body.velocity.z);
			animator.SetFloat("speed_v", v);
			animator.SetFloat("speed_h", h);

		}
		if (Input.GetKey(KeyCode.Space))
		{
			this.animator.SetBool(key_isJump, true);
		}
		else
		{
			this.animator.SetBool(key_isJump, false);
		}
	}
}
