using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour
{
	public string[] items;
	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;

	public Text name1;
	public Text name2;
	public Text name3;
	public Text name4;
	public Text name5;

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

		name1.text = GetDataValue(items[0], " ");
		score1.text = GetDataValue(items[1], " ");

		name2.text = GetDataValue(items[2], " ");
		score2.text = GetDataValue(items[3], " ");

		name3.text = GetDataValue(items[4], " ");
		score3.text = GetDataValue(items[5], " ");

		name4.text = GetDataValue(items[6], " ");
		score4.text = GetDataValue(items[7], " ");

		name5.text = GetDataValue(items[8], " ");
		score5.text = GetDataValue(items[9], " ");

	}

	string GetDataValue(string data, string index)
	{
		string value = data.Substring(data.IndexOf(index) + index.Length);
		return value;
	}


}