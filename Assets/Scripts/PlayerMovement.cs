using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float turnSmoothing = 15f;   
	public float speedDampTime = 0.1f;  
	private Vector3 spawn;
	private Animator anim;              

	
	
	void Awake ()
	{

		anim = GetComponent<Animator>();
		spawn = transform.position;	

	}

	void FixedUpdate ()
	{

		//float h = Input.GetAxis("Horizontal");
		//float v = Input.GetAxis("Vertical");

		float h = Input.acceleration.x;
		float v = Input.acceleration.y;

		
		MovementManagement(h, v);

		if (transform.position.y < -2) {
			Die ();
		}
	}
	

	
	
	void MovementManagement (float horizontal, float vertical)
	{

		if(Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
		{
			Rotating(horizontal, vertical);
			anim.SetFloat("Speed", Mathf.Max (Mathf.Abs(vertical),Mathf.Abs(horizontal)), speedDampTime, Time.deltaTime);
		}
		else

			anim.SetFloat("Speed", 0);
	}
	
	
	void Rotating (float horizontal, float vertical)
	{

		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		

		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		

		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		

		rigidbody.MoveRotation(newRotation);
	}
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
			Die();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Goal") {
			GameManager.CompleteLevel();
				
		}
		}




	void Die(){
		transform.position=spawn;
	}

}