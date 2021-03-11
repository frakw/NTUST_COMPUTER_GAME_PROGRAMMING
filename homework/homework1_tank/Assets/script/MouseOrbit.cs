using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour 
{
	public Transform target;
	public float distance = 10.0f;
	public float minDistance = 1.5f;
	public float maxDistance = 15f;
	
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	
	public float yMinLimit = -20.0f;
	public float yMaxLimit = 80.0f;
	
	private float x = 0.0f;
	private float y = 0.0f;
	private bool control = true;

	public GameObject turret;

	void Start () 
	{
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		if (GetComponent<Rigidbody>())
		GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	void LateUpdate () 
	{
		//if(Input.GetKey(KeyCode.Space))
		//control = false;
		//else
		//control = true;
		if (control)
		{
			if (target)
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.01f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.01f;

				y = ClampAngle(y, yMinLimit, yMaxLimit);

				Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
				Vector3 position = rotation * (new Vector3(0.0f, 0.0f, -distance)) + target.position;

				transform.rotation = rotation;
				transform.position = position;
			}
			distance += -300.0f * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
			if (distance < minDistance)
				distance = minDistance;
			else
			if (distance > maxDistance)
				distance = maxDistance;
		}
	}
	
	static float ClampAngle (float angle, float min, float max) 
	{
		if (angle < -360.0f)
			angle += 360.0f;
		if (angle > 360.0f)
			angle -= 360.0f;
		return Mathf.Clamp (angle, min, max);
    }
}
