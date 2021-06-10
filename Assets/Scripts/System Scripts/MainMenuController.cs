using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenuCanvas, highscoreCanvas;

    [SerializeField]
    private Text shipsDestroyedHighscore, meteorsDestroyedHighscore, wavesSurvivedHighscore;

    private AudioSource audio;

	private void Awake()
	{
        audio = GetComponent<AudioSource>();
	}

	private void Start()
	{
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.Confined;
    }

	public void PlayGame()
	{
        audio.Play();

        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
	}

    public void ToggleHighscoreCanvas(bool open)
	{
        audio.Play();

        mainMenuCanvas.enabled = !open;

        highscoreCanvas.enabled = open;

        if (open)
            DisplayHighscore();
	}

    private void DisplayHighscore()
	{
        shipsDestroyedHighscore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);

        meteorsDestroyedHighscore.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);

        wavesSurvivedHighscore.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
	}
}
