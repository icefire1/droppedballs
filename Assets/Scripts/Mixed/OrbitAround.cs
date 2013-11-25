using UnityEngine;
using System.Collections;

public class OrbitAround : MonoBehaviour {
	public Transform target;
	public float speed = 10;

	void Update () {
		transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);;
	}
}
