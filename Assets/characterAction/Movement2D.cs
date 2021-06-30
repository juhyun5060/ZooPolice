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
        // ���ο� ��ġ = ���� ��ġ + (���� + �ӵ�)
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��ֹ� ���̾��� ��
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("���� ����");
            Destroy(gameObject);
        }
    }
}
