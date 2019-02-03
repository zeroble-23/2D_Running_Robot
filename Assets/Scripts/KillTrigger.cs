using UnityEngine;
using System.Collections;

public class KillTrigger : MonoBehaviour {

    // Checks for collisions with kill trigger colliders and kills the player on contact 
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			PlayerController.instance.Kill();
		}
	}
}
