using UnityEngine;
using System.Collections;

public class GetWinner : MonoBehaviour {

	private PlayerManager playerManager;
	private UILabel uiLabel;

	// Use this for initialization
	void Awake () {
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager>();
		uiLabel = GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void OnEnable () {
		string name = playerManager.GetLeadingPlayer().Name;
		uiLabel.text = name + " won!";
	}
}
