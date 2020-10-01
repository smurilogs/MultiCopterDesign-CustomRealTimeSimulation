
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation
{
	private float resultX = 0.0f;
	private float currX = 0.0f;
	private float lastX = 0.0f;

	private float resultY = 0.0f;
	private float currY = 0.0f;
	private float lastY = 0.0f;

	private float resultZ = 0.0f;
	private float currZ = 0.0f;
	private float lastZ = 0.0f;

	public Rotation()
	{

	}

	//
	public float getX(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();

		// Gets normalized object front vector projection on plane YZ
		Vector3 objectUp = transform.forward;
		Vector3 absoluteUp = new Vector3(0.0f, 1.0f, 0.0f);
		Vector3 angleAxis = transform.right;

		// Gets angle in a absolute scale - result: CCW=[-180;0], CW=[0,180]
		float measuredAngle = Vector3.SignedAngle(absoluteUp, objectUp, angleAxis);

		// Debug.DrawRay(transform.position, absoluteUp * 5.0f, Color.red);
		// Debug.DrawRay(transform.position, objectUp * 5.0f, Color.blue);
		// Debug.DrawRay(transform.position, angleAxis * 5.0f, Color.yellow);

		// Turns result into CW=[0,360]
		 if(measuredAngle < 0.0f)
		 	measuredAngle = 360.0f + measuredAngle;

		lastX = currX;
        currX = measuredAngle;

		if(currX > lastX)
		{
			if((currX - lastX) >= 270.0f)
				resultX -= ((360.0f - currX) + lastX);
			else
				resultX -= (lastX - currX);
		}
		else
		{
			if((lastX - currX) >= 270.0f)
				resultX += ((360.0f - lastX) + currX);
			else
				resultX += (currX - lastX);
		}

		return resultX;
	}

	public float getY(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();

		// LOCAL - Gets normalized object front vector projection on plane XZ
		// Vector3 objectFront = transform.right;
		// Vector3 objectNorth = new Vector3(1.0f, transform.right.y, 0.0f);
		// Vector3 angleAxis = transform.forward;

		// GLOBAL - Gets normalized object front vector projection on plane XZ
		Vector3 objectFront = new Vector3(transform.right.x, 0.0f, transform.right.z).normalized;
		Vector3 objectNorth = new Vector3(1.0f, 0.0f, 0.0f);
		Vector3 angleAxis = new Vector3(0.0f, 1.0f, 0.0f);

		// Gets angle in a absolute scale - result: CCW=[-180;0], CW=[0,180]
		float measuredAngle = Vector3.SignedAngle(objectNorth, objectFront, angleAxis);

		Debug.DrawRay(transform.position, objectNorth * 5.0f, Color.red);
		Debug.DrawRay(transform.position, objectFront * 5.0f, Color.blue);
		Debug.DrawRay(transform.position, angleAxis * 5.0f, Color.yellow);

		// Turns result into CW=[0,360]
		 if(measuredAngle < 0.0f)
		 	measuredAngle = 360.0f + measuredAngle;

		lastY = currY;
        currY = measuredAngle;

		if(currY > lastY)
		{
			if((currY - lastY) >= 270.0f)
				resultY -= ((360.0f - currY) + lastY);
			else
				resultY -= (lastY - currY);
		}
		else
		{
			if((lastY - currY) >= 270.0f)
				resultY += ((360.0f - lastY) + currY);
			else
				resultY += (currY - lastY);
		}

		return resultY;
	}

	public float getZ(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();

		// Gets normalized object front vector projection on plane YZ
		Vector3 objectUp = transform.forward;
		Vector3 absoluteUp = new Vector3(0.0f, 1.0f, 0.0f);
		Vector3 angleAxis = transform.up;

		// Gets angle in a absolute scale - result: CCW=[-180;0], CW=[0,180]
		float measuredAngle = Vector3.SignedAngle(absoluteUp, objectUp, angleAxis);

		// Debug.DrawRay(transform.position, absoluteUp * 5.0f, Color.red);
		// Debug.DrawRay(transform.position, objectUp  * 5.0f, Color.blue);
		// Debug.DrawRay(transform.position, angleAxis  * 5.0f, Color.yellow);

		// Turns result into CW=[0,360]
		 if(measuredAngle < 0.0f)
		 	measuredAngle = 360.0f + measuredAngle;

		lastZ = currZ;
        currZ = measuredAngle;

		if(currZ > lastZ)
		{
			if((currZ - lastZ) >= 270.0f)
				resultZ -= ((360.0f - currZ) + lastZ);
			else
				resultZ -= (lastZ - currZ);
		}
		else
		{
			if((lastZ - currZ) >= 270.0f)
				resultZ += ((360.0f - lastZ) + currZ);
			else
				resultZ += (currZ - lastZ);
		}

		return resultZ;
	}
}
