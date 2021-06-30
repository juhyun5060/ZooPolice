using System.Collections;
using UnityEngine;

public class FadeOutScript : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
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
            color.a = Mathf.Lerp(1, 0, percent);
            rend.material.color = color;

            yield return null;
        }
    }
}
