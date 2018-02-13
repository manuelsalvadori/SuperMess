using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	
	public AudioSource puA;

	void Awake()
	{
		Debug.Log("awakeeeeeeeeeeee");
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		puA.Play();
	}
}
