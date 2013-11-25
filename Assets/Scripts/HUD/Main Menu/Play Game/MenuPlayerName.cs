using UnityEngine;
using System.Collections;

public class MenuPlayerName : MonoBehaviour {
	
	public GameObject PlayerParent;
	
	private MenuPlayerHUD menuPlayerHUD;
	private UILabel uiLabel;
	private PlayerManager playerManager;
		
	// Use this for initialization
	void Awake () {
		menuPlayerHUD = PlayerParent.GetComponent<MenuPlayerHUD> ();
		uiLabel = gameObject.GetComponent<UILabel>();
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager>();
	}
	
//	void OnEnable () {
//		text = playerManager.getPlayerInfo( menuPlayerHUD.playerId ).Name;	
//	}
	
	// Update is called once per frame
	void Update () {
		uiLabel.text = playerManager.getPlayerInfo( menuPlayerHUD.playerId ).Name;
	}
}
