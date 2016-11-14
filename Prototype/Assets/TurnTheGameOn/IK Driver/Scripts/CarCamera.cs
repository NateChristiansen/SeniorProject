using UnityEngine;
using System.Collections;

public class CarCamera : MonoBehaviour {

	public enum CameraType{ CarCamera, HelmetCamera}


	public bool mobile;
	public CameraType cameraType;
	public Camera carCamera;
	public Camera helmetCamera;
    public Transform car;
    public float distance;
    public float height;
    public float rotationDamping;
    public float heightDamping;
    public float zoomRatio;
    public float DefaultFOV;
    private Vector3 rotationVector;
    private Vector3 position;
    private Rigidbody carBody;
	[Header("Camera Pivot")]
	public float max;
	public float value;
	public float minPivotMoveSpeed;
	public float maxPivotMoveSpeed;
	public float pivotMoveSpeed;
	public Vector3 targetPivotPosition;

	void Update(){
		if (cameraType == CameraType.CarCamera) {
			helmetCamera.gameObject.SetActive(false);
			carCamera.gameObject.SetActive(true);
		}else if (cameraType == CameraType.HelmetCamera){
			carCamera.gameObject.SetActive(false);
			helmetCamera.gameObject.SetActive(true);
		}
	}

    void LateUpdate() {
		
		if (cameraType == CameraType.CarCamera) {			
			if (!car) {
				car = transform.parent.transform;
				transform.parent = null;
				carBody = car.GetComponent<Rigidbody> ();
			}
			var wantedAngle = rotationVector.y;
			var wantedHeight = car.position.y + height;
			var myAngle = transform.eulerAngles.y;
			var myHeight = transform.position.y;
			myAngle = Mathf.LerpAngle (myAngle, wantedAngle, rotationDamping * Time.deltaTime);
			myHeight = Mathf.Lerp (myHeight, wantedHeight, heightDamping * Time.deltaTime);
			var currentRotation = Quaternion.Euler (0, myAngle, 0);
			transform.position = car.position;
			transform.position -= currentRotation * Vector3.forward * distance;
			position = transform.position;
			position.y = myHeight;
			transform.position = position;
			transform.LookAt (car);
			carCamera.transform.LookAt (car);
			//Vector3.Lerp (cameraComponent.transform.position, targetPivotPosition, pivotMoveSpeed * Time.deltaTime);
			if (Input.GetAxis ("Horizontal") > 0) {
				value = -max;
				pivotMoveSpeed = minPivotMoveSpeed;
			} else if (Input.GetAxis ("Horizontal") < 0) {
				value = max;
				pivotMoveSpeed = minPivotMoveSpeed;
			} else {
				value = 0;
				pivotMoveSpeed = Mathf.Lerp (pivotMoveSpeed, maxPivotMoveSpeed, 1 * Time.deltaTime);
			}
			targetPivotPosition.x = Mathf.Lerp (targetPivotPosition.x, value, pivotMoveSpeed * Time.deltaTime);
			carCamera.transform.localPosition = targetPivotPosition;
		}
		else if (cameraType == CameraType.HelmetCamera){
			
		}

    }

	public void CycleCamera(){
		if (cameraType == CameraType.CarCamera) {
			cameraType = CameraType.HelmetCamera;
		}else if (cameraType == CameraType.HelmetCamera){
			cameraType = CameraType.CarCamera;
		}
	}
		
    void FixedUpdate(){
		
		if (cameraType == CameraType.CarCamera) {
			if (car && !mobile) {
				var localVelocity = car.InverseTransformDirection (carBody.velocity);
				if (localVelocity.z < -0.5f && Input.GetAxis ("Vertical") == -1) {
					rotationVector.y = car.eulerAngles.y + 180f;
				} else {
					rotationVector.y = car.eulerAngles.y;
				}
				var acc = carBody.velocity.magnitude;
				carCamera.fieldOfView = DefaultFOV + acc * zoomRatio * Time.deltaTime;
				//cameraComponent.transform.rotation = pivotRotation;
			}else if (car && mobile){
				
				var localVelocity = car.InverseTransformDirection (carBody.velocity);
				if (localVelocity.z < -0.5f && UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("Vertical") == -1) {
					rotationVector.y = car.eulerAngles.y + 180f;
				} else {
					rotationVector.y = car.eulerAngles.y;
				}
				var acc = carBody.velocity.magnitude;
				carCamera.fieldOfView = DefaultFOV + acc * zoomRatio * Time.deltaTime;
			}
		}
		else if (cameraType == CameraType.HelmetCamera){
		
		}

    }

}