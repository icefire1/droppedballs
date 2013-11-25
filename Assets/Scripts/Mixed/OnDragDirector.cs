using UnityEngine;
using System.Collections;

public class OnDragDirector : MonoBehaviour {
	
	private StickManager receiver;
	private MouseOrbit mouseOrbit;
	
	// Use this for initialization
	void Start () {
		receiver = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<StickManager> ();
		mouseOrbit = Camera.main.GetComponent<MouseOrbit> ();
	}
	
	void OnDrag (Vector2 delta) {
		receiver.OnDrag(delta);
	}
	
	void OnPress (bool isDown) {
		mouseOrbit.enabled = !isDown;	
	}
}
