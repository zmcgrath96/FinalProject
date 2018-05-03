using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour, ICharacter
{
    //MuffinMan muffinMan;
    //Jack jack;

    public int Health = 100;
    int doOnce = 0;

    private Animator animator;
    public string enemyName;

    private Rigidbody2D myEnemy;

    void Start()
    {
        animator = GetComponent<Animator>();

        myEnemy = GetComponent<Rigidbody2D>();

        IEnemy[] scripts = this.GetComponents<IEnemy>();

        foreach (IEnemy ie in scripts)
        {
            Debug.Log(ie.GetType().Name);
            enemyName = ie.GetType().Name;
        }

        if (enemyName == "MuffinMan")
        {
            Health = 100;
        }
        else if (enemyName == "Jack")
        {
            Health = 200;
        }
    }

    /**
    * Does Damage to a player when it is struck by an enemy
    * @Param Damage Taken
    * @Return bool
    **/
    public void TakeDamage(int damageTaken)
    {
        if (isDead() == false)
        {
            if (enemyName == "MuffinMan")
            {
                animator.SetTrigger("MuffinMan_Hurt");
            }
            else if (enemyName == "Jack")
            {
                animator.SetTrigger("Jack_Hurt");
            }
            
            Health = Health - damageTaken;
        }
    }
    /**
    * Void
    * @Param None
    * @Return None
    **/
    public void Attack()
    {
    }
    /**
     * Void
     * @Param int Speed
     * @Return None
    **/
    public void setSpeed(int speed)
    {
    }

    /**
     * Void
     * @Param int Health
     * @Return None
    **/
    public void setHealth(int health)
    {
    }

    /**
     * Returns True if the player is dead and returns false if the player is 
     * not dead
     * @Param None
     * @Return Bool
    **/
    public bool isDead()
    {
        if (Health <= 0)
        {
            Die();
            return true;
        }
        else
        {
            return false;
        }
    }

    /**
    * Destroys the character when it dies
    * @Param None
    * @Return None
    **/
    public void Die()
    {
        if (doOnce == 0)
        {
            //Debug.Log("Now Dead");
            if (enemyName == "MuffinMan")
            {
                animator.SetTrigger("MuffinMan_Dead");
            }
            else if (enemyName == "Jack")
            {
                animator.SetTrigger("Jack_Dead");
            }
            doOnce = 1;
        }
        //Destroy (this.gameObject);
        Destroy(GetComponent<BoxCollider2D>());
        myEnemy.AddForce(-myEnemy.velocity);
    }


}
