﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece>();
	
	void Awake() {
		instance = this;
	}

	void Start() {
		GenerateInitialPieces();
	}

    // Creates two level pieces when the game starts
	public void GenerateInitialPieces() {
		for (int i=0; i<2; i++) {
			AddPiece();
		}
	}
	
	public void AddPiece() {

		// Picks a random number for the level piece prefab array
		int randomIndex = Random.Range(0, levelPrefabs.Count);

		// Instantiate a random copy of a level prefab and stores it in piece variable
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
		piece.transform.SetParent(this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		if (pieces.Count == 0) {
			spawnPosition = levelStartPoint.position;
		}
		else {
			// Takes exit point from last piece as a spawn point for the new piece
			spawnPosition = pieces[pieces.Count-1].exitPoint.position;
		}
		
		piece.transform.position = spawnPosition;
		pieces.Add(piece);
	}



    // Removes level pieces as the player progresses to the right
	public void RemoveOldestPiece() {		
		LevelPiece oldestPiece = pieces[0];
		
		pieces.Remove(oldestPiece);
		Destroy(oldestPiece.gameObject);
	}

}
