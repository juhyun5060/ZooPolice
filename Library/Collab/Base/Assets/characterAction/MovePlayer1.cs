using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Comma;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.5f;
    private Vector3 lastMoveDirection = Vector3.right;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal1");
        float y = Input.GetAxisRaw("Vertical1");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        if (x != 0 || y != 0)
        {
            lastMoveDirection = new Vector3(x, y, 0);

            // 캐릭터 모션(Animator의 paramater값 설정)
            animator.SetFloat("DirX", x);
            animator.SetFloat("DirY", y);
            animator.SetBool("Walking", true);
        } else
        {
            animator.SetBool("Walking", false);
        }

        // 총 쏘기
        if (Input.GetKeyDown(keyCodeFire))
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.tag = "PlayerAttack";
            clone.transform.localScale = Vector3.one * 0.2f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;

            clone.GetComponent<Movement2D>().Setup(lastMoveDirection);
        }
    }
}
