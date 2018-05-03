using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMusic : MonoBehaviour
{
	/** Awake
	 * @param none
	 * @return none
	 * Stops the menu music and starts the game music
	 * Also only allows one instance of game music to play
	 */
	public void Awake()
	{
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        GameObject foo = GameObject.FindGameObjectWithTag("MenuMusic");
            Destroy(foo);

	}
}
