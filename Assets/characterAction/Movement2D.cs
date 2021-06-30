using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 7.0f;
    private Vector3 moveDirection;

    public void Setup(Vector3 direction)
    {
        moveDirection = direction;

        Destroy(gameObject, 3f);
    }

    public void Update()
    {
        // 새로운 위치 = 현재 위치 + (방향 + 속도)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //장애물 레이어일 때
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("벽에 맞음");
            Destroy(gameObject);
        }
    }
}
