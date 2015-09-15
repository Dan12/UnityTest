using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position-GameManager.instance.getGameSpeed();

		if (transform.position.z + transform.localScale.z < GameManager.instance.getZClip ()) {

			Destroy (gameObject);
		}
	}
}
