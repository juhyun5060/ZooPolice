using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testFadeToRank : MonoBehaviour
{
    SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    IEnumerator FadeIn()
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        if (this.gameObject.name == "FadeToRank")
        {
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
                    Debug.Log("스코어 저장 성공");
                    SceneManager.LoadScene("saveScore");
                }
            }

            yield return null;
        }
    }

    public void startFading()
    {
        StartCoroutine("FadeIn");
    }

}
