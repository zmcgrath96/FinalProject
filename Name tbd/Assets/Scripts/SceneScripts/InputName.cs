using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour {

	/** SubmitName
	 * @param none
   * @return none
	 * Submits the user's name
	 */
	public void SubmitName()
    {
        GameVariables.PlayerName = GameObject.FindGameObjectWithTag("NameInput").GetComponent<InputField>().text;
        SceneManager.LoadScene("PlayerSelector");
    }
}
