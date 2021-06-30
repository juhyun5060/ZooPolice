using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange()
    {
        if(this.gameObject.name == "ClickRank")
        {
            //SceneManager.LoadScene("Ranking");
        } else if(this.gameObject.name == "ClickSkip")
        {
            SceneManager.LoadScene("Stage1");
        } else if(this.gameObject.name == "ClickMap2")
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
