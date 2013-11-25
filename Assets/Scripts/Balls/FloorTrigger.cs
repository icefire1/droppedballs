using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour {
	
	private GameObject gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");	
	}
	
	void OnTriggerEnter (Collider collider) {
		collider.gameObject.SendMessage("FloorHit", SendMessageOptions.DontRequireReceiver);
		gameManager.SendMessage("BallDropped", collider.gameObject, SendMessageOptions.DontRequireReceiver);
	}
}