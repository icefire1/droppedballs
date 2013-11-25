using UnityEngine;
using System.Collections;

public class MenuNavigation : MonoBehaviour {
	
	public GameObject targetPanel;
	
	private NavigationHandler navigationHandler;

	// Use this for initialization
	void Start () {
		navigationHandler = GameObject.FindGameObjectWithTag ("NavigationHandler").GetComponent<NavigationHandler> ();
	}
	
	void OnClick () {
		navigationHandler.changeMenuTab(targetPanel);
	}
}
