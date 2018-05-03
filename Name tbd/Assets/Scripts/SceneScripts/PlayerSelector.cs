using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelector : MonoBehaviour {
	/* SelectGingy
	 * @param none
	 * @return none
	 * Selects gingy as the player
	 */
	public void SelectGingy()
    {
        GameVariables.CharacterName = "Gingy";
        Invoke("StartGame", .2f);
    }
		/* SelectShadowGingy
		 * @param none
		 * @return none
		 * Selects Shadow Gingy as the player
		 */
    public void SelectShadowGingy()
    {
        GameVariables.CharacterName = "ShadowGingy";
        Invoke("StartGame", .2f);
    }
		/* StartGame
		 * @param none
		 * @return none
		 * Starts the game
		 */
    private void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
