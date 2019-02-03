using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState {
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;

	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;

	public int collectedCoins = 0;

	void Awake() {
		instance = this;
	}

	void Start() {
		currentGameState = GameState.menu;
	}
	
	public void StartGame() {
		PlayerController.instance.StartGame();
		SetGameState(GameState.inGame);
	}
	
	public void GameOver() {
		SetGameState(GameState.gameOver);
	}

	public void Restart(){
        SceneManager.LoadScene (0);
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }

	// Called when the player goes back to the menu
	public void BackToMenu() {
		SetGameState(GameState.menu);
	}

    // Changes the menu views depending on the player state
	void SetGameState (GameState newGameState) {		
		if (newGameState == GameState.menu) {
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
		}
		else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
		}
		else if (newGameState == GameState.gameOver) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
        }
		
		currentGameState = newGameState;
	}


	public void CollectedCoin() {
		collectedCoins ++;
	}

}



