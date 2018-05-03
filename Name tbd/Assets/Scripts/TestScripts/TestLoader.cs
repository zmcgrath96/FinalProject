using UnityEngine;
using System.Collections;


public class TestLoader : MonoBehaviour
{
    public TestManager testManager;          //TestManager prefab to instantiate.
    /** Awake
       * @param none
       * @return none
       * Loads the test mode
       */
    void Awake()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        //if (!(GameObject.Find("GameManager")))
        //{
        //    Instantiate(gameManager);
        //}

        testManager = GetComponent<TestManager>();
    }
}
