using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public void SceneChange()
    {
        if(this.gameObject.name == "ClickStart")
        {
            SceneManager.LoadScene("Map1");
        } else
        {
            //SceneManager.LoadScene("Ranking");
        }
    }
}
