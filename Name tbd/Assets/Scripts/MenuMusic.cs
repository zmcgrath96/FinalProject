using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuMusic : MonoBehaviour
{
  /** Awake
   * @param none
   * @return none
   * Allows only one instance of menu music to play
   */
    public void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MenuMusic");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
