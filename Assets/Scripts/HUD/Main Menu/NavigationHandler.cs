using UnityEngine;
using System.Collections;

public class NavigationHandler : MonoBehaviour {
	
	public GameObject mainMenu;
	public bool tweenTabs;
	public bool loadMainMenuOnStart;
	
	private GameObject currPanel;

	// Use this for initialization
	void Start () {
		if (loadMainMenuOnStart && mainMenu) {
			mainMenu.SetActive(true);
			currPanel = mainMenu;
		}
	}
	
	// Change menu tab
	public void changeMenuTab (GameObject panel) {
		if (tweenTabs) {
			PlayTweens ();
		}
		else {
			if (currPanel)
				currPanel.SetActive(false);
			panel.SetActive(true);
			currPanel = panel;
		}
	}
	
	void PlayTweens () {
		currPanel.SetActive(false);
	}
}
