using UnityEngine;
using System.Collections;

public class Hime : MonoBehaviour {
	
	public float min = 1f, max = 5f;
	public float speed = 0.05f;
	bool up = true, isStopped = false;
	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (!isStopped)
		{
			anim.SetBool("hit", false);
			if (transform.position.x <= 4.1f && transform.position.x >= 3.9f)
			{
				isStopped = true;
				StartCoroutine(riprendi());
			}
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
		else
		{
			anim.SetBool("hit", true);
		}
		
	}

	IEnumerator riprendi()
	{
		yield return new WaitForSeconds(0.2f);
		isStopped = false;
	}
}
