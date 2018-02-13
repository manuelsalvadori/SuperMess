using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public int life = 3;

	public static GameMaster gm;

	// Use this for initialization
	void Start ()
	{
		if (gm == null)
		{
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		}
		gm.StartCoroutine(gm.suona());
	}
	public Transform themeprefab, jazzMario, elettroMario, victory, solid;
	GameObject  instantiatedObj;

	void Awake()
	{


	}
	
	// Update is called once per frame
	void Update () {

	}

	public Transform playerPrefab;
	public Transform deathPrefab;
	public Transform metalMario;

	public Transform spawnPoint;
	public int spawnDelay = 2;

	public IEnumerator RespawnPlayer ()
	{
		Destroy (instantiatedObj);
		Instantiate (deathPrefab, spawnPoint.position, spawnPoint.rotation);
		gm.StartCoroutine(gm.suona());

		yield return new WaitForSeconds(2.925f);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	IEnumerator suona()
	{
		yield return new WaitForSeconds(2.325f);
		instantiatedObj = (GameObject) Instantiate (themeprefab.gameObject, spawnPoint.position, spawnPoint.rotation);
	}

	public static void KillPlayer(Player player)
	{

		Destroy(player.gameObject);
		gm.StartCoroutine(gm.RespawnPlayer());
	}

	public static void SpeedUp()
	{
		gm.StartCoroutine (gm.SpeedUp1());


	}
	public Transform wtfPrefab, lolPrefab, swagPrefab;

	public IEnumerator SpeedUp1()
	{
		Enemy playerScript = null;
		GameObject thePlayer = GameObject.Find("maryel_18");
		if(thePlayer != null)
		{
			playerScript = thePlayer.GetComponent<Enemy>();
			playerScript.speed = 0.5f;
		}
		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (metalMario.gameObject, spawnPoint.position, spawnPoint.rotation);
		GameObject back = GameObject.Find("BackgroundPU1");
		Vector3 zeta = back.transform.position;
		zeta.z = 6;
		back.transform.position = zeta;
		GameObject wtf = Instantiate(wtfPrefab.gameObject);
		wtf.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
		wtf.transform.localPosition = new Vector3(0,1.5f,0);

		yield return new WaitForSeconds(10f);
		Destroy (wtf);

		if(thePlayer != null)
			playerScript.speed = 0.05f;

		zeta.z = 10;
		back.transform.position = zeta;

		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (themeprefab.gameObject, spawnPoint.position, spawnPoint.rotation);

	}

	public static void SmallDown()
	{
		gm.StartCoroutine (gm.SmallDown1());
	}

	public IEnumerator SmallDown1()
	{
		Vector3 scale1 = Vector3.zero, scale2 = Vector3.zero;
		GameObject l1 = GameObject.Find("Luigi");
		GameObject l2 = GameObject.Find("Luigi1");
		if(l1 != null)
		{
			scale1 = l1.transform.localScale;
			scale1.x = 0.4f;
			scale1.y = 0.4f;
			l1.transform.localScale = scale1;
		}
		if(l2 != null)
		{
			scale2 = l2.transform.localScale;
			scale2.x = 0.4f;
			scale2.y = 0.4f;
			l2.transform.localScale = scale2;
		}
		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (jazzMario.gameObject, spawnPoint.position, spawnPoint.rotation);
		GameObject back = GameObject.Find("BackgroundPU2");
		Vector3 zeta = back.transform.position;
		zeta.z = 5;
		back.transform.position = zeta;
		GameObject lol = Instantiate(lolPrefab.gameObject);
		lol.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
		lol.transform.localPosition = new Vector3(0,1.5f,0);

		yield return new WaitForSeconds(10f);
		Destroy(lol);

		zeta.z = 10;
		back.transform.position = zeta;


		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (themeprefab.gameObject, spawnPoint.position, spawnPoint.rotation);

		scale1.x = 1f;
		scale1.y = 1f;
		if (l1 != null)
			l1.transform.localScale = scale1;
		scale2.x = 1f;
		scale2.y = 1f;
		if(l2 != null)
			l2.transform.localScale = scale2;

	}

	public static void WTF()
	{
		gm.StartCoroutine (gm.WTF1());

	}

	public IEnumerator WTF1()
	{
		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (elettroMario.gameObject, spawnPoint.position, spawnPoint.rotation);
		GameObject back = GameObject.Find("BackgroundPU3");
		GameObject dot = GameObject.Find("PuntoD");
		Vector3 zeta = back.transform.position;
		zeta.z = 5;
		back.transform.position = zeta;
		Vector3 zeta1 = dot.transform.position;
		zeta1.z = -1;
		dot.transform.position = zeta1;
		
		yield return new WaitForSeconds(46.2f);
		
		zeta.z = 10;
		back.transform.position = zeta;
		
		
		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (themeprefab.gameObject, spawnPoint.position, spawnPoint.rotation);

	}

	public static void Exit()
	{
		gm.StartCoroutine(gm.Exit1());
	}

	public IEnumerator Exit1()
	{
		Destroy (instantiatedObj);
		instantiatedObj = (GameObject) Instantiate (victory.gameObject, spawnPoint.position, spawnPoint.rotation);
		GameObject solido = (GameObject) Instantiate (solid.gameObject, spawnPoint.position, spawnPoint.rotation);
		Vector3 s = solido.transform.position;
		s.x = 335;
		s.y = 3;
		s.z = 0;
		solido.transform.position = s;
		yield return new WaitForSeconds(8f);
		Application.LoadLevel("Main");
	}
}
