using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    void Awake()
    {
        currentHealth = staringHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, staringHealth);

        if(currentHealth > 0)
        {
            anim.SetTrigger("Hurt");


        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Dead");

                if(GetComponent<CharacterMovement>() != null)
                    GetComponent<CharacterMovement>().enabled = false;

                //Enemy

                if(GetComponentInParent<EnemyPetrol>() != null)
                GetComponentInParent<EnemyPetrol>().enabled = false;

                if(GetComponent<MonsterEnemy>() != null)
                GetComponent<MonsterEnemy>().enabled = false;

                dead= true;
            }
           
        }
    }

    [SerializeField]
    private float staringHealth;
    public float currentHealth;
    private bool dead;

    private Animator anim;


}
