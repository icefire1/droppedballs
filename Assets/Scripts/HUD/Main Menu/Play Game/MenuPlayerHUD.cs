using UnityEngine;
using System.Collections;

public class MenuPlayerHUD : MonoBehaviour {
	
	public int playerId;
	
	private Player player;
	private PlayerManager playerManager;
	private UILabel uiLabel;
	
	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player != playerManager.getPlayerInfo (playerId) ){
			player = playerManager.getPlayerInfo( playerId );
			foreach ( Transform child in transform ) {
				if (player != null) {
					child.gameObject.SetActive(true);
				}
				else
					child.gameObject.SetActive(false);
			}
		}
	}
	
	void RemovePlayer () {
		Debug.Log ("Remove: " + player.Name);
		playerManager.removePlayer (playerId);	
	}
}
