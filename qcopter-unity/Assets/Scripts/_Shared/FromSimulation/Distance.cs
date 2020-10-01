using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance
{
	private GameObject gameObject;
	private Transform transform;
	private Vector3 vector;

	public Distance() 
	{

	}

	public float getValue(GameObject aGameObject, Vector3 aVector)
	{
		gameObject = aGameObject;
		transform = gameObject.GetComponent<Transform>();
		vector = aVector;
		
		RaycastHit hitLocation;

		// If the raycast hits something...
		if(Physics.Raycast(transform.position, vector, out hitLocation))
		{
			// inches to meters
			float distance = hitLocation.distance;//UnityToSI.length(hitLocation.distance);

			// Returns distance to the hit point
			return distance;	
		}
		else
		{
			return -1.0f;
		}
	}
}
