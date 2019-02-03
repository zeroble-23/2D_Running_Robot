using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour {
    
    public Text scoreLabel;
    public Text coinLabel;

    // Displays the score and coins collected when the player is killed
    void Update() {
        if (GameManager.instance.currentGameState == GameState.gameOver) {
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            coinLabel.text = GameManager.instance.collectedCoins.ToString();
        }
    }
}
