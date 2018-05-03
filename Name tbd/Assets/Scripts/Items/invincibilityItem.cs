using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class invincibilityItem : MonoBehaviour, IItem
{

    private int durationLength;
    /* Ablity
     * @param IPlayer
     * @return none
     * Calls the ability of the item
     */
    public void Ability(IPlayer player){
        changeInviciblity(player);
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
        player.setIDuration(durationLength);
    }
    /* changeInviciblity
     * @param IPlayer
     * @return none
     * Changes player's invincibility to true
     */
    private void changeInviciblity(IPlayer player){
        player.setInvincibility(true);
    }
}
