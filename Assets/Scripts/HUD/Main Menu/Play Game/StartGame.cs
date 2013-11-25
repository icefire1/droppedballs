using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
//	public GameObject menuPanel;
//	public GameObject gamePanel;
	
	private StickManager stickManager;
	private Gamemanager gamemanager;
	
	// Use this for initialization
	void Start () {
		stickManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<StickManager> ();
		gamemanager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Gamemanager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnClick () {
//		menuPanel.active = false;
//		gamePanel.active = true;
//		stickManager.enabled = true;

		gamemanager.StartGame ();
	}
}
