using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 *  Spawn balls in a circle around a spawnpoint
 *  with a defined radius to the spawnpoint and
 *  a defined movement along that circle with a
 * 	defined spawnrate pr. sec.
 **/
public class BallGenerator : MonoBehaviour {

	public Transform spawnPoint;
	// Spawn distance from spawnpoint
	public float spawnRadius;
	// Move a quarter pi radians along a spawn circle
	public float radianSpawnSteps = 0.25f;
	public float spawnRate = 0.25f;
	public GameObject[] BallTypes;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateBalls (int amountOfBalls, float delay) {
		StartCoroutine(generateBalls(amountOfBalls, delay));
	}

	public void GenerateBalls (int amountOfBalls) {
		GenerateBalls(amountOfBalls, 0.0f);
	}

	IEnumerator generateBalls(int amountOfBalls, float delay) {
		float radianStep = 0;
		float x,z;
		Vector3 stepSpawnpoint;
		yield return new WaitForSeconds(delay);
		for (int i=0; i<amountOfBalls; i++) {
			yield return new WaitForSeconds(spawnRate + 0.001f);

			radianStep += radianSpawnSteps * Mathf.PI;
			// Get a coordinate point on the circle periphery
			x = spawnPoint.position.x + spawnRadius * Mathf.Cos (radianStep);
			z = spawnPoint.position.z + spawnRadius * Mathf.Sin (radianStep);
//			Debug.DrawLine(spawnPoint.position, new Vector3(x, spawnPoint.position.y, z), Color.red, 1.0f);

			stepSpawnpoint = new Vector3(x, spawnPoint.position.y, z);
			Instantiate (BallTypes[Random.Range(0,BallTypes.Length)], stepSpawnpoint, Quaternion.identity);
		}
		bool wait = true;
		while (wait) {
			yield return new WaitForSeconds(0.2f);
			wait = false;
			GameObject[] balls = GameObject.FindGameObjectsWithTag ("Ball");
			foreach(GameObject ball in balls){
				if (ball != null)			
					if(!ball.rigidbody.IsSleeping()){
						wait = true;
					}
			}
		}

		// Let the this gameobject know that we've completed spawning the balls
		gameObject.SendMessage("OnBallGenerationDone", SendMessageOptions.DontRequireReceiver);
		yield return null;
	}
}
