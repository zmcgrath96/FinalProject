using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables {

    private static string characterName;
    private static int levelReached;
    private static double levelDuration;
    private static string playerName;


    /* CharacterName
    * @param none
    * @return none
    * Allows for public access to private variable characterName 
    */
    public static string CharacterName
    {
        get
        {
            return characterName;
        }
        set
        {
            characterName = value;
        }
    }


    /* LevelReached
    * @param none
    * @return none
    * Allows for public access to private variable levelReached
    */
    public static int LevelReached
    {
        get
        {
            return levelReached;
        }
        set
        {
            levelReached = value;
        }
    }


    /* LevelDuration
    * @param none
    * @return none
    * Allows for public access to private variable LevelDuration
    */
    public static double LevelDuration
    {
        get
        {
            return levelDuration;
        }
        set
        {
            levelDuration = value;
        }
    }



    /* PlayerName
    * @param none
    * @return none
    * Allows for public access to private variable playerName
    */
    public static string PlayerName
    {
        get
        {
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

}
