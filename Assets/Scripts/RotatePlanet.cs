using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
	private Vector3 previousMousePosition;
	private Transform cameraTransform;

	[SerializeField] float rotationSpeed = 5.0f;

	void Start()
	{
		cameraTransform = Camera.main.transform;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			previousMousePosition = Input.mousePosition;
		}

		if (Input.GetMouseButton(0))
		{
			Vector3 mouseDelta = Input.mousePosition - previousMousePosition;

			// Convert mouse movement to camera space
			Vector3 rotationAxis = cameraTransform.TransformDirection(Vector3.up);
			float rotationX = mouseDelta.y * rotationSpeed * Time.deltaTime;
			float rotationY = -mouseDelta.x * rotationSpeed * Time.deltaTime;

			// Rotate the object based on the camera's orientation
			transform.Rotate(rotationAxis, rotationY, Space.World);
			transform.Rotate(Vector3.right, rotationX, Space.World);

			previousMousePosition = Input.mousePosition;
		}
	}
}
