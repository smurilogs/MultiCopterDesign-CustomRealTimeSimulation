
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QCPlant
{
	// Auxiliary objects
	private static GameObject gameObject;
	private static Transform transform;
	private static Rigidbody rigidbody;
	private	static ConstantForce constantForce;
	private	static HingeJoint hingeJoint;
	private	static JointMotor jointMotor;
	private static Vector3 vector;

	private static Position position = new Position();
	private static Rotation rotation = new Rotation();
	private static Distance distance = new Distance();
	private static LinearAcceleration linearAcceleration = new LinearAcceleration();
	private static LinearVelocity linearVelocity = new LinearVelocity();

	private static AngularVelocity angularVelocity = new AngularVelocity();
	private static AngularAcceleration angularAcceleration = new AngularAcceleration();

    public static void setup()
    {

    }

    // data in
    public static float IN01 = 0.0f;
    public static float IN02 = 0.0f;
    public static float IN03 = 0.0f;
    public static float IN04 = 0.0f;
    public static float IN05 = 0.0f;
    public static float IN06 = 0.0f;
    public static float IN07 = 0.0f;
    public static float IN08 = 0.0f;

	public static void processINs()
	{
		// TODO: deve-se verificar como é feito o controle de torque no Unity. Aqui está sendo feito utilizando
		//       HingeJoint.force (que parece estar diretamente conectado com HingeJoint.targetVelocity - uma
		//		 influencia na outra), mas não entendi muito bem essa variável. Existe a possibilidade de se utilizar
		//       Rigidbody.addTorque, mas ainda não testei. Fazer, então, a comparação entre os dois tipos de atuação.

		// All calculations considering max input value as 100
		// Max up force defined as 10 N (100 x 0.1 = 10.0 N)
		// Max Angular Velocity defined as 5000 rads/s (100 x 50.0 = 5000.0 rads/s)
		// Max Torque defined as 50 N.m (100 x 0.5 = 50 N.m)

		// QCPropellerFR

		gameObject = GameObject.Find("QCMotorFR");
		transform = gameObject.GetComponent<Transform>();
		constantForce = gameObject.GetComponent<ConstantForce>();
		vector = Vector3.Normalize(transform.up) * QCPlant.IN01 * 0.1f;
		constantForce.force = vector;
		vector = Vector3.Normalize(transform.up) * QCPlant.IN01 * 0.01f;
		constantForce.torque = -vector;

		gameObject = GameObject.Find("QCPropellerFR");		
		hingeJoint = gameObject.GetComponent<HingeJoint>();
		jointMotor = hingeJoint.motor;
		jointMotor.force = 2400.0f;
		jointMotor.targetVelocity = 5000.0f;
		hingeJoint.motor = jointMotor;
		hingeJoint.useMotor = true;


		// QCPropellerFL

		gameObject = GameObject.Find("QCMotorFL");
		transform = gameObject.GetComponent<Transform>();
		constantForce = gameObject.GetComponent<ConstantForce>();
		vector = Vector3.Normalize(transform.up) * QCPlant.IN02 * 0.1f;
		constantForce.force = vector;
		vector = Vector3.Normalize(transform.up) * QCPlant.IN02 * 0.01f;
		constantForce.torque = vector;

		gameObject = GameObject.Find("QCPropellerFL");
		hingeJoint = gameObject.GetComponent<HingeJoint>();
		jointMotor = hingeJoint.motor;
		jointMotor.force = 2400.0f;
		jointMotor.targetVelocity = -5000.0f;	
		hingeJoint.motor = jointMotor;
		hingeJoint.useMotor = true;

		// QCPropellerBR

		gameObject = GameObject.Find("QCMotorBR");
		transform = gameObject.GetComponent<Transform>();
		constantForce = gameObject.GetComponent<ConstantForce>();
		vector = Vector3.Normalize(transform.up) * QCPlant.IN03 * 0.1f;
		constantForce.force = vector;
		vector = Vector3.Normalize(transform.up) * QCPlant.IN03 * 0.01f;
		constantForce.torque = vector;

		gameObject = GameObject.Find("QCPropellerBR");
		hingeJoint = gameObject.GetComponent<HingeJoint>();
		jointMotor = hingeJoint.motor;
		jointMotor.force = 2400.0f;
		jointMotor.targetVelocity = -5000.0f;
		hingeJoint.motor = jointMotor;
		hingeJoint.useMotor = true;

		// QCPropellerBL

		gameObject = GameObject.Find("QCMotorBL");
		transform = gameObject.GetComponent<Transform>();
		constantForce = gameObject.GetComponent<ConstantForce>();
		vector = Vector3.Normalize(transform.up) * QCPlant.IN04 * 0.1f;
		constantForce.force = vector;
		vector = Vector3.Normalize(transform.up) * QCPlant.IN04 * 0.01f;
		constantForce.torque = -vector;

		gameObject = GameObject.Find("QCPropellerBL");
		hingeJoint = gameObject.GetComponent<HingeJoint>();
		jointMotor = hingeJoint.motor;
		jointMotor.force = 2400.0f;
		jointMotor.targetVelocity = 5000.0f;
		hingeJoint.motor = jointMotor;
		hingeJoint.useMotor = true;

	}

	// data out
    public static float OUT01 = 0.0f;
    public static float OUT02 = 0.0f;
    public static float OUT03 = 0.0f;
    public static float OUT04 = 0.0f;
    public static float OUT05 = 0.0f;
    public static float OUT06 = 0.0f;
    public static float OUT07 = 0.0f;
    public static float OUT08 = 0.0f;
    public static float OUT09 = 0.0f;
    public static float OUT10 = 0.0f;
    public static float OUT11 = 0.0f;
    public static float OUT12 = 0.0f;	
    public static float OUT13 = 0.0f;
    public static float OUT14 = 0.0f;	
    public static float OUT15 = 0.0f;	
    public static float OUT16 = 0.0f;	

	public static void processOUTs()
	{
		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT01 = angularVelocity.getZ(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT02 = rotation.getZ(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT03 = angularVelocity.getX(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT04 = rotation.getX(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT05 = angularVelocity.getY(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT06 = rotation.getY(gameObject);


		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT07 = linearVelocity.getGlobalY(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT08 = distance.getValue(gameObject, -Vector3.up);
		//transform = gameObject.GetComponent<Transform>();
		//Debug.DrawRay(transform.position,  new Vector3(1.0f, 0.0f, 0.0f) * 5000.0f, Color.red);


		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT09 = linearVelocity.getGlobalX(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT11 = linearVelocity.getGlobalZ(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT12 = position.getY(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT13 = position.getX(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT16 = linearVelocity.getGlobalX(gameObject);


		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT14 = linearVelocity.getGlobalZ(gameObject);

		gameObject = GameObject.Find("QCLoad0");
		QCPlant.OUT15 = position.getZ(gameObject);

		//Debug.Log(" Pitch: " + QCPlant.var2PV + " | Roll: " + QCPlant.var4PV + " | Yaw: " + QCPlant.var6PV + " | Alt: " + QCPlant.var8PV);
		//Debug.Log(" FR: " + QCPlant.FRActuatorCV + " | FL: " + QCPlant.FLActuatorCV + " | BR: " + QCPlant.BRActuatorCV + " | BL: " + QCPlant.BLActuatorCV);
	}
}
