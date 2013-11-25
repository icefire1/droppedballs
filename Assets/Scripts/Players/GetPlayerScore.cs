using UnityEngine;
using System.Collections;

public class GetPlayerScore : MonoBehaviour {
	
	public int playerId;
	private PlayerManager playerManager;
	private UILabel label;
	private string previouslyAppended = "";

	// Use this for initialization
	void Start () {
		label = GetComponent<UILabel> ();
		playerManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		string points = playerManager.getPoints (playerId).ToString();
		if (!previouslyAppended.Equals(points)){
			label.text = label.text.Substring(0, label.text.Length - previouslyAppended.Length);
			previouslyAppended = points;
			label.text += previouslyAppended;
		}
	}
}
