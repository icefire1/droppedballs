using UnityEngine;
using System.Collections;
 
public class MouseOrbit : MonoBehaviour{
    public Transform target;

	public float autoRotateSpeed = 10;
	public bool autoRotate = false;
	
	public float zoomSpeed = 5f;
	
    public float distance = 10.0f;
    public float maxDistance = 3.0f;
    public float minDistance = 0.5f;

    public float xSpeed = 40.0f;
    public float ySpeed = 40.0f;

    public float yMinLimit = -20;
    public float yMaxLimit = 80;
	
	public float smoothTime = 0.3f;
	public float pcSensitivity = 15.0f;

    private float x = 0.0f;
    private float y = 0.0f;
	
	private float xSmooth = 0.0f;
	private float ySmooth = 0.0f; 
	private float xVelocity = 0.0f;
	private float yVelocity = 0.0f;
	 
	private Vector3 posSmooth = Vector3.zero;
	private Vector3 posVelocity = Vector3.zero;

    void Start(){
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (rigidbody){
            rigidbody.freezeRotation = true;
		}
    }
	
	void OnDisable() {
		x -= (x - xSmooth);
		y -= (y - ySmooth);
		xSmooth = x;
		ySmooth = y;
	}

    void Update(){
    	if(autoRotate){
    		AutoRotate();
    	} else {
    		ManualRotate();
    	}
    }

    static float ClampAngle(float angle, float min, float max){
        if (angle < -360){
            angle += 360;
        }
        if (angle > 360){
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }

    private void AutoRotate(){
    	transform.RotateAround(target.position, Vector3.up, autoRotateSpeed * Time.deltaTime);
    }

    private void ManualRotate(){
    	#region Zoom Controlle
		distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 12 * Time.deltaTime * pcSensitivity;
		
		if (Input.touchCount == 2){
			Touch touch1 = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);
			
			Vector2 curDist = touch1.position - touch2.position;
			Vector2 prevDist = (touch1.position - touch1.deltaPosition) - (touch2.position - touch2.deltaPosition);
			
			float delta = curDist.magnitude - prevDist.magnitude;
			
			distance -= delta * zoomSpeed * Time.deltaTime;
		}
		
		if(distance < minDistance){
			distance = minDistance;
		} else if(distance > maxDistance){
			distance = maxDistance;
		}
		#endregion
		
        if(target){
			if (Application.platform != RuntimePlatform.Android) {
				if(Input.GetMouseButton(0)){
					x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime * pcSensitivity;
					y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime * pcSensitivity;
				}
			}
			
			if (Input.touchCount == 1){
				x += Input.touches[0].deltaPosition.x * xSpeed * Time.deltaTime;
		        y -= Input.touches[0].deltaPosition.y * ySpeed * Time.deltaTime;
		    }
			
			xSmooth = Mathf.SmoothDamp(xSmooth, x, ref xVelocity, smoothTime);
	        ySmooth = Mathf.SmoothDamp(ySmooth, y, ref yVelocity, smoothTime);
	 
	        ySmooth = ClampAngle(ySmooth, yMinLimit, yMaxLimit);
	 
	        Quaternion rotation = Quaternion.Euler(ySmooth, xSmooth, 0);
 
        	posSmooth = target.position;
			
            transform.rotation = rotation;
        	transform.position = rotation * new Vector3(0, 0, -distance) + posSmooth;
        }
    }
}