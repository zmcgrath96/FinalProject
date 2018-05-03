using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter{

	void TakeDamage (int damageTaken);

	void Attack ();
	
	void setSpeed (int speed);

	void setHealth(int health);

	bool isDead ();

<<<<<<< HEAD
    /**
     * Destroys the characted when it dies
    * @Param None
    * @Return None
    **/
=======
	/* Set of actions when the player dies
	 * @param none
	 * @return none
	 */
>>>>>>> 64bd956d414a0125c776032427f41857266730ad
	void Die ();

}
