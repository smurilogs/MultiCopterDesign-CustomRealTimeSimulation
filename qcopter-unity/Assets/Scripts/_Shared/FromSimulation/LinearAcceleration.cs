using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearAcceleration
{
	private float lastGlobalXVelocity = 0;
	private float lastGlobalYVelocity = 0;
	private float lastGlobalZVelocity = 0;

	// private float lastRelativeXVelocity = 0;
	// private float lastRelativeYVelocity = 0;
	// private float lastRelativeZVelocity = 0;

	public float getGlobalX(GameObject aGameObject)
	{
		Rigidbody rigidbody = aGameObject.GetComponent<Rigidbody>();
		
		float acceleration = (rigidbody.velocity.x - lastGlobalXVelocity) / Time.fixedDeltaTime;
		lastGlobalXVelocity = rigidbody.velocity.x;

		return acceleration;
	}

	public float getGlobalY(GameObject aGameObject)
	{
		Rigidbody rigidbody = aGameObject.GetComponent<Rigidbody>();
		
		float acceleration = (rigidbody.velocity.y - lastGlobalYVelocity) / Time.fixedDeltaTime;
		lastGlobalYVelocity = rigidbody.velocity.y;

		return acceleration;
	}

	public float getGlobalZ(GameObject aGameObject)
	{
		Rigidbody rigidbody = aGameObject.GetComponent<Rigidbody>();
		
		float acceleration = (rigidbody.velocity.z - lastGlobalZVelocity) / Time.fixedDeltaTime;
		lastGlobalZVelocity = rigidbody.velocity.z;

		return acceleration;
	}	

	// public float getRelativeX(Rigidbody rigidbody)
	// {

	// }

	// public float getRelativeY(Rigidbody rigidbody)
	// {

	// }

	// public float getRelativeZ(Rigidbody rigidbody)
	// {

	// }	
}
