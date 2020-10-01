using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SocketIO;

public class Session : MonoBehaviour
{
	private SocketIOComponent socketIO;
	private GameObject gameObject;

    public static float TIMESCALE = 1.0f;
    public static float SYNCTIME = 1.0f;
    public static int PHYSICSSOLVER = 255;

	private double t0 = 0.0f;
	private double t1 = 0.0f;
	private double dt = 0.0f;
	private double ct = 0.0f;

	void Start()
	{
		//UnityEditor.SceneView.FocusWindowIfItsOpen(typeof(UnityEditor.SceneView));
		Physics.defaultSolverIterations = Session.PHYSICSSOLVER;
		Time.timeScale = Session.TIMESCALE;

		// Gets socketIO intance ready to use
		gameObject = GameObject.Find("SocketIO");
		socketIO = gameObject.GetComponent<SocketIOComponent>();

		// Sets up callbacks for responding externam communication throught SocketIO
		socketIO.On("onConnect", onConnect);
		socketIO.On("onSetup", onSetup);	
		socketIO.On("onStream", onStream);
		socketIO.On("onDisconnect", onDisconnect);	
			
	}

	void FixedUpdate()
	{
		t0 = t1;
		t1 = Time.time;

		// Creates JSON object with desired data
		string jsonString = string.Format(
			@"{{
				""S00"": {0},
				""S01"": {1},
				""S02"": {2},
				""S03"": {3},
				""S04"": {4},
				""S05"": {5},
				""S06"": {6},
				""S07"": {7}}}",
				ct,
				dt,
				QCPlant.OUT12,
				QCPlant.OUT06,
				QCPlant.OUT13,
				QCPlant.OUT14,
				QCPlant.OUT15,
				QCPlant.OUT16
		);
		JSONObject jsonObject = new JSONObject(jsonString);

		// Sends JSON object created to the server
		socketIO.Emit("stream", jsonObject);
		Time.timeScale = 0.0f;

		dt = t1 - t0;
		ct = Time.time;
	}

	public void onConnect(SocketIOEvent e)
	{
		Time.timeScale = 1.1f;
	}

	public void onSetup(SocketIOEvent e)
	{
		SceneManager.LoadScene("Scene");
	}

	// Applies TIMESCALE changing based on setTIMESCALE() incoming command and data from server
	public void onStream(SocketIOEvent e)
	{
		//t1 = Time.time;

		string valueString = "";

		valueString = e.data.GetField("A01").ToString();
		float A01 = float.Parse(valueString);

		valueString = e.data.GetField("A02").ToString();
		float A02 = float.Parse(valueString);

		valueString = e.data.GetField("A03").ToString();
		float A03 = float.Parse(valueString);

		valueString = e.data.GetField("A04").ToString();
		float A04 = float.Parse(valueString);

		QCPlant.IN01 = A01;
		QCPlant.IN02 = A02;
		QCPlant.IN03 = A03;
		QCPlant.IN04 = A04;				


		//dt = t1 - t0;
		//Debug.Log(dt);

		Time.timeScale = 1.1f;
	}

	public void onDisconnect(SocketIOEvent e)
	{

	}
}
