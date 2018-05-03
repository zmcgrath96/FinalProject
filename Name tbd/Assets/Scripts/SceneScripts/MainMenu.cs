using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject manual;
    /* Awake
     * @param none
     * @return none
     * Opens the main menu
     */
    public void Awake()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        Destroy(music);
        manual.SetActive(false);
    }
	/**
	 * Loads the scene to play the game
	 * @Param None
	 * @Return None
	**/
	public void PlayGame(){
		SceneManager.LoadScene ("InputName");
	}

	/**
	 * Quits the application
	 * @Param None
	 * @Return None
	**/
	public void QuitGame(){
		Application.Quit ();
	}

    /* TestMode
     * @param none
     * @return none
     * Allows the user to go into test mode of the game
     */
     public void TestMode()
    {
        SceneManager.LoadScene("TestMode");
    }
    /* ToManual
     * @param none
     * @return none
     * Allows the user to go into the manual
     */
    public void ToManual()
    {
        manual.SetActive(true);
    }
    /* BackHome
     * @param none
     * @return none
     * Allows the user to go back to the menu
     */
    public void BackHome()
    {
        manual.SetActive(false);
    }
}
