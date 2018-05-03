using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	public Button PauseButton;
    



	void start() {
		Button btn = PauseButton.GetComponent<Button> ();
		btn.onClick.AddListener (Pause);
	}

    /**
     * Resumes time in-game
     * @Param None
     * @Return None
    **/
	public void Resume() {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
    /**
     * Pauses time in-game
     * @Param None
     * @Return None
    **/
	public void Pause (){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
    /**
     * Makes sure to resume time when the main menu option is selected
     * @Param None
     * @Return None
    **/
	public void Menu(){
		Time.timeScale = 1f;
		Destroy(GameObject.Find("GameManager"));
		SceneManager.LoadScene ("MainMenu");
	}
	
   

	// Update is called once per frame
	void Update () {
	}
}
