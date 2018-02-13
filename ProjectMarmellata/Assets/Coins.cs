using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public AudioSource coin;
	void OnCollisionEnter2D(Collision2D other)
	{
		coin.Play();
		Destroy(transform.gameObject);
	}
}
