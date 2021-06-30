using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator animator;
    Vector3 vector;

    public float nextX; //이동방향 결정 
    public float nextY; //이동방향 결정
    public float speed; //이동속도

    public GameObject player1;
    public GameObject player2;

    public float atkRange; //근거리 공격 시야

    Player_Info player1info;
    Player_Info player2info;

    float distance1; //player1과의 거리
    float distance2; //player2와의 거리

    private bool isStarted = false;
    void Awake()
    {
        player1info = GameObject.Find("Player1").GetComponent<Player_Info>();
        player2info = GameObject.Find("Player2").GetComponent<Player_Info>();

        Invoke("Stop", 2);
        Invoke("Think", 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStarted)
        {
            return;
        }
        //플레이어 인식/추적(추적>장애물>자유이동)
        distance1 = Vector3.Distance(player1.transform.position, rigid.position);
        distance2 = Vector3.Distance(player2.transform.position, rigid.position);
        if (player1info.isDead == true) distance1 = 10;
        if (player2info.isDead == true) distance2 = 10;
        

        if (distance1 <= atkRange || distance2 <= atkRange)
        {
            //player1이 더 가까울 때
            if (distance1 < distance2)
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player1.transform.position, speed/50f);

                animator.SetFloat("DirX", player1.transform.position.x - rigid.position.x);
                animator.SetFloat("DirY", player1.transform.position.y - rigid.position.y);
            }
            //player2가 더 가까울 때
            else
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player2.transform.position, speed/50f);

                animator.SetFloat("DirX", player2.transform.position.x - rigid.position.x);
                animator.SetFloat("DirY", player2.transform.position.y - rigid.position.y);
            }
        }
        else
        {
            //이동
            rigid.velocity = new Vector2(nextX, nextY);

            animator.SetFloat("DirX", nextX);
            animator.SetFloat("DirY", nextY);

            //장애물 확인
            Vector2 frontVec = new Vector2(rigid.position.x + nextX, rigid.position.y + nextY);
            Debug.DrawRay(rigid.position, new Vector3(nextX, nextY, 0), new Color(1, 0, 0)); //진행방향으로 레이 발사
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, new Vector3(nextX, nextY, 0), 1, LayerMask.GetMask("Obstacle"));
            if (rayHit.collider != null) //장애물이 있을 때
            {
                //뒤돌게하기
                nextX *= -1; nextY *= -1;
                CancelInvoke();
                Invoke("Think", 3);
                //Debug.Log(rayHit.collider.name);
            }
        }
    }

    //이동 방향 결정 함수
    void Think()
    {
        int nextMove = Random.Range(0, 5);

        animator.SetBool("isWalk", true);

        switch (nextMove)
        {
            case 0: nextX = 0; nextY = speed; break; //상
            case 1: nextX = 0; nextY = -speed; break; //하
            case 2: nextX = -speed; nextY = 0; break; //좌
            case 3: nextX = speed; nextY = 0; break; //우
            default: nextX = 0; nextY = 0; animator.SetBool("isWalk", false); break; //정지
        }
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
    void Stop()
    {
        isStarted = true;
    }
}
