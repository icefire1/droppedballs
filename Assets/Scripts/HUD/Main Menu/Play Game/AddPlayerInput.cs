using UnityEngine;
using System.Collections;

public class AddPlayerInput : MonoBehaviour {
	
	public GameObject inputGO;
	
	void OnClick () {
		inputGO.SetActive(true);
	}	
}
