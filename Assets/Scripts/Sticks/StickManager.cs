using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StickManager : MonoBehaviour {
	
	public LayerMask stickMask;
	public bool forceAndroidInput = true;
	public float sensitivity = 3.5f;
	
	[HideInInspector]public bool canSelectStick = true;
	private Transform selectedStick;
	private Collider beginCollider;

	void OnDisable () {
		if (selectedStick != null)
			selectedStick.SendMessage("Selected", false, SendMessageOptions.DontRequireReceiver);
	}
	
	public void OnDrag (Vector2 delta) {
		if (selectedStick != null) {
			delta *= 1.0f / (sensitivity*sensitivity);
			canSelectStick = false;
			selectedStick.SendMessage("MoveStick", delta, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	// Update is called once per frame
	void Update () {		
		if (canSelectStick) {
			if (Application.platform != RuntimePlatform.Android && !forceAndroidInput){
				// Handle mouse presses
				if(Input.GetMouseButtonDown(0)){
				    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					
		            if(Physics.Raycast(ray, out hit, Mathf.Infinity, stickMask)){
						if (selectedStick != null)
							selectedStick.SendMessage("Selected", false, SendMessageOptions.DontRequireReceiver);
//						selectedStick = hit.collider.gameObject.transform.parent;
						selectedStick = hit.collider.gameObject.transform;
						selectedStick.SendMessage("Selected", true, SendMessageOptions.DontRequireReceiver);
						Debug.Log (selectedStick + " is selected");
					}
				}
				
			}
			if (Application.platform == RuntimePlatform.Android || forceAndroidInput){
				// Handle touches
				foreach (Touch touch in Input.touches)
				{
					// Select a stick if a touch both started and ended on the same stick 
					if (touch.phase == TouchPhase.Began)
					{
			            Ray ray = Camera.main.ScreenPointToRay(touch.position);
						RaycastHit hit;
			            if(Physics.Raycast(ray, out hit, Mathf.Infinity, stickMask)){
							beginCollider = hit.collider;  
						}
					}
					
					if (touch.phase == TouchPhase.Ended)
					{
			            Ray ray = Camera.main.ScreenPointToRay(touch.position);
						RaycastHit hit;
						
			            if(Physics.Raycast(ray, out hit, Mathf.Infinity, stickMask)){
							if (beginCollider == hit.collider){
								if (selectedStick != null)
									selectedStick.SendMessage("Selected", false, SendMessageOptions.DontRequireReceiver);
//								selectedStick = hit.collider.gameObject.transform.parent;
								selectedStick = hit.collider.gameObject.transform;
								selectedStick.SendMessage("Selected", true, SendMessageOptions.DontRequireReceiver);
								Debug.Log (selectedStick + " is selected");
							} else {
								if (selectedStick != null)
									selectedStick.SendMessage("Selected", false, SendMessageOptions.DontRequireReceiver);
								selectedStick = null;
							}
						
						}
					}
				}
			}
		}
	}
}
