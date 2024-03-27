using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EntryMenuHandler : MonoBehaviour
{
	private GameManager gameManager;
	[SerializeField] private GameObject inputGameObjectField;
	public void Start()
	{
		gameManager = GameManager.Instance;
	}
	public void StartTheGame()
	{
		gameManager.PlayerName = inputGameObjectField.GetComponent<TMP_InputField>().text;
		gameManager.ChangeScene(ISceneManager.SCENES.GAME);
	}
	public void ExitTheGame()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}
}
