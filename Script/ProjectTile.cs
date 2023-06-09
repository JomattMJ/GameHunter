using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;

    private Animator anim;
    private BoxCollider2D boColider;


    void Awake()
    {
        boColider= GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime ;
        transform.Translate(movementSpeed, 0 , 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit= true;
        boColider.enabled = false;

        if (collision.tag == "Enemy")
            collision.GetComponent<HealthBar>().TakeDamage(1);

    }
    public void  SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boColider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }

        transform.localScale = new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false); 
    }
}
