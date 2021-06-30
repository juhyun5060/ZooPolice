using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeScore : MonoBehaviour
{
    public static float time = 1;  //경과 시간을 갖는 변수
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 10)
        {
            timeScore.time += Time.deltaTime;
        }
    }
}
