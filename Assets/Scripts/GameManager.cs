using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
	public int gold;
	[SerializeField] int winCondition = 1000;
	public GameObject planet;

	public bool isPlaying = true;

	[SerializeField] TextMeshProUGUI goldDisplay;
	[SerializeField] GameObject gameOverScreen;
	[SerializeField] GameObject pausedScreen;
	[SerializeField] GameObject playButton;
	[SerializeField] GameObject pauseButton;
	[SerializeField] Animator transition;


	private void Start()
	{
		Time.timeScale = 1;
		pauseButton.SetActive(true);
		playButton.SetActive(false);
	}

	private void Update()
	{
		UpdateGoldDisplay();
		if (gold >= winCondition && isPlaying)
		{
			Debug.Log("You Won!");
			GameOver();
		}
	}

	private void UpdateGoldDisplay()
	{
		goldDisplay.text = gold.ToString();
	}

	public void ExitGame()
	{
		StartCoroutine(LoadGame(0));
	}

	public void ReplayLevel()
	{
		StartCoroutine(LoadGame(1));
	}

	IEnumerator LoadGame(int sceneIndex)
	{
		transition.SetTrigger("start");

		yield return new WaitForSeconds(1.5f);

		SceneManager.LoadScene(sceneIndex);
	}

	private void GameOver()
	{
		gameOverScreen.SetActive(true);
		isPlaying = false;
		while (planet.transform.childCount > 0)
		{
			DestroyImmediate(planet.transform.GetChild(0).gameObject);
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		pauseButton.SetActive(false);
		playButton.SetActive(true);
		pausedScreen.SetActive(true);
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		playButton.SetActive(false);
		pauseButton.SetActive(true);
		pausedScreen.SetActive(false);
	}
}
