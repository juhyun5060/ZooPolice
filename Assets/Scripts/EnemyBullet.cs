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
        // 플레이어나 벽에 닿았을 때 총알 삭제
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        // 플레이어 총알과 닿았을 때 충돌 무시
        } else if(collision.gameObject.layer == 10)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    // 충돌이 끝났을 때(충돌이 되지 않을 때)
    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }
}
