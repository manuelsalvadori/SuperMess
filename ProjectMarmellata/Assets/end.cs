using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(aspe());
	}
	Vector3 pos = Vector3.zero;
	bool test = false;
	public float dy = 0.1f;
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.y > -28.6f && test)
		{
			pos = transform.position;
			pos.y -= dy;
			transform.position = pos;
		}
	}

	IEnumerator aspe()
	{
		yield return new WaitForSeconds(3);
		test = true;
	}
}
