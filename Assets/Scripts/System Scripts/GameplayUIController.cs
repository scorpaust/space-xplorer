using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController instance;

	[SerializeField]
	private Text waveInfoText, shipsDestroyedInfo, meteorsDestroyedInfo;

	private int waveCount, shipsDestroyedCount, meteorsDestroyedCount;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		Cursor.visible = false;

		Cursor.lockState = CursorLockMode.Locked;
	}

	public int GetShipsDestroyedCount()
	{
		return shipsDestroyedCount;
	}

	public int GetMeteorsDestroyedCount()
	{
		return meteorsDestroyedCount;
	}

	public int GetWaveCount()
	{
		return waveCount;
	}

	public void SetInfo(int infoType)
	{
		switch(infoType)
		{
			case 1:
				waveCount++;

				waveInfoText.text = "Wave: " + waveCount;

				break;
			case 2:
				shipsDestroyedCount++;

				shipsDestroyedInfo.text = shipsDestroyedCount + "x";

				break;
			case 3:
				meteorsDestroyedCount++;

				meteorsDestroyedInfo.text = meteorsDestroyedCount + "x";

				break;
		}
	}
}
