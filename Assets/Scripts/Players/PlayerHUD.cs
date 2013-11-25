using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {

	public string pointsText = "Points: ";
	
	private int playerId;
	private PlayerManager playerManager;
	private UILabel playerNameLabel;
	private UILabel scoreLabel;
	
	void Awake () {
		playerNameLabel = GetComponent<UILabel> ();
		scoreLabel = transform.FindChild("points").GetComponent<UILabel> ();
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
	}
	
	public void setPlayerId (int playerId) {
		this.playerId = playerId;
		playerNameLabel.text = playerManager.getPlayerInfo(playerId).Name;
	}
	
	void Update () {
		string points = playerManager.getPoints (playerId).ToString();
		scoreLabel.text = pointsText + points.ToString ();
	}
}
