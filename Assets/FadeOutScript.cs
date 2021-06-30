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
            // fadeTime으로 나누어서 fadeTime 시간동안 percent 값이 0에서 1로 증가하도록 함
            currentTime += Time.deltaTime;
            percent = currentTime / 0.4f;

            // 알파값 a를 start부터 end까지 fadeTime 시간 동안 변화시킴
            Color color = rend.material.color;
            color.a = Mathf.Lerp(1, 0, percent);
            rend.material.color = color;

            yield return null;
        }
    }
}
