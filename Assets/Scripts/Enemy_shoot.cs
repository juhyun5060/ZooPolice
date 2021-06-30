using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shoot : MonoBehaviour
{
    public Rigidbody2D rigid;

    public float atkRange; //근거리 공격 시야
    public float visualRange; //원거리 공격 시야

    Player_Info player1info;
    Player_Info player2info;

    float distance1; //player1과의 거리
    float distance2; //player2와의 거리

    public GameObject player1;
    public GameObject player2;

    public GameObject bullet; //총알
    public float cooltime;
    private float currenttime;
    private Vector3 direction = Vector3.right;

    private bool isStarted = false;
    public float stopTime = 5;
    // Start is called before the first frame update
    void Awake()
    {
        player1info = GameObject.Find("Player1").GetComponent<Player_Info>();
        player2info = GameObject.Find("Player2").GetComponent<Player_Info>();
        Invoke("Stop", stopTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStarted)
        {
            return;
        }
        distance1 = Vector3.Distance(player1.transform.position, rigid.position);
        distance2 = Vector3.Distance(player2.transform.position, rigid.position);
        if (player1info.isDead == true) distance1 = 10;
        if (player2info.isDead == true) distance2 = 10;

        if ((distance1 <= visualRange && distance1 > atkRange) || (distance2 <= visualRange && distance2 > atkRange))
        {
            //player1이 더 가까울 때
            if (distance1 < distance2)
            {
                direction = player1.transform.position - transform.position;
            }
            //player2가 더 가까울 때
            else
            {
                direction = player2.transform.position - transform.position;
            }

            if (currenttime <= 0)
            {
                GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);

                bulletClone.name = "Bullet";
                bulletClone.tag = "Enemy";
                bulletClone.layer = 7; //Enemy레이어

                bulletClone.GetComponent<Movement2D>().Setup(direction / 5);
                currenttime = cooltime;
            }
        }
        currenttime -= Time.deltaTime;
    }
    void Stop()
    {
        isStarted = true;
    }
}
