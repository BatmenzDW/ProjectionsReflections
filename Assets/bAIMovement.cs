using System.Collections;
using UnityEngine;
 
public class bAIMovement : MonoBehaviour
{
    [Header("Enemy Weapon Field")]
    public GameObject eBul;
    public Transform eBulSpawn;
 
    private Rigidbody2D enemyRb;
    private float enemySpd = 5f;
    private float bulSpd = 20f;
    private float shootTimer = 1.0f;
    private int moveDir;
    private int curDir; 
    private bool canChange;
    private bool canFire;
    private bool readyTofire;
    private Vector2 moveDirection;
 
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        moveDir = Random.Range(1, 5);
        if(moveDir < 1 || moveDir > 4)
        {
            while(moveDir < 1 || moveDir > 4) { moveDir = Random.Range(1, 5); }
        }
 
        canChange = true; 
        canFire = false; 
        readyTofire = false; 
    }
 
    private void Update()
    {
        if (PlayerDetection.playerIsDetected == false)
        {
            MovementHandler();
            readyTofire = false;
            shootTimer = 1.0f;
        }
        else
        {
            StopMoving();                      
        }
 
        if(readyTofire == true)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer > 0f && canFire == true)
            {
                StartCoroutine(FireRate());
            }
 
            if(shootTimer < -1f)
            {
                shootTimer = 1.0f;              
            }
        }
    }
 
    private void FixedUpdate()
    {
        enemyRb.MovePosition(enemyRb.position + (moveDirection * enemySpd) * Time.fixedDeltaTime);
    }
 
    void ChangeDirection()
    {
        if (EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == true &&
                                                                                                 EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1, 5);
            if (moveDir < 1 || moveDir > 4)
            {
                while (moveDir < 1 || moveDir > 4)
                {
                    moveDir = Random.Range(1, 5);
                    if (moveDir == curDir)
                    {
                        moveDir = Random.Range(1, 5);
                    }
                }
            }
        } 
        else if(EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == false &&
                                                                                                     EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1, 5); 
            while(moveDir < 1 || moveDir > 4 || moveDir == 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == false &&
                                                                                                      EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 4 || moveDir == 2 || moveDir == 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == false && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == false &&
                                                                                                       EnemyDetection.pathOpenUp == true)
        {
            moveDir = 4;
        } 
        else if(EnemyDetection.pathOpenDown == false && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == true &&
                                                                                                      EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1,5);
            while (moveDir < 3 || moveDir > 4)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == false && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == true &&
                                                                                                     EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1, 5);
            while (moveDir > 4 || moveDir < 2)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == false && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == false &&
                                                                                                      EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1, 5);
            while (moveDir < 1 || moveDir > 4 || moveDir == 1 || moveDir == 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == true &&
                                                                                                     EnemyDetection.pathOpenUp == true)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 4 || moveDir == 2)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == true &&
                                                                                                   EnemyDetection.pathOpenUp == false)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if(EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == false &&
                                                                                                   EnemyDetection.pathOpenUp == false)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 2)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if (EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == true &&
                                                                                                   EnemyDetection.pathOpenUp == false)
        {
            moveDir = Random.Range(1, 5);
            while(moveDir < 1 || moveDir > 3)
            {
                moveDir = Random.Range(1, 5);
            }
        }
        else if (EnemyDetection.pathOpenDown == true && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == false &&
                                                                                                   EnemyDetection.pathOpenUp == false)
        {
            moveDir = 1;
        }
        else if (EnemyDetection.pathOpenDown == false && EnemyDetection.pathOpenLeft == true && EnemyDetection.pathOpenRight == false &&
                                                                                                   EnemyDetection.pathOpenUp == false)
        {
            moveDir = 2;
        } 
        else if (EnemyDetection.pathOpenDown == false && EnemyDetection.pathOpenLeft == false && EnemyDetection.pathOpenRight == true &&
                                                                                                   EnemyDetection.pathOpenUp == false)
        {
            moveDir = 3;
        }
        else { moveDir = 4; }
    }
 
    void MoveLeft()
    {
        curDir = 2;
        enemyRb.transform.GetChild(0).GetChild(0).eulerAngles = new Vector3(0, 0, -90);
        moveDirection = Vector2.left;
    }
 
    void MoveRight()
    {
        curDir = 3;
        enemyRb.transform.GetChild(0).GetChild(0).eulerAngles = new Vector3(0, 0, 90);
        moveDirection = Vector2.right;
    }
 
    void MoveUp()
    {
        curDir = 4;
        enemyRb.transform.GetChild(0).GetChild(0).eulerAngles = new Vector3(0, 0, 180);
        moveDirection = Vector2.up;
    }
 
    void MoveDown()
    {
        curDir = 1;
        enemyRb.transform.GetChild(0).GetChild(0).eulerAngles = new Vector3(0, 0, 0);
        moveDirection = Vector2.down;
    }
 
    void StopMoving()
    {
        moveDirection = Vector2.zero;
        if (shootTimer >= 1.0f)
        {
            readyTofire = true;
            canFire = true;
        }
    }
 
    void StartShooting()
    {
            GameObject eBull = Instantiate(eBul, eBulSpawn.position, eBulSpawn.rotation);
            Rigidbody2D eBulRb = eBull.GetComponent<Rigidbody2D>();
            eBulRb.AddForce(eBulSpawn.up * bulSpd, ForceMode2D.Impulse);
            Destroy(eBull, 3f);              
    }
 
    void MovementHandler()
    {
        if (moveDir == 1)
        {
            if (EnemyDetection.pathOpenDown == true)
            {
                MoveDown();
            }
            else { ChangeDirection(); }
        }
        else if (moveDir == 2)
        {
            if (EnemyDetection.pathOpenLeft == true)
            {
                MoveLeft();
            }
            else { ChangeDirection(); }
        }
        else if (moveDir == 3)
        {
            if (EnemyDetection.pathOpenRight == true)
            {
                MoveRight();
            }
            else { ChangeDirection(); }
        }
        else if (moveDir == 4)
        {
            if (EnemyDetection.pathOpenUp == true)
            {
                MoveUp();
            }
            else { ChangeDirection(); }
        }
 
        if (canChange == true)
        {
            StartCoroutine(RandomMovement());
        }
    }
 
    IEnumerator RandomMovement()
    {
        canChange = false;
        var timer = Random.Range(0.5f, 2.5f);
        yield return new WaitForSeconds(timer);
        ChangeDirection();
        yield return new WaitForSeconds(0.5f);
        canChange = true;
    }
 
    IEnumerator FireRate()
    {
        canFire = false;
        float fireRate = 0.25f;
        yield return new WaitForSeconds(fireRate);
        StartShooting();
        yield return new WaitForSeconds(fireRate);
        canFire = true;
 
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            ChangeDirection();
        }
    }
}
