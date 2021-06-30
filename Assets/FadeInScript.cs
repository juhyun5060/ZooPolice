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
            // fadeTime���� ����� fadeTime �ð����� percent ���� 0���� 1�� �����ϵ��� ��
            currentTime += Time.deltaTime;
            percent = currentTime / 0.4f;

            // ���İ� a�� start���� end���� fadeTime �ð� ���� ��ȭ��Ŵ
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
                    Debug.Log("���ھ� ���� �� �̵� ����");
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
