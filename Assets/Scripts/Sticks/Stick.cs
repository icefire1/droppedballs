using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {
	
	public bool selected;
	
	public Material selectedDiffuse;
	private Material normalDiffuse;
	
	void Start () {
		normalDiffuse = renderer.material;
	}
	
	public void Selected (bool selected){
		this.selected = selected;
		if (selected)
			renderer.material = selectedDiffuse;
		else
			renderer.material = normalDiffuse;
	}
	
	// Move the stick based on a delta movement
	public void MoveStick (Vector2 delta) {
		transform.position += transform.forward * delta.x * Time.deltaTime;
	}
}
