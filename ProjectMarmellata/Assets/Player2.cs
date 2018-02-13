using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {
	
	public int sogliaMorte = -20;
	int vita = 3;
	Animator anim;
	public AudioSource hitA;
	// Use this for initialization
	void Awake ()
	{
		anim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(transform.position.y < sogliaMorte)
		{
			GM2.KillPlayer2(this);
		}
	}
	public Transform winwin, spawnPoint;
	bool fine = false;
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			GM2.KillPlayer2(this);
		}
		if (other.gameObject.tag == "Head" && !fine)
		{
			hitA.Play();
			anim.SetBool("hitted",true);
			vita --;
			switch (vita)
			{
			case 2 : Destroy(GameObject.Find("vite2")); break;
			case 1 : Destroy(GameObject.Find("vite1")); break;
			case 0 : Destroy (GameObject.Find("vite")); break;
			}
			if(vita > 0)
			{
				StartCoroutine(waita());
				Debug.Log("waita()");
			}
			else
			{
				Destroy(other.gameObject);
				GameObject pls = GameObject.Find("peachPLS");
				Vector3 ppls = pls.transform.position;
				ppls.z = 0;
				pls.transform.position = ppls;
				GameObject audio = GameObject.Find("bosssaudio");
				Destroy (audio);
				fine = true;
				Instantiate (winwin.gameObject, spawnPoint.position, spawnPoint.rotation);
				StartCoroutine(freeMario());
			}
			
		}
	}

	IEnumerator freeMario()
	{
		yield return new WaitForSeconds(6);
		Destroy(GameObject.Find("gabbiamario").GetComponent<BoxCollider2D>());
		yield return new WaitForSeconds(4);
		Application.LoadLevel("credits");

	}

	IEnumerator waita()
	{
		yield return new WaitForSeconds(1);
		if(anim != null)
		{
			anim.SetBool("hitted",false);
		}

	}
	
}