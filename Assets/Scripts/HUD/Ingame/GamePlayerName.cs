using UnityEngine;
using System.Collections;

public class GamePlayerName : MonoBehaviour {
	
	public GameObject PlayerParent;
	
	private GamePlayerHUD gamePlayerHUD;
	private UILabel uiLabel;
		
	// Use this for initialization
	void Awake () {
		gamePlayerHUD = PlayerParent.GetComponent<GamePlayerHUD> ();
		uiLabel = gameObject.GetComponent<UILabel>();
	}
	
	void OnEnable () {
		uiLabel.text = gamePlayerHUD.player.Name;
	}
	
	// Update is called once per frame
//	void Update () {
//		uiLabel.text = gamePlayerHUD.player.Name;
//	}
}
