using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public Transform origin, end, player;
    public float radarSpd;
    public bool playerDectected;

    public static bool playerIsDetected;

    private int playerLayer = 1 << 8;
    private Rigidbody2D enemyRb;
    private Vector3 facePlayer;

    private void Start()
    {
        enemyRb = GetComponentInParent<Rigidbody2D>();
        playerIsDetected = false;
    }

    private void Update()
    {
        PlayerDetector();
        if (playerDectected == false)
        {
            Radar();
        }
        else { PlayerIsDetected(); }
    }

    void PlayerDetector()
    {
        Debug.DrawLine(origin.position, end.position, Color.red);
        playerDectected = Physics2D.Linecast(origin.position, end.position, playerLayer);
    }
    void Radar()
    {
        end.RotateAround(origin.position, Vector3.forward, radarSpd * Time.deltaTime);
        playerIsDetected = false;
    }

    void PlayerPosition()
    {
        facePlayer = player.position - enemyRb.transform.GetChild(0).GetChild(0).position;
        enemyRb.transform.GetChild(0).GetChild(0).up = -facePlayer;
    }

    void PlayerIsDetected()
    {
        if(playerDectected == true)
        {
            playerIsDetected = true;
            end.position = player.position;
            PlayerPosition();
        }
    }

}
