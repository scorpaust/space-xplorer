using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUIController : MonoBehaviour
{
    public static GameoverUIController instance;

	[SerializeField]
	private Canvas playerInfoCanvas, shipsAndMeteorsInfoCanvas, gameoverCanvas;

	[SerializeField]
	private Text shipsDestroyedFinalInfo, meteorsDestroyedFinalInfo, waveFinalInfo;

	[SerializeField]
	private Text shipsDestroyedHighscore, meteorsDestroyedHighScore, waveHighscore;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	public void OpenGameoverPanel()
	{
		playerInfoCanvas.enabled = false;

		shipsAndMeteorsInfoCanvas.enabled = false;

		gameoverCanvas.enabled = true;

		int shipsDestroyedFinal = GameplayUIController.instance.GetShipsDestroyedCount();

		int meteorsDestroyedFinal = GameplayUIController.instance.GetMeteorsDestroyedCount();

		int waveCountFinal = GameplayUIController.instance.GetWaveCount();

		waveCountFinal--;

		shipsDestroyedFinalInfo.text = "x" + shipsDestroyedFinal;

		meteorsDestroyedFinalInfo.text = "x" + meteorsDestroyedFinal;

		waveFinalInfo.text = "Wave: " + waveCountFinal;
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
	}
}
