using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gingy : IPlayer
{
	//public int Health = 100;


    /** GetHealth
    * @param none
    * @return int
    * returns health
    */
    public int GetHealth()
    {
        return Health;
    }

    /** SetHealth
    * @param int
    * @return none
    * Sets the health
    */
    public void SetHealth(int value)
    {
        Health = value;
    }
}
