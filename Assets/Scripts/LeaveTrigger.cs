using UnityEngine;
using System.Collections;

public class LeaveTrigger : MonoBehaviour {

    // Trigger for creating and removing level pieces
	void OnTriggerEnter2D(Collider2D other) {
		LevelGenerator.instance.AddPiece();
		LevelGenerator.instance.RemoveOldestPiece();
	}
	
}
