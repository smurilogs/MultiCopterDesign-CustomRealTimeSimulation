
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{

	public Position() 
	{

	}

	public float getX(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();
		float x = transform.position.x;

		return x;
	}

	public float getY(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();
		float y = transform.position.y;

		return y;
	}

	public float getZ(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();
		float z = transform.position.z;

		return z;
	}	
}

