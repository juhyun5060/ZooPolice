using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.5f;
    private Vector3 lastMoveDirection = Vector3.right;
    private Animator animator;

    Player_Info info;

    // 총 쏠 때 효과음
    public AudioSource mysfx;
    public AudioClip shootingsfx;
    private void Start()
    {
        animator = GetComponent<Animator>();
        info = GameObject.Find("Player2").GetComponent<Player_Info>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal2");
        float y = Input.GetAxisRaw("Vertical2");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (x != 0 || y != 0)
        {
            lastMoveDirection = new Vector3(x, y, 0);

            // 캐릭터 모션
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
            if(info.isDead == false)
            {
                GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                clone.name = "Bullet";
                clone.tag = "PlayerAttack";
                clone.transform.localScale = Vector3.one * 0.5f;

                clone.GetComponent<Movement2D>().Setup(lastMoveDirection);

                ShootingSound();
            }
        }
    }

    // 효과음 출력 함수
    public void ShootingSound()
    {
        mysfx.PlayOneShot(shootingsfx);
    }
}
