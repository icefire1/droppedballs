using UnityEngine;
using System.Collections;

public class GamePlayerPoints : MonoBehaviour {
	
	public string pointsText = "Points: ";
	public GameObject PlayerParent;
	
	private GamePlayerHUD gamePlayerHUD;
	private UILabel uiLabel;
		
	// Use this for initialization
	void Awake () {
		gamePlayerHUD = PlayerParent.GetComponent<GamePlayerHUD> ();
		uiLabel = gameObject.GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		uiLabel.text = pointsText + gamePlayerHUD.player.Points.ToString ();
	}
}
