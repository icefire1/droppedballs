using UnityEngine;
using System.Collections;

public class RemovePlayer : MonoBehaviour {

	// Use this for initialization
	void OnClick () {
		gameObject.SendMessageUpwards ("RemovePlayer");
	}
}
