using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StickGenerator : MonoBehaviour {
	
	public float maxStickAngle = 40.0f;
	public Transform[] stickTypes;
	public float stickOffset = 0.13f;

	private Dictionary<Transform, bool> holes = new Dictionary<Transform, bool> ();

	void Start () {
		GameObject[] holesGOs = GameObject.FindGameObjectsWithTag ("Hole");
		foreach (GameObject hole in holesGOs) {
			holes.Add (hole.transform, false);
		}
		Debug.Log ("Found " + holes.Count + " holes");
	}

	public void GenerateSticks (int amountOfSticks) {
		StartCoroutine("generateSticks", amountOfSticks); 
	}
	
	IEnumerator generateSticks(int amountOfSticks) {
		Debug.Log ("Generate sticks.");
		if (amountOfSticks > holes.Count / 2) {
			Debug.Log("Amount of sticks exceeds the amount of half the holes. Max amount of sticks are: " + holes.Count / 2
			          +"\nGenerating " + holes.Count / 2 + " sticks instead of " + amountOfSticks);
			amountOfSticks = holes.Count / 2;
		}
		Transform hole1, hole2;
		int sticks = 0;
		int maxRepeats = 100;
		int repeats = 0;
		while (sticks < amountOfSticks+1) {
			yield return new WaitForSeconds(0.01f);
			repeats++;
			if (repeats > maxRepeats) {
				Debug.Log("Failed to generate all the sticks. Only " +sticks+"/"+amountOfSticks+ " has been instantiated");
				break;
			}
			hole1 = GetUnoccupiedHole ();
			holes[hole1] = true; // Occupy hole
			
			// Keep trying new holes till a hole fits the demands
			int attempts = 0; // Make sure we don't go into an endless loop
			while (true) {
				attempts += 1;
				hole2 = GetUnoccupiedHole ();
				Vector3 stickVector = hole2.position - hole1.position;
				// The parent of hole1 is placed in the middle of the cylinder and at same height as hole1
				Vector3 centerVector = hole1.parent.position - hole1.position;
				// Make sure the max angle is opheld
				float angle = Vector3.Angle(centerVector, stickVector);
				if (angle <= maxStickAngle) {
					// Vector math to place the stick correcly
					Transform clone = (Transform) Instantiate(stickTypes[Random.Range(0, stickTypes.Length)]);
					clone.position = (hole1.position + hole2.position) / 2;
					//					clone.Translate(Vector3.forward * stickOffset, Space.Self);
					Vector3 relativePos = hole2.position - hole1.position;
					Quaternion rotation = Quaternion.LookRotation(relativePos);
					clone.rotation = rotation;
					holes[hole2] = true; // Occupy hole
					
					sticks++;
					break;
				}
				if (attempts > GetUnoccuipiedHoles ()) {
					holes[hole1] = false; // Unoccupy hole
					break;
				}
			}
		}
		yield return null;
	}

	private Transform GetUnoccupiedHole () {
		List<Transform> unoccupiedHoles = new List<Transform> ();
		foreach (KeyValuePair<Transform,bool> hole in holes) {
			if (hole.Value == false) {
				unoccupiedHoles.Add (hole.Key);
			}
		}
		int index = (int) Random.Range(0, unoccupiedHoles.Count);
		return unoccupiedHoles[index];
	}

	private int GetUnoccuipiedHoles () {
		int unoccuipiedHoles = 0;
		foreach (KeyValuePair<Transform,bool> hole in holes) {
			if (hole.Value == false) {
				unoccuipiedHoles += 1;
			}
		}
		return unoccuipiedHoles;
	}
	
	public void RemoveAllSticks () {
		Debug.Log ("Remove all sticks.");

	}
}
