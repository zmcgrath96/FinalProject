using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

	Image HealthBar;
	int maxHealth = 100;
	public static float health;

	/* Start
			 * @param none
			 * @return none
			 * Initializes the health bar
			 */
	void Start () {
		HealthBar = GetComponent<Image> ();
		health = IPlayer.Health;
	}

	/* Update
			 * @param none
			 * @return none
			 * Updates the health bar
			 */
	void Update () {
		HealthBar.fillAmount = health / maxHealth;
	}
}
