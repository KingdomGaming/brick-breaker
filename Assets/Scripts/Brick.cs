using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	private int timesHit;
	private bool isBreakable;

	public static int breakableCount = 0;
	public Sprite[] hitSprites;

	public AudioClip crack;
	public AudioClip impact;
	public GameObject smoke;

	private LevelManager levelManager;

	// Use this for initialization
	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		timesHit = 0;
		isBreakable = (this.tag == "Breakable");

		if(isBreakable)
		{
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(isBreakable)
		{
			HandleHits();
		}
	}

	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if(timesHit >= maxHits)
		{
			breakableCount--;
			EmitSmoke();
			AudioSource.PlayClipAtPoint(crack, transform.position);
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		}
		else
		{
			LoadSprites();
			AudioSource.PlayClipAtPoint(impact, transform.position, 2.0f);
		}
	}

	void EmitSmoke()
	{
		GameObject smokePuff = (GameObject) Instantiate(smoke, this.transform.position, Quaternion.identity);
		smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;

		GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
}
