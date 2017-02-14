using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleToBallVector;

	private bool gameStarted = false;

	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!gameStarted)
		{
			// Lock ball to paddle's position
			transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for mouseclick to initiate gameplay
			if(Input.GetMouseButtonDown(0))
			{
				gameStarted = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(gameStarted)
		{
			Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
			GetComponent<Rigidbody2D>().velocity += tweak;

			//GetComponent<AudioSource>().Play();
		}
	}
}
