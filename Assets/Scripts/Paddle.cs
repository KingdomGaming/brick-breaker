using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(autoPlay)
		{
			AutoPlay();
		}
		else
		{
			Vector3 paddlePos = new Vector3(0.5f, transform.position.y);
			float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 0.5f, 15.5f);
			paddlePos.x = mousePosInBlocks;

			transform.position = paddlePos;
		}
	}

	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3(0.5f, transform.position.y);
		float ballPosInBlocks = Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f);
		paddlePos.x = ballPosInBlocks;

		transform.position = paddlePos;
	}
}
