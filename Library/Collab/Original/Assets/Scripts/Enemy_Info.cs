using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Info : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float hp;

    // Start is called before the first frame update
    void Awake()
    {
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(hp <= 0)
        {
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                if (this.transform.parent.name == "Enemy1" || this.transform.parent.name == "Enemy3")
                {
                    scoreManagement.SavingScore(20);
                }
                else if (this.transform.parent.name == "Enemy2")
                {
                    scoreManagement.SavingScore(25);
                }
            }else if (SceneManager.GetActiveScene().name == "Stage2")
            {
                if (this.transform.parent.name == "Enemy1")
                {
                    scoreManagement.SavingScore(30);
                }
                else if (this.transform.parent.name == "Enemy2")
                {
                    scoreManagement.SavingScore(20);
                }
            }else if (SceneManager.GetActiveScene().name == "Stage3") {
                if (this.gameObject.name == "Boss") {
                    scoreManagement.SavingScore(250);
                    SCORE_SAVE save = new SCORE_SAVE();
                    save.endScoreSave(scoreManagement.savingScore);
                    Debug.Log("스코어 전달 성공");
                }
                else if (this.gameObject.name == "1(Clone)")
                {
                    scoreManagement.SavingScore(45);
                }
            }
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "PlayerAttack")
        {
            onAttacked();
        }
    }
    void onAttacked()
    {
        this.hp -= 1;

        StartCoroutine("Attacked");
    }
    IEnumerator Attacked()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color(1, 0, 0);
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1);
            }

            yield return new WaitForSeconds(0.1f);

            countTime++;
        }
        yield return null;
    }
}
