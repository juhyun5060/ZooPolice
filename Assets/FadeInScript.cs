using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInScript : MonoBehaviour
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
                if (this.gameObject.name == "FadeToStage1")
                {
                    SceneManager.LoadScene("Stage1");
                } else if(this.gameObject.name == "FadeToMap1")
                {
                    SceneManager.LoadScene("Map1");
                } else if(this.gameObject.name == "FadeToStage2")
                {
                    SceneManager.LoadScene("Stage2");
                } else if (this.gameObject.name == "FadeToMap2")
                {
                    SceneManager.LoadScene("Map2");
                } else if (this.gameObject.name == "FadeToMap3")
                {
                    SceneManager.LoadScene("Map3");
                } else if (this.gameObject.name == "FadeToStage3")
                {
                    SceneManager.LoadScene("Stage3");
                } else if(this.gameObject.name == "FadeToHow")
                {
                    SceneManager.LoadScene("HowToPlay");
                } else if (this.gameObject.name == "FadeToHome")
                {
                    scoreManagement.savingScore = 0;
                    timeScore.time = 1;
                    SceneManager.LoadScene("StartScene");
                } else if (this.gameObject.name == "FadeToRank")
                {
                    Debug.Log("스코어 저장 씬 이동 성공");
                    SceneManager.LoadScene("saveScore");
                }
                else if (this.gameObject.name == "FadeScreen")
                {
                    scoreManagement.savingScore = 0;
                    timeScore.time = 1;
                    SceneManager.LoadScene("StartScene");
                }
                else if (this.gameObject.name == "FadeToRanking")
                {
                    SceneManager.LoadScene("Ranking");
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
