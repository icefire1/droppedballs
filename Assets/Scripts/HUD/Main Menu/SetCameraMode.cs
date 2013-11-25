using UnityEngine;
using System.Collections;

public class SetCameraMode : MonoBehaviour {
	
	public enum CameraModes{
		Manual, Rotating
	}

	public CameraModes cameraMode = CameraModes.Rotating;

	private MouseOrbit camera;
	private Gamemanager gamemanager;


	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<MouseOrbit> ();
		gamemanager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Gamemanager> ();
		if (cameraMode == CameraModes.Rotating)
			camera.autoRotate = true;
		else
			camera.autoRotate = false;
	}
	
	// Update is called once per frame
//	void Update () {
//		if (gamemanager.GameActive) {
//			camera.autoRotate = false;
//			cameraMode = CameraModes.Manual;
//		}
//		else {
//			camera.autoRotate = true;
//			cameraMode = CameraModes.Rotating;
//		}
//	}

	public void CameraMode (CameraModes cameraMode) {
		this.cameraMode = cameraMode;
		if (cameraMode == CameraModes.Rotating)
			camera.autoRotate = true;
		else
			camera.autoRotate = false;
	}
}
