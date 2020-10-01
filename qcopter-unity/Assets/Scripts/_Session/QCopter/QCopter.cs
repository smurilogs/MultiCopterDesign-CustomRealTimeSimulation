using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QCopter : MonoBehaviour
{
	// Auxiliary objects
	private GameObject gameObject;
	private Rigidbody rigidbody;
	private Transform transform;

	void Start()
	{
		gameObject = GameObject.Find("QCFrame");
		rigidbody = gameObject.GetComponent<Rigidbody>();
		rigidbody.isKinematic = true;

		QCPlant.setup();
		//QCControl.setup();
	}

	void FixedUpdate()
	{
		// I'VE FOUND A PROBLEM WHEN USING HINGE JOINTS:
		// IN THE SIMULATION FIRST TIME UPDATES, RIGIBBODIES ATTACHED DISCONNECT
		// FROM EACH OTHER, AS IF THEY WERE IN DIFFERENT TIMESCALES. THE SOLUTION
		// WAS TO KEEP THE MODEL IN KINEMATIC MODE UNTIL UNITY SYNC RIGIDBODIES
		// AT THE SAME TIMESCALE

		if(Time.time > Session.SYNCTIME)
		{
			gameObject = GameObject.Find("QCFrame");
			rigidbody = gameObject.GetComponent<Rigidbody>();
			rigidbody.isKinematic = false;

			// // Altitude
			// float value = Input.GetAxis("Vertical") * 0.01f;
			// QCData.var8SP += value;
			//
			// // Yaw
			// value = Input.GetAxis("Horizontal") * 0.5f;
			// QCData.var6SP += value;
			//
			// // Roll
			// value = Input.GetAxis("Vertical2") * 70.0f;
			// QCData.var4SP = -value;
			//
			// // Pitch
			// value = Input.GetAxis("Horizontal2") * 70.0f;
			// QCData.var2SP = -value;

			// Dynamic data refreshment
			QCPlant.processINs();
			QCPlant.processOUTs();
		}
	}
}
