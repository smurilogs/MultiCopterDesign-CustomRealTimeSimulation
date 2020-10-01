using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularVelocity
{
	private float lastXAngle = 0.0f;
	private float lastYAngle = 0.0f;
	private float lastZAngle = 0.0f;

	private float currentXAngle = 0.0f;
	private float currentYAngle = 0.0f;
	private float currentZAngle = 0.0f;

	private Rotation rotation;
    
    public AngularVelocity()
    {
		rotation = new Rotation();
    }

	public float getX(GameObject aGameObject)
	{
		lastXAngle = currentXAngle;
		currentXAngle = rotation.getX(aGameObject);

		float angularVelocity = (currentXAngle - lastXAngle) / Time.fixedDeltaTime;

		return angularVelocity;
	}

	public float getY(GameObject aGameObject)
	{
		lastYAngle = currentYAngle;
		currentYAngle = rotation.getY(aGameObject);

		float angularVelocity = (currentYAngle - lastYAngle) / Time.fixedDeltaTime;

		return angularVelocity;
	}

	public float getZ(GameObject aGameObject)
	{
		lastZAngle = currentZAngle;
		currentZAngle = rotation.getZ(aGameObject);

		float angularVelocity = (currentZAngle - lastZAngle) / Time.fixedDeltaTime;

		return angularVelocity;
	}

}
