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
		//��ư�� ������ saveButton�� �����
		//		if (timeUpdate)
		saveBtn.onClick.AddListener(saveButton);
	}

	// Update is called once per frame
	//void Update()
	//{

	//	//�����̽��� ������ http://gamejjang.dothome.co.kr/rankingIndex.php �� �÷��̾� �̸�, score�����(score��������)
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