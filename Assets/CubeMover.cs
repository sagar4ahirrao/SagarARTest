using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class CubeMover : MonoBehaviour {
    public Transform startPos;
    public Text scoreText;
    private int score;

	void Start () {
        scoreText.text = "";
        score = 0;
        DataHandler.instance.UpdateScore(score);
    }

    void Update () {
        transform.Translate(CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 2, 0.0f, CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Destroy") {
            int highscore = DataHandler.instance.GetHighScore();
            transform.position = startPos.position;
            score += 1;
            scoreText.text = "Score: " + score + "\n HighScore: " + highscore;
            DataHandler.instance.UpdateScore(score);
        }
    }
}
