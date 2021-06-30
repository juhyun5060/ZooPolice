using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToClear : MonoBehaviour
{
    SpriteRenderer rend;
    GameObject enemy1; GameObject enemy1_1; GameObject enemy1_2; GameObject enemy1_3;
    GameObject enemy2; GameObject enemy2_1; GameObject enemy2_2; GameObject enemy2_3;
    GameObject enemy3; GameObject enemy3_1;

    private void Update()
    {   
        // Stage1에서
        if (this.gameObject.name == "FadeToClear1")
        {
            // 적이 다 죽었을 때
            if (enemy1 == null && enemy1_1 == null
                && enemy2 == null && enemy2_1 == null
                && enemy3 == null && enemy3_1 == null)
            {
                startFading();
            }
        } else if (this.gameObject.name == "FadeToClear2")
        {
            if (enemy1 == null && enemy1_1 == null && enemy1_2 == null && enemy1_3 == null
                && enemy2 == null && enemy2_1 == null && enemy2_2 == null && enemy2_3 == null)
            {
                startFading();
            }
        } else if (this.gameObject.name == "FadeToClear3")
        {
            if (enemy1 == null && enemy2 == null && enemy3 == null)
            {
                startFading();
            }
        }
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

        if (this.gameObject.name == "FadeToClear1")
        {
            enemy1 = GameObject.Find("Enemy1").transform.Find("1").gameObject; enemy1_1 = GameObject.Find("Enemy1").transform.Find("1 (1)").gameObject;
            enemy2 = GameObject.Find("Enemy2").transform.Find("1").gameObject; enemy2_1 = GameObject.Find("Enemy2").transform.Find("1 (1)").gameObject;
            enemy3 = GameObject.Find("Enemy3").transform.Find("1").gameObject; enemy3_1 = GameObject.Find("Enemy3").transform.Find("1 (1)").gameObject;
        } else if (this.gameObject.name == "FadeToClear2")
        {
            enemy1 = GameObject.Find("Enemy1").transform.Find("1").gameObject; enemy1_1 = GameObject.Find("Enemy1").transform.Find("1 (1)").gameObject; enemy1_2 = GameObject.Find("Enemy1").transform.Find("1 (2)").gameObject; enemy1_3 = GameObject.Find("Enemy1").transform.Find("1 (3)").gameObject;
            enemy2 = GameObject.Find("Enemy2").transform.Find("1").gameObject; enemy2_1 = GameObject.Find("Enemy2").transform.Find("1 (1)").gameObject; enemy2_2 = GameObject.Find("Enemy2").transform.Find("1 (2)").gameObject; enemy2_3 = GameObject.Find("Enemy2").transform.Find("1 (3)").gameObject;
        } else if (this.gameObject.name == "FadeToClear3")
        {
            enemy1 = GameObject.Find("Boss").transform.Find("Enemy").gameObject;
            enemy2 = GameObject.Find("Boss").transform.Find("Enemy").gameObject.transform.Find("1 (1)").gameObject;
            enemy3 = GameObject.Find("Boss").transform.Find("Enemy").gameObject.transform.Find("1 (2)").gameObject;
        }


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
                if (this.gameObject.name == "FadeToClear1")
                {
                    SceneManager.LoadScene("Clear1");
                } else if(this.gameObject.name == "FadeToClear2")
                {
                    SceneManager.LoadScene("Clear2");
                } else if (this.gameObject.name == "FadeToClear3")
                {
                    SceneManager.LoadScene("Clear3");
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
