using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;
using System.Linq;
public class RatingUI
{
	private List<RatingData> ratingsList;
	private List<GameObject> textMeshes = new List<GameObject>();
	public GameObject ratingTitle;
	private GameObject canvas;
	public RatingUI(GameObject titleText)
	{
		ratingTitle = titleText;
		ratingsList = new();
		canvas = GameObject.Find("Canvas");
	}
	public void SetRatingData(List<RatingData> ratingsList, bool needUpdateUI = false)
	{
		this.ratingsList = ratingsList;
		if (needUpdateUI) Update();
	}
	private void Clear()
	{
		foreach(var tMesh in textMeshes)
		{
			GameObject.Destroy(tMesh);
		}
		textMeshes.Clear();
	}
	public void Update()
	{
		Clear();
		Vector3 offset = new Vector3 (0, 0, 0);
		foreach (RatingData data in ratingsList.OrderByDescending(p => p.point))
		{
			var oneScoreRow = GameObject.Instantiate(ratingTitle);
			oneScoreRow.transform.SetParent(canvas.transform, false);
			oneScoreRow.transform.position += offset;
			offset.y -= 30;
			TMP_Text textRow = oneScoreRow.GetComponent<TMP_Text>();
			textRow.text = string.Format("{0}: {1}", data.name, data.point);
			textMeshes.Add(oneScoreRow);
		}
	}
}
