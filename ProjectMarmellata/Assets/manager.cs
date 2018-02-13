using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {

	public AudioSource startA;

	public void StartLevel()
	{
		StartCoroutine(StartL());
	}
	public IEnumerator StartL()
	{
		startA.Play();
		yield return new WaitForSeconds(0.945f);
		Application.LoadLevel("Scena1");
	}
}
