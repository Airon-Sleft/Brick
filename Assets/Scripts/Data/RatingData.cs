using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Android;

[Serializable]
public class RatingData
{
	public string name;
	public int point;
}
[Serializable]
public class RatingDataHandler
{
	[Serializable]
	private class DataList
	{
		public List<RatingData> data = new();
	}
	private DataList dataList;
	private IDataLocal<DataList> dataHandler;
	public void Add(RatingData data)
	{
		RatingData result = dataList.data.Where(p => p.name == data.name).FirstOrDefault();
		if (result != null)
		{
			if (data.point > result.point)
			{
				result.point = data.point;
				Save();
			}
			return;
		}
		dataList.data.Add(data);
		while (dataList.data.Count > 10)
		{
			RatingData one = dataList.data.OrderBy(p => p.point).FirstOrDefault();
			dataList.data.Remove(one);
		}
	}
	public RatingDataHandler()
	{
		dataHandler = DataRepositoryFactory<DataList>.Create("score");
	}
	public void Init()
	{
		dataList = dataHandler.Load();
	}

	public void Save()
	{
		dataHandler.Save(dataList);
	}

	public List<RatingData> GetData()
	{
		return dataList.data;
	}
}
