using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class PiattaformeVerticale : MonoBehaviour {

	public float min = 1f, max = 5f;
	public float speed = 0.05f;
	bool up = true, parented = false;
	GameObject player;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if(player == null)
		{
			Debug.LogError("WTF??");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{


		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if(transform.position.y >= max)
		{
			up = false;
		}
		if(transform.position.y <= min)
		{
			up = true;
		}

		if(up)
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
		}
		else
		{
			transform.position = new Vector3 (transform.position.x, transform.position.y - speed, transform.position.z);
		}
		if((CrossPlatformInputManager.GetButtonDown("Jump")) && parented)
		{
			player.transform.parent = null;
		}

	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject == player)
		{
			player.transform.parent = this.transform;
			parented = true;
		}
	}
}
