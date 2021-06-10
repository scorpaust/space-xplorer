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

		CalculateHighscore(shipsDestroyedFinal, meteorsDestroyedFinal, waveCountFinal);
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
	}

	private void CalculateHighscore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
	{
		int shipsDestroyedHighscoreData = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);

		int meteorsDestroyedHighscoreData = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);

		int waveHighscoreData = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

		if (shipsDestroyedCurrent > shipsDestroyedHighscoreData)
			DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA, shipsDestroyedCurrent);

		if (meteorsDestroyedCurrent > meteorsDestroyedHighscoreData)
			DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA, meteorsDestroyedCurrent);

		if (waveCurrent > waveHighscoreData)
			DataManager.SaveData(TagManager.WAVE_NUMBER_DATA, waveCurrent);

		shipsDestroyedHighscore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);

		meteorsDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);

		waveHighscore.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
	}
}
