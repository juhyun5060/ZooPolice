using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToGameOver : MonoBehaviour
{
    SpriteRenderer rend;
    GameObject player1;
    GameObject player2;

    private void Update()
    {

        // 플레이어가 다 죽었을 때
        if (player1.GetComponent<Player_Info>().isDead == true && player2.GetComponent<Player_Info>().isDead == true)
        {
            startFading();
        }
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    IEnumerator FadeIn()
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // fadeTime으로 나누어서 fadeTime 시간동안 percent 값이 0에서 1로 증가하도록 함
            currentTime += Time.deltaTime;
            percent = currentTime / 0.4f;

            // 알파값 a를 start부터 end까지 fadeTime 시간 동안 변화시킴
            Color color = rend.material.color;
            color.a = Mathf.Lerp(0, 1, percent);
            rend.material.color = color;

            if (rend.material.color.a == 1)
            {
                if (this.gameObject.name == "FadeToGameOver")
                    SceneManager.LoadScene("GameOver");
            }

            yield return null;
        }
    }

    public void startFading()
    {
        StartCoroutine("FadeIn");
    }

}
