using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearVelocity
{
	public LinearVelocity()
	{

	}

	public float getGlobalX(GameObject aGameObject)
	{
		Rigidbody rigidbody = aGameObject.GetComponent<Rigidbody>();
		float velocity = rigidbody.velocity.x;

		return velocity;
	}

	public float getGlobalY(GameObject aGameObject)
	{
		Rigidbody rigidbody = aGameObject.GetComponent<Rigidbody>();
		float velocity = rigidbody.velocity.y;

		return velocity;
	}

	public float getGlobalZ(GameObject aGameObject)
	{
		Rigidbody rigidbody = aGameObject.GetComponent<Rigidbody>();
		float velocity = rigidbody.velocity.z;

		return velocity;
	}	

	// public float getRelativeX(GameObject aGameObject)
	// {

	// }

	// public float getRelativeY(GameObject aGameObject)
	// {

	// }

	// public float getRelativeZ(GameObject aGameObject)
	// {

	// }	
}
