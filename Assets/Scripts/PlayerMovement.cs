using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed;
	public float maxSpeed=5f;
	private Vector3 spawn;
	private Vector3 input;
	public Vector3 tilt;
	public float speed;
	private Vector3 previousPosition;
	public GameObject deathParticle;
	public Camera cam;
	// Use this for initialization
	void Start () {
		spawn = transform.position;
		previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		tilt.z = Input.acceleration.y;
		tilt.x = Input.acceleration.x;
		
		rigidbody.AddForce(tilt * speed * Time.deltaTime);
		if (transform.position.y < 0) {
			Die ();
				}

	}

	
	void LateUpdate()
	{
		Vector3 movement = transform.position - previousPosition;
		
		movement =new Vector3(movement.z,0,  -movement.x);
				
		previousPosition = transform.position;	
		
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
		if (other.transform.tag == "Cam") {
			cam.fieldOfView-=25;
		}
		}
	void OnTriggerExit(Collider other){
		if (other.transform.tag == "Cam") {
			cam.fieldOfView+=25;
		}
		}


	void Die(){
		Instantiate(deathParticle,transform.position,Quaternion.identity);
		transform.position=spawn;
	}
}
