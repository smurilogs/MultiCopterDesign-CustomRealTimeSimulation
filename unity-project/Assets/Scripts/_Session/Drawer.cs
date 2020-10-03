using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Drawer
{
	private static GameObject gameObject;
    private static Transform transform;

	public static void drawRotationConstraints(GameObject aGameObject, Color aColorX, Color aColorY, Color aColorZ)
	{
		gameObject = aGameObject;
		Color colorX = aColorX;
		Color colorY = aColorY;
		Color colorZ = aColorZ;

	    transform = gameObject.GetComponent<Transform>();
		DebugExtension.DebugCircle(transform.position, Vector3.up, colorY, 0.5f);

	    transform = gameObject.GetComponent<Transform>();
		DebugExtension.DebugCircle(transform.position, Vector3.right, colorX, 0.5f);

	    transform = gameObject.GetComponent<Transform>();
		DebugExtension.DebugCircle(transform.position, Vector3.forward, colorZ, 0.5f);
	}

	public static void drawPositionConstraints(GameObject aGameObject, Color aColorX, Color aColorY, Color aColorZ)
	{
		gameObject = aGameObject;
		Color colorX = aColorX;
		Color colorY = aColorY;
		Color colorZ = aColorZ;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, Vector3.up * 0.5f, colorY);
		Debug.DrawRay(transform.position, -Vector3.up * 0.5f, colorY);


	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, Vector3.forward * 0.5f, colorZ);
		Debug.DrawRay(transform.position, -Vector3.forward * 0.5f, colorZ);

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, Vector3.right * 0.5f, colorX);
		Debug.DrawRay(transform.position, -Vector3.right * 0.5f, colorX);
	}



	public static void drawRelativeFront(GameObject aGameObject, Color aColor)
	{
		gameObject = aGameObject;
		Color color = aColor;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, transform.right * 0.6f, color);
	}

	public static void drawRelativeUp(GameObject aGameObject, Color aColor)
	{
		gameObject = aGameObject;
		Color color = aColor;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, transform.up * 0.6f, color);
	}	

	public static void drawRelativeDown(GameObject aGameObject, Color aColor)
	{
		gameObject = aGameObject;
		Color color = aColor;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, -transform.up * 0.6f, color);
	}



	public static void drawGlobalFront(GameObject aGameObject, Color aColor)
	{
		gameObject = aGameObject;
		Color color = aColor;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, Vector3.right * 0.6f, color);
	}

	public static void drawGlobalUp(GameObject aGameObject, Color aColor)
	{
		gameObject = aGameObject;
		Color color = aColor;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, Vector3.up * 0.6f, color);
	}	

	public static void drawGlobalDown(GameObject aGameObject, Color aColor)
	{
		gameObject = aGameObject;
		Color color = aColor;

	    transform = gameObject.GetComponent<Transform>();
		Debug.DrawRay(transform.position, -Vector3.up * 0.6f, color);
	}	
}

