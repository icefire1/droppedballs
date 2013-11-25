using UnityEngine;
using System.Collections;

public class AddPlayer : MonoBehaviour {
	
	private PlayerManager playerManager;
	
	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void OnSubmit (string name) {
		Debug.Log ("OnSubmit");
		playerManager.addPlayer (name);
		gameObject.SetActive(false);
	}	
}
