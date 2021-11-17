using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordReflect : MonoBehaviour
{
    // Start is called before the first frame update
    //private Vector2 inDirection;
    //private float speed = 1f;
    public Animator animator;

    public Transform attackCollider;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    void Start()
    {
        //inDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void Attack()
    {
        //Attack animation
        animator.SetTrigger("Attack");
        //Detect enemies/bullet
        //START BACK HERE
        Physics2D.OverlapCircleAll(attackCollider.position, attackRange, enemyLayers);
    }
    /*public void fixedUpdate()
    {
        transform.Translate(inDirection * speed, Space.World);
    }
    public void onCollisionEnter2D(Collision2D collision)
    {
        var contact = collision.GetContact(0).point;
        //var contact = collision.contacts[0].point;
        Vector2 locateBullet = transform.position;
        var inNormal = (locateBullet - contact).normalized;
        inDirection = Vector2.Reflect(inDirection, inNormal);

    }
    // Make sword slashing animation, somehow make quarter-end animation in order to time reflection
    //rather than just pressing a key, because that causes the character to be invulnerable
}
*/
}