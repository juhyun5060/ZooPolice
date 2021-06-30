using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManagement : MonoBehaviour
{
	public static int savingScore = 0;
	static int cnt = 0;
	string CreateUserURL = "http://gamejjang.dothome.co.kr/rankingIndex.php";
	public Button saveBtn;
	public Button saveBtn1;

	// Start is called before the first frame update
	public void Start() {
		saveBtn.onClick.AddListener(saveButton);
		saveBtn1.onClick.AddListener(saveButton);
	}

	void saveButton() {
		cnt++;
		savingScore = (int)((savingScore * 100)/ timeScore.time);
		StartCoroutine(CreateUser(cnt.ToString(), savingScore.ToString()));
		Debug.Log("스코어 저장 완료");
		//scoreManagement.savingScore = 0;
	}


	IEnumerator CreateUser(string name, string score)
	{
		WWWForm form = new WWWForm();
		form.AddField("namePost", name);
		form.AddField("scorePost", score);

		WWW www = new WWW(CreateUserURL, form);

		yield return www;
		Debug.Log(www.text);

	}

	public static void SavingScore(int score)
	{
		savingScore += score;
		Debug.Log("현재 점수 : "+savingScore);
	}

}
