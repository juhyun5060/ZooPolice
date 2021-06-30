using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SCORE_SAVE : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI rankText;
    static int score = 0;

    void Start() {
        score = (int)((score * 100) / timeScore.time);
        scoreText.text = score.ToString();
    }

    // Use this for initialization
    public void endScoreSave(int score)
    {
        SCORE_SAVE.score = score;
        Debug.Log("score РќДо : " + SCORE_SAVE.score);
    }

}

