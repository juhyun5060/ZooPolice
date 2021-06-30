using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_movement : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float nextX; //�̵����� ���� 
    public float nextY; //�̵����� ����
    public float speed; //�̵��ӵ�

    public GameObject player1;
    public GameObject player2;

    public GameObject bullet; //�Ѿ�
    public float cooltime;
    private float currenttime;
    private Vector3 direction = Vector3.right;

    public float visualRange; //���Ÿ� ���� �þ�
    public float atkRange; //�ٰŸ� ���� �þ�

    float distance1; //player1���� �Ÿ�
    float distance2; //player2���� �Ÿ�
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //�÷��̾� �ν�/����(����>��ֹ�>�����̵�)
        distance1 = Vector3.Distance(player1.transform.position, rigid.position);
        distance2 = Vector3.Distance(player2.transform.position, rigid.position);

       
        //�ٰŸ� ���� ���� �ȿ� ������ �� �߰�
        if (distance1 <= atkRange || distance2 <= atkRange)
        {
            //player1�� �� ����� ��
            if (distance1 < distance2)
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player1.transform.position, speed / 50f);
            }
            //player2�� �� ����� ��
            else
            {
                rigid.position = Vector3.MoveTowards(rigid.position, player2.transform.position, speed / 50f);
            }
        }
        //���Ÿ� ���� �ȿ� �����鼭 �ٰŸ� ���� �ۿ� ���� ��
        else if (distance1 < visualRange || distance2 < visualRange)
        {
            //player1�� �� ����� ��
            if (distance1 < distance2)
            {
                direction = player1.transform.position - transform.position;
            }
            //player2�� �� ����� ��
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
            //�̵�
            rigid.velocity = new Vector2(nextX, nextY);

            //��ֹ� Ȯ��
            Vector2 frontVec = new Vector2(rigid.position.x + nextX, rigid.position.y + nextY);
            Debug.DrawRay(rigid.position, new Vector3(nextX, nextY, 0), new Color(1, 0, 0)); //����������� ���� �߻�
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, new Vector3(nextX, nextY, 0), 1, LayerMask.GetMask("Obstacle(temp)"));
            if (rayHit.collider != null) //��ֹ��� ���� ��
            {
                //�ڵ����ϱ�
                nextX *= -1; nextY *= -1;
                CancelInvoke();
                Invoke("Think", 3);
                //Debug.Log(rayHit.collider.name);
            }
        }
        currenttime -= Time.deltaTime;
    }

    //�̵� ���� ���� �Լ�
    void Think()
    {
        int nextMove = Random.Range(0, 5);
        switch (nextMove)
        {
            case 0: nextX = 0; nextY = speed; break; //��
            case 1: nextX = 0; nextY = -speed; break; //��
            case 2: nextX = -speed; nextY = 0; break; //��
            case 3: nextX = speed; nextY = 0; break; //��
            default: nextX = 0; nextY = 0; break; //����
        }
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
}
