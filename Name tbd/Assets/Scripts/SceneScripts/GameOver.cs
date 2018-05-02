using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private GameObject[] leaderboardText;
    private GameObject gameOverText;
    private List<string> vals;
    private List<string[]> stats;

    public void Awake()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        Destroy(music);


        leaderboardText = GameObject.FindGameObjectsWithTag("Leaderboard");
        gameOverText = GameObject.Find("GameOverText");

        gameOverText.SetActive(true);
        foreach(GameObject text in leaderboardText)
        {
            text.SetActive(false);
        }
        Invoke("ShowLeaderboard", 3f);
    }
        



    public void ShowLeaderboard()
    {
        gameOverText.SetActive(false);
        foreach(GameObject text in leaderboardText)
        {
            text.SetActive(true);
        }
        UpdateLeaderboard();
        SetLeaderboardText();
    }


    private void UpdateLeaderboard()
    {
        vals = SaveLoad.Load();                                                 // vals is a List<string> where each string is name,level,duration
        Debug.Log("Size of vals in UpdateLeaderboard: " + vals.Count);
        stats = new List<string[]>();

        foreach (string stat in vals) stats.Add(stat.Split(','));               // each stats is [name,level,duration]

        string[] tempPlayerString = new string[3];
        tempPlayerString[0] = GameVariables.PlayerName;
        tempPlayerString[1] = GameVariables.LevelReached.ToString();
        tempPlayerString[2] = GameVariables.LevelDuration.ToString();

        if (stats.Count > 0)
        {
            for (int i = 0; i < stats.Count; i++)                                      // Iterate through the array to see if the new level can/should be added to the array
            {
                if (i == stats.Count - 1)
                {
                    stats.Add(tempPlayerString);
                    break;
                }

                else if (GameVariables.LevelReached > int.Parse(stats[i][1]))
                {
                    stats.Insert(i, tempPlayerString);
                }

                else if (GameVariables.LevelReached == int.Parse(stats[i][1]))
                {
                    if (GameVariables.LevelDuration > System.Math.Round(System.Convert.ToDouble(stats[i][2]), 2))
                    {
                        stats.Insert(i, tempPlayerString);
                    }
                    else
                    {
                        stats.Insert(i + 1, tempPlayerString);
                    }

                    break;
                }
                
            }
        }
        else
            stats.Add(tempPlayerString);

        while (stats.Count > 10)
            stats.RemoveAt(stats.Count - 1);
        
    }


    private void SetLeaderboardText()
    {
        int rank = 1;
        foreach (string[] playerStat in stats)
        {
            GameObject.Find("PlayerText").GetComponent<Text>().text += rank.ToString() + "\t \t" + playerStat[0] + "\n";
            GameObject.Find("ScoreText").GetComponent<Text>().text += playerStat[1] + "\t \t \t" + System.Math.Round(System.Convert.ToDouble(playerStat[2]),2) + "\n";
            rank++;
        }
    }


    private void SaveLeaderboard()
    {
        while (vals.Count > 0)
            vals.RemoveAt(0);

        foreach (string[] toConvert in stats)
            vals.Add(toConvert[0]+","+toConvert[1]+","+toConvert[2]);

        SaveLoad.Save(vals);
    }

	/**
	 * Loads MainMenu
	 * @Param None
	 * @Return None
	**/
	public void toMainMenu(){
        SaveLeaderboard();
		SceneManager.LoadScene ("MainMenu");
	}

    public void QuitGame()
    {
        SaveLeaderboard();
        Application.Quit();
    }
		
}
