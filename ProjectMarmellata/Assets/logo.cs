using UnityEngine;
using System.Collections;

public class logo : MonoBehaviour {

	void Awake()
	{
		this.StartCoroutine(menu());
	}
	public GameObject canvas;
	void Update()
	{
		if(Camera.main.transform.position.y > 0 && test)
		{
			Vector3 vec = Camera.main.transform.position;
			vec.y -= 0.1f;
			Camera.main.transform.position = vec;
		}
		if (Camera.main.transform.position.y <= 0 && test2)
		{
			Application.LoadLevel("Start");
			test2 = false;
		}
	}
	bool test = false, test2 = true;
	IEnumerator menu()
	{
		yield return new WaitForSeconds(2);
		test = true;

	}
}
