using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularAcceleration
{
	private float lastXVelocity = 0;
	private float lastYVelocity = 0;
	private float lastZVelocity = 0;

    private AngularVelocity angularVelocity;   

	public AngularAcceleration()
    {
        angularVelocity = new AngularVelocity();
    }

	public float getX(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();

        float acceleration = (angularVelocity.getX(aGameObject) - lastXVelocity) / Time.fixedDeltaTime;
        lastXVelocity = angularVelocity.getX(aGameObject);

		return acceleration;
	}

	public float getY(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();

        float acceleration = (angularVelocity.getY(aGameObject) - lastYVelocity) / Time.fixedDeltaTime;
        lastYVelocity = angularVelocity.getY(aGameObject);

		return acceleration;
	}   

	public float getZ(GameObject aGameObject)
	{
		Transform transform = aGameObject.GetComponent<Transform>();

        float acceleration = (angularVelocity.getZ(aGameObject) - lastZVelocity) / Time.fixedDeltaTime;
        lastZVelocity = angularVelocity.getZ(aGameObject);

		return acceleration;
	} 
}
