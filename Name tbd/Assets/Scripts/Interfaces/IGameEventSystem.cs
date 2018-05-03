using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IGameEventSystem : IEventSystemHandler {

    /* LevelOver
    * @param none
    * @return none
    * Use of the eventsystemhandler to message level over
    */
    void LevelOver();


    /* GameOver
    * @param none
    * @return none
    * Use of the eventsystemhandler to message game over
    */
    void GameOver();
}
