using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IPlayer: MonoBehaviour, ICharacter, IEventSystemHandler
{
	public static int Health;
    public bool Invinc;
    public int InvincDur;
    public int Icount;
    public int Attak;
    public int AttakDur;
    public int Acount;
	public int maxHealth = 100;

    private Animator animator;
    public string playerName;

    private GameObject myPlayer;
    private GameObject invincImage;
    private Text invincText;
    private GameObject AttackBonusImage;
    private Text AttackBonusText;


    public void Start()
	{
        animator = GetComponent<Animator>();
        setHealth(100);
        setAttack(10);
        setInvincibility(false);
        setADuration(0);
        setIDuration(0);
        Icount = 0;
        Acount = 0;
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        
        Debug.Log(myPlayer.name);
        playerName = myPlayer.name;

    }
    /**
     * Takes Damage given to the character
     * @Param int damageTaken
     * @Return None
    **/
	public void TakeDamage (int damageTaken)
    {
        if (!Invinc)
        {
            if (playerName == "Gingy(Clone)")
            {
                animator.SetTrigger("Player1_Hurt");
            }
            else if (playerName == "ShadowGingy(Clone)")
            {
                animator.SetTrigger("Player2_Hurt");
            }

            //animator.SetTrigger("Player1_Hurt");
            Health = Health - damageTaken;
			HealthBarScript.health -= damageTaken;
            Debug.Log("My Health:"+Health);
            if (isDead())
            {
                Die();
            }
        }
        else { Debug.Log("My Health:"+Health); }
	}

    /**
     * When the player attacks it determines if there is an enemy to do 
     * damage to or not
     * @Param None
     * @Return None
    **/
	public void Attack()
	{
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
		int i = 0;
		while (i < hitColliders.Length)
		{
			if (hitColliders [i].tag == "Enemy") {
				
				hitColliders [i].GetComponent<IEnemy> ().TakeDamage(Attak);
				Debug.Log(hitColliders [i].GetComponent<IEnemy> ().Health);
			} 
			i++;

		}
	}
    /**
     * Shows text when the player picks up invincibility power up
     * @Param None
     * @Return None
    **/
    void ShowInvinc()
    {
        invincImage = GameObject.Find("InvincibilityImage");
        invincText = GameObject.Find("InvincibilityText").GetComponent<Text>();
        invincText.text = "Invincible!";
    }
    /**
     * Hides the text that shows when you pick up invincibility
     * @Param None
     * @Return None
    **/
    void HideInvinc()
    {
        invincImage.SetActive(false);
    }
    /**
      * Shows text when the player picks up attack power up
      * @Param None
      * @Return None
     **/
    void ShowAttackBonus()
    {
        AttackBonusImage = GameObject.Find("AttackBonusImage");
        AttackBonusText = GameObject.Find("AttackBonusText").GetComponent<Text>();
        AttackBonusText.text = "Attack Bonus!";
    }
    /**
     * Hides the text that shows when you pick up attack power up
     * @Param None
     * @Return None
    **/
    void HideAttackBonus()
    {
        AttackBonusImage.SetActive(false);
    }
    /**
     * void
     * @Param int speed
     * @Return None
    **/
    public void setSpeed (int speed)
    {
	}

    /**
     * Sets the health for the player
     * @Param int health
     * @Return None
    **/
	public void setHealth(int health)
    {
		HealthBarScript.health = health;
        Health = health;
	}

    /**
     * Gets the health of the player
     * @Param None
     * @Return Health
    **/
    public int getHealth()
    {
        return Health;
    }


    /**
     * sets attack of the player
     * @Param int
     * @Return none
    **/
    public void setAttack(int attack)
    {
        Attak = attack;
        Debug.Log("Attack:"+Attak);
        if(Attak > 20)
        {
            ShowAttackBonus();
        }
        else
        {
            HideAttackBonus();
        }
    }


/**
     * returns the attack of the player
     * @Param None
     * @Return Health
    **/
    public int getAttack()
    {
        return Attak;
    }



    /**
     * setInvincibility
     * @Param bool
     * @Return none
    **/
    public void setInvincibility(bool invinc)
    {
        Invinc = invinc;
        Debug.Log("Invincible:"+ Invinc);
        if (Invinc)
        {
            ShowInvinc();
        }
        else
        {
            HideInvinc();
        }
    }


    /**
     * sets the duration of the item picked up
     * @Param int
     * @Return none
    **/
    public void setIDuration(int dur)
    {
        InvincDur = (dur*50);
        Debug.Log("Invincibility Duration:" + InvincDur);
    }


    /**
     * gets the duration of the item 
     * @Param none
     * @Return int
    **/
    public int getIDuration()
    {
        return InvincDur;
    }


    /**
     * sets duration of the attack item
     * @Param int
     * @Return none
    **/
    public void setADuration(int dur)
    {
        AttakDur = (dur*50);
        Debug.Log("Attack Duration:" + AttakDur);
    }


    /**
     * Gets the attack item duration
     * @Param None
     * @Return int
    **/
    public int getADuration()
    {
        return AttakDur;
    }


    /**
     * sees if the player is dead
     * @Param None
     * @Return bool
    **/
    public bool isDead ()
    {
		if (Health <= 0)
        {
			return true;
		}
        else
        {
			return  false;
		}
	}


    /**
     * Performs functions when player dies
     * @Param None
     * @Return none
    **/
	public void Die ()
    {
        if (playerName == "Gingy(Clone)")
        {
            animator.Play("Player1_Dead", 0, 0.9f);
        }
        else if (playerName == "ShadowGingy(Clone)")
        {
            animator.Play("Player1_Dead", 0, 0.9f);
        }

        if (GameObject.Find("GameManager"))
            ExecuteEvents.Execute<IGameEventSystem>(GameObject.Find("GameManager"), null, (x, y) => x.GameOver());
        else
            ExecuteEvents.Execute<ITestEventSystem>(GameObject.Find("TestManager"), null, (x, y) => x.EndTest());
        
    }


    /**
     * Gets the collider touching the player for item interaction
     * @Param Collider2D
     * @Return none
    **/
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<IItem>().Ability(this);
            
        }
    }


    /**
     * Called every .02 sec
     * @Param None
     * @Return none
    **/
    void FixedUpdate()
    {


        if (getIDuration() > 0)
        {
            if (Icount <= getIDuration())
            {
                Icount = Icount + 1;
            }
            else
            {
                setInvincibility(false);
                setIDuration(0);
                Icount = 0;
            }
        }
        if (getADuration() > 0)
        {
            if (Acount <= getADuration())
            {
                Acount = Acount + 1;
            }
            else
            {
                setAttack(20);
                setADuration(0);
                Acount = 0;
            }
        }
    }
}

