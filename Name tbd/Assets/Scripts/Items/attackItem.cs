using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attackItem : MonoBehaviour, IItem
{

    private float changeToAttack;
    private int durationLength;

    /* Ablity
     * @param IPlayer
     * @return none
     * Calls the ability of the item
     */
    public void Ability(IPlayer player){
        changeAttack(player);
        Duration(player);
    }

    /* Duration
     * @param IPlayer
     * @return none
     * Sets the duration of the ability
     */
    public void Duration(IPlayer player){
        durationLength = Random.Range(1,3);
        durationLength = durationLength * 10;
        player.setADuration(durationLength);
    }

    /* changeAttack
     * @param IPlayer
     * @return none
     * Changes player's attack stat
     */
    public void changeAttack(IPlayer player){
        changeToAttack = Random.Range(3,10);
        changeToAttack = changeToAttack/10;
		player.setAttack((int)(player.getAttack() * (1 + changeToAttack)));
    }
}
