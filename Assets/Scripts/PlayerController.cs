using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public float jumpForce = 12f;
	public float runningSpeed = 5f;
	public Animator animator;

	private Vector3 startingPosition;
	private Rigidbody2D rigidBody;

	void Awake() {
		instance = this;
		rigidBody = GetComponent<Rigidbody2D>();
		startingPosition = this.transform.position;
	}
		
	public void StartGame() {
		animator.SetBool("isAlive", true);
		LevelGenerator.instance.GenerateInitialPieces ();
		this.transform.position = startingPosition;
	}
	
	void Update () {
		if (GameManager.instance.currentGameState == GameState.inGame) 
		{
			if (Input.GetMouseButtonDown(0)) {
				Jump();
			}
			animator.SetBool("isGrounded", IsGrounded());
		}
	}

	void FixedUpdate() {
		if (GameManager.instance.currentGameState == GameState.inGame) 
		{
			if (rigidBody.velocity.x < runningSpeed) {
				rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
			}
		}
	}

    // Player will jump with jumpForce variable if he is on the ground
	void Jump() {
		if (IsGrounded()) {
			rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public LayerMask groundLayer;

    // Checks if the player is touching the ground layer
	bool IsGrounded() {
		if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value)) {
			return true;
		}
		else {
			return false;
		}
	}
		

	public void Kill() {
		GameManager.instance.GameOver();
		animator.SetBool("isAlive", false);

        //check the highscore and save if it's more than the previous one
        if (PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance()) {
			PlayerPrefs.SetFloat("highscore", this.GetDistance());
		}
        rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);

    }


	public float GetDistance() {
        // Returns the distance between the current x position and the starting position
		float traveledDistance = Vector2.Distance(new Vector2(startingPosition.x, 0),
		                                          new Vector2(this.transform.position.x, 0));
		return traveledDistance;	                                                                               
	}


}
	