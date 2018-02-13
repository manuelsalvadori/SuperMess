using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int sogliaMorte = -20;

	// Use this for initialization
	void Start () {
		spawnNew = GameObject.FindGameObjectWithTag("spawn");
	}
	bool test = true, spat = true, spat2 = true;
	GameObject spawnNew;

	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x >= 245f && spat)
		{
			Vector3 pos = spawnNew.transform.position;
			pos.x = 245f;
			pos.y = 4f;
			spawnNew.transform.position = pos;
			spat = false;
		}
		if(transform.position.x >= 144.8f && spat2)
		{
			Vector3 pos = spawnNew.transform.position;
			pos.x = 144.8f;
			spawnNew.transform.position = pos;
			spat2 = false;
		}
		if(transform.position.y < sogliaMorte)
		{
			GameMaster.KillPlayer(this);
		}
		Transform scri = transform.FindChild("wtf(Clone)");
		if(scri == null)
		{
			scri = transform.FindChild("swag(Clone)");
			if(scri == null)
			{
				scri = transform.FindChild("lol(Clone)");
			}
		}
		else
		{
			if(GameObject.Find("maryel_18") == null && test)
			{
				StartCoroutine(swag());
				test = false;
			}
		}

		if (scri != null)
		{
			GameObject scritte = scri.gameObject;
			Vector3 scale = scritte.transform.localScale;
			scale.x = transform.localScale.x;
			scritte.transform.localScale = scale;
		}

	}
	IEnumerator swag()
	{
		Vector3 zeri = GameObject.Find("swag").transform.position;
		zeri.z = 0;
		GameObject.Find("swag").transform.position = zeri;
		
		yield return new WaitForSeconds(6f);
		Destroy(GameObject.Find("swag"));
	}

	public AudioSource puA;
	public AudioSource enemyA;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			GameMaster.KillPlayer(this);
		}
		if (other.gameObject.tag == "Head")
		{
			Destroy(other.gameObject);
			enemyA.Play();

		}

		if (other.gameObject.tag == "Giallo")
		{
			Destroy (other.gameObject);
			GameMaster.SpeedUp();
			puA.Play();
		}

		if (other.gameObject.tag == "Blu")
		{
			Destroy (other.gameObject);
			GameMaster.SmallDown();
			puA.Play();
		}

		if (other.gameObject.tag == "Viola")
		{
			Destroy (other.gameObject);
			GameMaster.WTF();
			puA.Play();
		}
		if (other.gameObject.tag == "Exit")
		{
			Destroy (other.gameObject);
			GameMaster.Exit();
		}
	}

}
