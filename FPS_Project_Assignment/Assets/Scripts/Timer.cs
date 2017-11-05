using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timerText;

	private float StartTime;
	private bool Finished = false;

	// Use this for initialization
	void Start () {

		StartTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Finished)
			return;

		else
		{
			float t = Time.time - StartTime;

			string minutes = ((int) t / 60).ToString();
			string seconds = (t % 60).ToString("F2");

			timerText.text = minutes + ":" + seconds;
		}

	
	
	}

	void OnTriggerEnter(Collider Col)
	{
		if (Col.gameObject.tag == "WinBox") 
		{
			Time.timeScale = 0;
		}


	}

	public void Finish()
	{
		Finished = true;
	}
}
