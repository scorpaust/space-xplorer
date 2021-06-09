using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth = 100f;

    [SerializeField]
    private GameObject playerExplosionFx;

    [SerializeField]
    private GameObject playerDamageFx;

    private float playerHealth;

    private Collectable collectable;

    private Slider playerHealthSlider;

	private void Awake()
	{
        playerHealth = playerMaxHealth;

        playerHealthSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();

        playerHealthSlider.minValue = 0;

        playerHealthSlider.maxValue = playerHealth;

        playerHealthSlider.value = playerHealth;
	}

    public void TakeDamage(float damageAmount)
	{
        playerHealth -= damageAmount;

        playerHealthSlider.value = playerHealth;

        if (playerHealth <= 0)
		{
            Instantiate(playerExplosionFx, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDestroySound();

            GameoverUIController.instance.OpenGameoverPanel();

            Destroy(gameObject);
		}
        else
		{
            Instantiate(playerDamageFx, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDamageSound();
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
		{
            collectable = collision.GetComponent<Collectable>();

            if (collectable.type == CollectableType.Health)
			{
                playerHealth += collectable.healthValue;

                if (playerHealth > playerMaxHealth)
                    playerHealth = playerMaxHealth;

                Destroy(collision.gameObject);
            }
                
		}

		if (collision.CompareTag("Meteor"))
		{
            TakeDamage(Random.Range(20, 40));

            Destroy(collision.gameObject);
		}
	}
}
