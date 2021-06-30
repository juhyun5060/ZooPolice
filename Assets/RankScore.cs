using System.Collections;
using UnityEngine;
using TMPro;

public class RankScore : MonoBehaviour
{
	public string[] items;

	public TextMeshProUGUI score1;
	public TextMeshProUGUI score2;
	public TextMeshProUGUI score3;


	IEnumerator Start()
	{
		WWW itemsData = new WWW("http://gamejjang.dothome.co.kr/readRanking.php");
		yield return itemsData;
		/*string itemDataString = itemsData.text;
		print(itemDataString);
		items = itemDataString.Split(';');
		print(GetDataValue(items[0], "Name:"));
		score.text = GetDataValue(items[0], "Name:");
		ranking++;*/
		string itemDataString = itemsData.text;
		print(itemDataString);
		items = itemDataString.Split(';');

		score1.text = GetDataValue(items[0], " ");
		score2.text = GetDataValue(items[1], " ");
		score3.text = GetDataValue(items[2], " ");

	}

	string GetDataValue(string data, string index)
	{
		string value = data.Substring(data.IndexOf(index) + index.Length);
		return value;
	}


}
