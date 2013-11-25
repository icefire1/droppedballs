using UnityEngine;
using System.Collections;

public class LoadMainScene : MonoBehaviour {
	
	public string mainSceneName = "Playroom";
	public float timeDelay = 5.5f;
	
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + timeDelay)
			onFinished (mainSceneName);
	}
	
	void onFinished (string sceneName) {
		Application.LoadLevel (sceneName);
	}
}
