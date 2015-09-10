using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float rotMult = 1f;

	private float rotSpeed = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rotSpeed = GameManager.instance.getGameSpeed().z * rotMult;
		transform.Rotate (rotSpeed, 0f, 0f);
	}
}
