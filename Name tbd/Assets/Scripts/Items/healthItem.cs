using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class healthItem : MonoBehaviour, IItem
{

    private int changeToHealth;

    /* Ablity
     * @param IPlayer
     * @return none
     * Calls the ability of the item
     */
    public void Ability(IPlayer player){

          changeHealth(player);
    }

    /* Duration
     * @param IPlayer
     * @return none
     * does nothing
     */
    public void Duration(IPlayer player){

    }

    /* changeHealth
     * @param IPlayer
     * @return none
     * Changes player's health stat
     */
    private void changeHealth(IPlayer player){

        changeToHealth = Random.Range(-5,5);
        while (changeToHealth == 0){
            changeToHealth = Random.Range(-5,5);
        }

        changeToHealth = changeToHealth*10;
		player.setHealth(player.getHealth() + changeToHealth);
    }
}
