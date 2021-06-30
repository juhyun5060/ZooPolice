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
                // fadeTime���� ����� fadeTime �ð����� percent ���� 0���� 1�� �����ϵ��� ��
                currentTime += Time.deltaTime;
                percent = currentTime / 0.4f;

                // ���İ� a�� start���� end���� fadeTime �ð� ���� ��ȭ��Ŵ
                Color color = rend.material.color;
                color.a = Mathf.Lerp(0, 1, percent);
                rend.material.color = color;


                if (rend.material.color.a == 1)
                {
                    Debug.Log("���ھ� ���� ����");
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
