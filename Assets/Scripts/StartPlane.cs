using UnityEngine;
using System.Collections;

public class StartPlane : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position-GameManager.instance.getGameSpeed();
	}
}
