using System.IO;
using UnityEngine;

public interface IDataLocal<T>
{
	public T Load();
	public void Save(T dataList);
}

public class DataRepository<T> : IDataLocal<T> where T : class
{
	public string Name;
	public DataRepository(string dataName)
	{
		Name = dataName;
	}
	public T Load()
	{
		var Path = Application.persistentDataPath + "/" + Name + ".json";
		if (!File.Exists(Path)) return default;
		string fileData = File.ReadAllText(Path);
		return JsonUtility.FromJson<T>(fileData);
	}

	public void Save(T dataList)
	{
		var Path = Application.persistentDataPath + "/" + Name + ".json";
		string data = JsonUtility.ToJson(dataList);
		if (!File.Exists(Path))
		{
			FileStream fs = File.Create(Path);
			fs.Dispose();
		}
		File.WriteAllText(Path, data);
	}
}

public class DataRepositoryFactory<T> where T : class
{
	public static IDataLocal<T> Create(string dataName)
	{
		return new DataRepository<T>(dataName);
	}
}