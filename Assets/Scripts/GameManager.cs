using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public GameObject platform;
	public float currentSpeed = 5f;
	public float acceleration = 0.1f;
	public int platformView = 10;

	public static GameManager instance = null;

	private Vector3 gameSpeed;
	private GameObject[] platforms;
	private bool gameStarted = false;
	
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		SetupGame ();
	}

	private void SetupGame(){
		gameSpeed = new Vector3 (0f,0f,0f);
		
		Instantiate (player, transform.position+(new Vector3(0f,1f,0f)), Quaternion.identity);

		for (int i = 0; i < platformView; i++) {
			Instantiate (platform, transform.position + (new Vector3 (0f, -0.5f, 7f+4*i)), Quaternion.identity);
		}

		platforms = new GameObject[10];
	}

	public Vector3 getGameSpeed(){
		return gameSpeed;
	}

	void Update(){
		if (Input.GetButtonDown ("Fire1") && !gameStarted) {
			gameStarted = true;
			gameSpeed.z = 0.1f;
		}

		if (gameStarted) {
			if(gameSpeed.z < currentSpeed)
				gameSpeed.z = gameSpeed.z*(1f+acceleration);
			if(gameSpeed.z > currentSpeed)
				gameSpeed.z = currentSpeed;
		}

		print (gameSpeed);
	}
}
