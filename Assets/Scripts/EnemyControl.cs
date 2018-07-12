using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	public Transform[] patrolPoints; 
	private int currentPoint;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		if (patrolPoints.Length == 0)
						return;
		transform.position = patrolPoints [0].position;
		currentPoint = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (patrolPoints.Length == 0)
			return;
		if (transform.position == patrolPoints [currentPoint].position) {
			currentPoint++; 
			if (currentPoint >= patrolPoints.Length) {
				currentPoint=0;
			} 

		}
		transform.position = Vector3.MoveTowards (transform.position, patrolPoints [currentPoint].position, moveSpeed * Time.deltaTime);
	
}
}
