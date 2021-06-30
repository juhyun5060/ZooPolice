using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator animator;
    Vector3 vector;

    public float nextX; //�̵����� ���� 
    public float nextY; //�̵����� ����
    public float speed; //�̵��ӵ�

    public GameObject player1;
    public GameObject player2;

    public float atkRange; //�ٰŸ� ���� �þ�

    Player_Info player1info;
    Player_Info player2info;

    float distance1; //player1���� �Ÿ�
    float distance2; //player2���� �Ÿ�

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
        //�÷��̾� �ν�/����(����>��ֹ�>�����̵�)
        distance1 = Vector3.Distance(player1.transform.position, rigid.position);
        distance2 = Vector3.Distance(player2.transform.position, rigid.position);
        if (player1info.isDead == true) distance1 = 10;
        if (player2info.isDead == true) distance2 = 10;
        

        if (distance1 <= atkRange || distance2 <= atkRange)
        {
            //player1�� �� ����� ��
            if (distance1 < distance2)
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player1.transform.position, speed/50f);

                animator.SetFloat("DirX", player1.transform.position.x - rigid.position.x);
                animator.SetFloat("DirY", player1.transform.position.y - rigid.position.y);
            }
            //player2�� �� ����� ��
            else
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player2.transform.position, speed/50f);

                animator.SetFloat("DirX", player2.transform.position.x - rigid.position.x);
                animator.SetFloat("DirY", player2.transform.position.y - rigid.position.y);
            }
        }
        else
        {
            //�̵�
            rigid.velocity = new Vector2(nextX, nextY);

            animator.SetFloat("DirX", nextX);
            animator.SetFloat("DirY", nextY);

            //��ֹ� Ȯ��
            Vector2 frontVec = new Vector2(rigid.position.x + nextX, rigid.position.y + nextY);
            Debug.DrawRay(rigid.position, new Vector3(nextX, nextY, 0), new Color(1, 0, 0)); //����������� ���� �߻�
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, new Vector3(nextX, nextY, 0), 1, LayerMask.GetMask("Obstacle"));
            if (rayHit.collider != null) //��ֹ��� ���� ��
            {
                //�ڵ����ϱ�
                nextX *= -1; nextY *= -1;
                CancelInvoke();
                Invoke("Think", 3);
                //Debug.Log(rayHit.collider.name);
            }
        }
    }

    //�̵� ���� ���� �Լ�
    void Think()
    {
        int nextMove = Random.Range(0, 5);

        animator.SetBool("isWalk", true);

        switch (nextMove)
        {
            case 0: nextX = 0; nextY = speed; break; //��
            case 1: nextX = 0; nextY = -speed; break; //��
            case 2: nextX = -speed; nextY = 0; break; //��
            case 3: nextX = speed; nextY = 0; break; //��
            default: nextX = 0; nextY = 0; animator.SetBool("isWalk", false); break; //����
        }
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
    void Stop()
    {
        isStarted = true;
    }
}
