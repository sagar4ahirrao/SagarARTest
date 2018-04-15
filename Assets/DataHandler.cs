using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataHandler : MonoBehaviour {
    string path;
    string jsonString;
    public Player p;
    public static DataHandler instance;
    int gameCount;
    private void Awake()
    {
        gameCount = PlayerPrefs.GetInt("gameStarted");

        instance = this;
        Debug.Log("gamecount:> " + gameCount+ ">  " + PlayerPrefs.GetInt("gameStarted"));
        
    }
    void Start () {
        if (PlayerPrefs.GetInt("gameStarted") == 0)
        {
            gameCount++;
            PlayerPrefs.SetInt("gameStarted", gameCount);
        }
        else
        {
            PlayerPrefs.SetInt("gameStarted", PlayerPrefs.GetInt("gameStarted")+1);
        }


        path = Application.streamingAssetsPath + "/data.json";
        jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);
        p = JsonUtility.FromJson<Player>(jsonString);
        if (PlayerPrefs.GetInt("gameStarted") == 0) {
            p.highScore = 0;
        }
       string jsonutil = JsonUtility.ToJson(p);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int GetHighScore() {
        return p.highScore;
    }
    public void UpdateScore(int Score) {
        p.score = Score;
        if (p.highScore < Score) {
            p.highScore = Score;
        }
        string newp = JsonUtility.ToJson(p);
        File.WriteAllText(path, newp);
    }
}

[System.Serializable]
public class Player {
    public int score;
    public int highScore;
}