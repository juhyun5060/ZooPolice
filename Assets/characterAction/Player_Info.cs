using System.Collections;
using UnityEngine;

public class Player_Info : MonoBehaviour
{
    public Rigidbody2D rigid;
    public SpriteRenderer spriteRenderer;
    public float hp;
    public GameObject Heart;

    public bool isDead;
    bool isHit;
    private Color invisibleColor;

    Transform filledHeart;
    // Start is called before the first frame update
    void Awake()
    {
        isDead = false;
        isHit = false;
        filledHeart = Heart.transform.Find("FilledHeart");
        invisibleColor = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hp <= 0)
        {
            isDead = true;
            Died();
            return;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        rigid.isKinematic = false;
        if (collision.gameObject.tag == "Enemy" && isDead == false)
        {
            onDamaged();
        }
        else if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerAttack")
        {
            rigid.isKinematic = true;
        }
    }
    void onDamaged()
    {
        hp -= 1;
        switch (hp)
        {
            case 2: changeHeart(2); break;
            case 1: changeHeart(1); break;
            case 0: changeHeart(0); break;
            default: break;
        }
        if (isHit == true)
        {
            //무적 레이어
            gameObject.layer = 9;
            StartCoroutine("UnBeatTime");
        }
        else
        {
            hp += 1;
        }
        
    }
    void offDamaged()
    {
        gameObject.layer = 8;
        isHit = false;
    }
    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while(countTime < 10)
        {
            if(countTime%2 == 0)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 1);
            }

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        offDamaged();
        yield return null;
    }
    void Died()
    {
        StartCoroutine(nameof(Dying));
        if(isDead == true)
        {
            StopCoroutine(nameof(Dying));
            spriteRenderer.color = invisibleColor;
        }
    }

    IEnumerator Dying()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
            }

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        yield return null;
    }
    void changeHeart(int index)
    {
        isHit = true;
        if (index <= 1)
        {
            //프레임으로 한번에 죽을 때 하트 남는 거 방지
            filledHeart.GetChild(index + 1).gameObject.GetComponent<SpriteRenderer>().color = invisibleColor;
        }
        filledHeart.GetChild(index).gameObject.GetComponent<SpriteRenderer>().color = invisibleColor;
    }
}
