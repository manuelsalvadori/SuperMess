using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float min = 1f, max = 5f;
	public float speed = 0.05f;
	bool up = true;

	void Awake()
	{
		//GetComponent<Animation>().Play("YoshiWalk");
	}

	// Update is called once per frame
	void Update ()
	{

		if(transform.position.x >= max)
		{
			up = false;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
		if(transform.position.x <= min)
		{
			up = true;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
		
		if(up)
		{
			transform.position = new Vector3 (transform.position.x + speed, transform.position.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
		}

		
	}


}
