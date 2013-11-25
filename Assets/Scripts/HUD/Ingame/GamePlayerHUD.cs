using UnityEngine;
using System.Collections;

public class GamePlayerHUD : MonoBehaviour {

	public int playerId;
	
	[HideInInspector] public Player player;
	private PlayerManager playerManager;
	
	// Use this for initialization
	void Start () {
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
//		player = playerManager.getPlayerInfo(playerId);
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
}
