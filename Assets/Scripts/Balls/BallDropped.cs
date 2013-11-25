using UnityEngine;
using System.Collections;

public class BallDropped : MonoBehaviour {
	
	public GameObject ballDropParticle;
	public int pointsOnDrop = 1;
	
	[HideInInspector]
	public bool moving = true;
	
	private PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		try{
			playerManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerManager>();
		}
		catch{
			Debug.Log("The PlayerManager script wasn't found on the GameManager object, please make sure you both have a GameManager object with the PlayerManager script on it.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FloorHit () {
		if (ballDropParticle){
			Quaternion q = new Quaternion();
			q.SetLookRotation(Vector3.back, Vector3.forward);
			Instantiate(ballDropParticle, transform.position, q);
		}
		
		playerManager.addPoints(pointsOnDrop);
		
		Destroy (this.gameObject);	
	}
}
