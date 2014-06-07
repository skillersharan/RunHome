using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int currentScore;
	public static int highScore;

	public static int currentLevel=0;
	public static int unlockedLevel;

	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public static void CompleteLevel(){
		Application.LoadLevel (++currentLevel);
		}
	
	// Update is called once per frame
	void Update () {
	
	}
}
