using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public ISceneManager gameSceneManager;
	public string PlayerName;

	public void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		gameSceneManager = new SceneGameManager();
		DontDestroyOnLoad(gameObject);
	}
	public void ChangeScene(ISceneManager.SCENES scene)
	{
		gameSceneManager.Load(scene);
	}
}

public interface ISceneManager
{
	public enum SCENES { 
		ENTRY,
		GAME,
	};
	public void Load(SCENES newScene);
}

public class SceneGameManager : ISceneManager
{
	private List<string> gameScenes = new List<string>()
	{
		"Entry","main",
	};

	private ISceneManager.SCENES actualScene;
	public SceneGameManager()
	{
		actualScene = 0;
	}
	public void Load(ISceneManager.SCENES newScene)
	{
		actualScene = newScene;
		SceneManager.LoadScene(gameScenes[(int)actualScene], LoadSceneMode.Single);		
	}
}