using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    /**
    * Determines the ability that the player recieves
    * @Param player
    * @Return None
    **/
	void Ability (IPlayer player);
    /**
    * Determines the duration of the ability
    * @Param player
    * @Return None
    **/
	void Duration(IPlayer player);

}

