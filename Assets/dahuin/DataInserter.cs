using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour
{
	//public InputField inputName;
	//string score;

	public Button saveBtn;
	string CreateUserURL = "http://gamejjang.dothome.co.kr/rankingIndex.php";


	// Use this for initialization
	void Start()
	{
		//버튼을 누르면 saveButton이 실행됨
		//		if (timeUpdate)
		saveBtn.onClick.AddListener(saveButton);
	}

	// Update is called once per frame
	//void Update()
	//{

	//	//스페이스바 누르면 http://gamejjang.dothome.co.kr/rankingIndex.php 에 플레이어 이름, score저장됨(score내림차순)
	//	//if (Input.GetKeyDown(KeyCode.Space)) CreateUser(inputName, time.ToString());
	//}

	void saveButton()
	{
		Debug.Log("hi");
		StartCoroutine(CreateUser("Sdfsdf", 400.ToString()));
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
}