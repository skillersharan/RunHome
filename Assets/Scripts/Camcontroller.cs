using UnityEngine;
using System.Collections;

public class Camcontroller : MonoBehaviour {
	public Camera cam;
	public float offx=0;
	public float offz=3;
	public float camheight=7;
	public Color color1 = Color.red;
	public Color color2 = Color.yellow;
	public float duration = 3.0F;
	public float smooth = 3f;
	public bool isstatic;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (!isstatic) {
						if (Time.realtimeSinceStartup < 8)
								cam.transform.position = Vector3.Lerp (cam.transform.position, new Vector3 (transform.position.x - offx, camheight, transform.position.z - offz), Time.deltaTime * 0.3f);
						else
								cam.transform.position = Vector3.Lerp (cam.transform.position, new Vector3 (transform.position.x - offx, camheight, transform.position.z - offz), smooth);
				}
		float t = Mathf.PingPong(Time.time, duration) / duration;
		cam.backgroundColor = Color.Lerp(color1, color2, t);
}
}