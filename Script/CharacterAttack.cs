using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;
    private Animator anim;
    private CharacterMovement playermovement;
    private float cooldownTimer = Mathf.Infinity;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        playermovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCoolDown && playermovement.CanAttack())
        {
            Attack();
            
            cooldownTimer += Time.deltaTime;
        }
    }

    //Player Attack
    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireBalls[0].transform.position = firePoint.position;
        fireBalls[0].GetComponent<ProjectTile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for(int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
     
}
