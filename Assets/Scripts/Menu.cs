using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public string tag;
	// Use this for initialization
	void Start () {
	
	}
	void OnMouseUp(){
		if(tag=="Start")
						Application.LoadLevel (1);
		if (tag == "Quit")
						Application.Quit ();
		}
	// Update is called once per frame
	void Update () {
	
	}
}
