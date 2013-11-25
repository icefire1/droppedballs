using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour {

	public Transform winnerPanel;
	public GameObject menuPanel;
	public GameObject gamePanel;
	public GameObject pausePanel;
	
	private List<GameObject> balls = new List<GameObject> ();
	private StickManager stickManager;
	private StickGenerator stickGenerator;
	private BallGenerator ballGenerator;
	private SetCameraMode setCameraMode;
	private PlayerManager playerManager;

	private bool gameActive = false;
	private bool ballsReady;
	public bool GameActive{
		get{return gameActive;}
	}
	private bool gamePaused = true;
	public bool GamePaused{
		get{return gamePaused;}
	}

	// Use this for initialization
	void Start () {
		stickManager = GetComponent<StickManager> ();
		setCameraMode = GetComponent<SetCameraMode> ();
		stickGenerator = GetComponent<StickGenerator> ();
		ballGenerator = GetComponent<BallGenerator> ();
		playerManager = GetComponent<PlayerManager>();
	}

	void OnBallGenerationDone() {
		ballsReady = true;
		// This should be taken from some ball generator script
		balls.Clear();
		foreach (GameObject ball in GameObject.FindGameObjectsWithTag ("Ball")) {
			balls.Add(ball);
		}
		if (gameActive)
			StartCoroutine("ChangePlayer");
	}

	void BallDropped (GameObject ball) {
		if (ball.tag == "Ball" && ballsReady){
			balls.Remove(ball);
			// Enable winning panel
			if (balls.Count == 0) {
				winnerPanel.gameObject.SetActive(true);
				PauseGame ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameActive) {
			if (Input.GetKeyDown(KeyCode.Escape)) { 
				if (!gamePaused)
					PauseGame ();
				// This should be handled in some pause menu panel!!!!!!!!!!
				else
					ResumeGame ();
			}
		}
	}

	public void StartGame() {
		gameActive = true;
		gamePaused = false;
		menuPanel.active = false;
		gamePanel.active = true;
		stickManager.enabled = true;
		ballsReady = false;

		setCameraMode.CameraMode(SetCameraMode.CameraModes.Manual);

		// Do some sort of initialization
		stickGenerator.GenerateSticks (20);
		ballGenerator.GenerateBalls (30, 1.0f);
	}

	public void PauseGame() {
		gamePaused = true;
		stickManager.enabled = false;
//		pausePanel.active = true;
		
		setCameraMode.CameraMode(SetCameraMode.CameraModes.Rotating);
	}

	public void ResumeGame() {
		gamePaused = false;
		stickManager.enabled = true;
//		pausePanel.active = false;

		setCameraMode.CameraMode(SetCameraMode.CameraModes.Manual);
	}

	public void RestartGame () {

	}

	public void NewGame () {

	}

	public void EndGame () {

	}
	
	// Called from a trigger encapsulating the cylinder
	void CylinderExit (GameObject stick) {
		if (stick.tag == "Stick"){
			Destroy (stick); // possibly make an effect later?
			StartCoroutine("ChangePlayer"); // Change turn when all the balls holds still
		}
	}
	
	IEnumerator ChangePlayer() {
		bool wait = true;
		while (wait){
			wait = false;
			foreach(GameObject ball in balls){
				if (ball != null)			
					if(!ball.rigidbody.IsSleeping()){
						wait = true;
				}
			}
			yield return null; // wait a frame
		}
		
		playerManager.nextPlayer();
		stickManager.canSelectStick = true;
	}
	
}
