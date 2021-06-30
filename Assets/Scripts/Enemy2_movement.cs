using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_movement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float nextX; //이동방향 결정 
    public float nextY; //이동방향 결정
    public float speed; //이동속도

    public GameObject player1;
    public GameObject player2;

    public GameObject bullet; //총알
    public float cooltime;
    private float currenttime;
    private Vector3 direction = Vector3.right;

    public float visualRange; //원거리 공격 시야
    public float atkRange; //근거리 공격 시야

    float distance1; //player1과의 거리
    float distance2; //player2와의 거리
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //플레이어 인식/추적(추적>장애물>자유이동)
        distance1 = Vector3.Distance(player1.transform.position, rigid.position);
        distance2 = Vector3.Distance(player2.transform.position, rigid.position);

       
        //근거리 공격 범위 안에 들어왔을 시 추격
        if (distance1 <= atkRange || distance2 <= atkRange)
        {
            //player1이 더 가까울 때
            if (distance1 < distance2)
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player1.transform.position, speed / 50f);
            }
            //player2가 더 가까울 때
            else
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player2.transform.position, speed / 50f);
            }
        }
        //원거리 범위 안에 있으면서 근거리 범위 밖에 있을 때
        else if (distance1 < visualRange || distance2 < visualRange)
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
                bulletClone.transform.localScale = Vector3.one * 0.2f;

                bulletClone.GetComponent<Movement2D>().Setup(direction/5);
                currenttime = cooltime;
            }
        }
        else
        {
            //이동
            rigid.velocity = new Vector2(nextX, nextY);

            //장애물 확인
            Vector2 frontVec = new Vector2(rigid.position.x + nextX, rigid.position.y + nextY);
            Debug.DrawRay(rigid.position, new Vector3(nextX, nextY, 0), new Color(1, 0, 0)); //진행방향으로 레이 발사
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, new Vector3(nextX, nextY, 0), 1, LayerMask.GetMask("Obstacle(temp)"));
            if (rayHit.collider != null) //장애물이 있을 때
            {
                //뒤돌게하기
                nextX *= -1; nextY *= -1;
                CancelInvoke();
                Invoke("Think", 3);
                //Debug.Log(rayHit.collider.name);
            }
        }
        currenttime -= Time.deltaTime;
    }

    //이동 방향 결정 함수
    void Think()
    {
        int nextMove = Random.Range(0, 5);
        switch (nextMove)
        {
            case 0: nextX = 0; nextY = speed; break; //상
            case 1: nextX = 0; nextY = -speed; break; //하
            case 2: nextX = -speed; nextY = 0; break; //좌
            case 3: nextX = speed; nextY = 0; break; //우
            default: nextX = 0; nextY = 0; break; //정지
        }
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
}
