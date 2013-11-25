using UnityEngine;
using System.Collections;

public class ButtonEnabled : MonoBehaviour {
	
	public UIButton uiButton;
	private PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerManager.getNumberOfPlayers () >= 2)
			uiButton.isEnabled = true;
		else
			uiButton.isEnabled = false;
	}
}
