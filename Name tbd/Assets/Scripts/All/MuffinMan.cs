using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffinMan : IEnemy
{
    //public int Health;

    private Animator animator;
    private Vector3 delta;
    public Vector3 current;
    public Vector3 target;
    private bool letMove;

    int doOnce = 0;


    /** Start
    * @param none
    * @return none
    * Called on start of muffinMan
    */
    void Start()
    {
        animator = GetComponent<Animator>();
        letMove = false;
    }


    /** SetMove
    * @param bool
    * @return none
    * sets value of letMove
    */
    public void SetMove(bool value)
    {
        letMove = value;
    }


    /** GetMove
    * @param none
    * @return bool
    * returns letMove
    */
    bool GetMove()
    {
        return letMove;
    }


    /** FixedUpdate
    * @param none
    * @return none
    * Called every .02s
    */
    public void FixedUpdate()
    {
        current = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform.position;

        delta = target - this.transform.position;

        if (letMove == false)
        {
            animator.Play("MuffinManIdle");
        }
        else if (GetComponent<IEnemy>().Health <= 0)
        {
            if (doOnce < 33)
            {
                //Debug.Log("Dead: " + doOnce);
                //animator.Play("MuffinMan_Dead");
                //animation["MuffinMan_Dead"].wrapMode = WrapMode.Once;
                doOnce++;
            }
            else
            {
                animator.Play("MuffinMan_Dead", 0, 0.9f);
            }

        }
        ////// Movement Animations //////
        else if ((current.x > (target.x + 0.4f)) && (Math.Abs(delta.x) > Math.Abs(delta.y)))
        {
            animator.SetTrigger("MuffinManLeft");
        }
        else if ((current.x < (target.x - 0.4f)) && (Math.Abs(delta.x) > Math.Abs(delta.y)))
        {
            animator.SetTrigger("MuffinManRight");
        }
        else if ((current.y < (target.y - 0.5f)) && (Math.Abs(delta.x) < Math.Abs(delta.y)))
        {
            animator.SetTrigger("MuffinManUp");
        }
        else if ((current.y > (target.y + 0.5f)) && (Math.Abs(delta.x) < Math.Abs(delta.y)))
        {
            animator.SetTrigger("MuffinManDown");
        }
    }


    /** TakeDamage
    * @param int
    * @return none
    * Reduces health of character
    */
    public void TakeDamage(int damageTaken)
    {
        animator.SetTrigger("MuffinMan_Hurt");
        Health = Health - damageTaken;
    }


    /** Attack
    * @param none
    * @return none
    * Uses attack animation of this character
    */
    public void Attack()
    {
        /// Attack Left ////
        if ((current.x > target.x) & (Math.Abs(delta.x) > Math.Abs(delta.y)))
        {
            animator.SetTrigger("MuffinManAttack_Left");
        }
        //// Attack Right ////
        else if ((current.x < target.x) & (Math.Abs(delta.x) > Math.Abs(delta.y)))
        {
            animator.SetTrigger("MuffinManAttack_Right");
        }
        /// Attack Up ////
        else if (current.y < target.y)
        {
            animator.SetTrigger("MuffinManAttack_Up");
        }
        /// Attack Down ////
        else if (current.y > target.y)
        {
            animator.SetTrigger("MuffinManAttack_Down");
        }
    }


    /** setSpeed
    * @param int
    * @return none
    * void
    */
    public void setSpeed(int speed)
    {
    }


    /** setHealth
    * @param int
    * @return none
    * void
    */
    public void setHealth(int health)
    {
    }


    /** isDead
    * @param none
    * @return bool
    * void
    */
    public bool isDead()
    {
        if (Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
