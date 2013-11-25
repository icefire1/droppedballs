using UnityEngine;
using System.Collections;

public class NextPlayerHUD : MonoBehaviour {
	
	public string playernamePlus = "'s turn!";
	
	private PlayerManager playerManager;
	private UILabel uiLabel;
	private TweenAlpha tweenAlpha;
	private TweenScale tweenScale;
	
	// Use this for initialization
	void Awake () {
		uiLabel = GetComponent<UILabel> ();
		tweenAlpha = GetComponent<TweenAlpha> ();
		tweenScale = GetComponent<TweenScale> ();
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
	}
	
	void OnEnable () {
//		uiLabel.text = playerManager.getPlayerInfo(playerManager.getTurn()).Name + playernamePlus;
		playerManager.OnNextPlayer += OnNextPlayer;	
	}
	
	void OnDisable () {
		playerManager.OnNextPlayer -= OnNextPlayer;	
	}

	void OnNextPlayer (Player player)
	{
		PlayTweens(player);
	}
	
	void PlayTweens (Player player) {
		// Some ngui implementation here
		tweenAlpha.Reset ();
		tweenScale.Reset ();
		tweenAlpha.Play ();
		tweenScale.Play ();
		uiLabel.text = player.Name + playernamePlus;
	}
}
