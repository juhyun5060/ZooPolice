using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� ����� �� �Ѿ� ����
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        // �÷��̾� �Ѿ˰� ����� �� �浹 ����
        } else if(collision.gameObject.layer == 10)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    // �浹�� ������ ��(�浹�� ���� ���� ��)
    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
