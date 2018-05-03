using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ITestEventSystem : IEventSystemHandler
{

    /* StartTest
    * @param none
    * @return none
    * Use of the eventsystemhandler to message start test
    */
    void StartTest();


    /* EndTest
    * @param none
    * @return none
    * Use of the eventsystemhandler to message end test
    */
    void EndTest();
}

