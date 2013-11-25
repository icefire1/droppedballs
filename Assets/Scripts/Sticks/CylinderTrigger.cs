using UnityEngine;
using System.Collections;

public class CylinderTrigger : MonoBehaviour {
	
	private GameObject gameManager;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");	
	}
	
	// Update is called once per frame
	void OnTriggerExit (Collider collider) {
		Debug.Log(collider + " exited");
		gameManager.SendMessage("CylinderExit", collider.gameObject, SendMessageOptions.DontRequireReceiver);
	}
}
