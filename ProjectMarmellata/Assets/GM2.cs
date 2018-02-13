using UnityEngine;
using System.Collections;

public class GM2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public static GM2 gm;
	public Transform spawnPoint, playerPrefab;
	public AudioSource deadA;
	void Awake()
	{
		if (gm == null)
		{
			gm = GameObject.FindGameObjectWithTag("GM2").GetComponent<GM2>();
		}
	}

	public static void KillPlayer2(Player2 player)
	{
				
		Destroy(player.gameObject);
		gm.StartCoroutine(gm.Respawn());
	
	}

	public IEnumerator Respawn ()
	{
		deadA.Play();
		yield return new WaitForSeconds(2.925f);
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
