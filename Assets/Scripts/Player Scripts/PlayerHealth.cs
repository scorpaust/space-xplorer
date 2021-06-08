using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth = 100f;

    [SerializeField]
    private GameObject playerExplosionFx;

    [SerializeField]
    private GameObject playerDamageFx;

    private float playerHealth;

	private void Awake()
	{
        playerHealth = playerMaxHealth;
	}

    public void TakeDamage(float damageAmount)
	{
        playerHealth -= damageAmount;

        if (playerHealth <= 0)
		{
            Instantiate(playerExplosionFx, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDestroySound();

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
		if (collision.CompareTag("Meteor"))
		{
            TakeDamage(Random.Range(20, 40));

            Destroy(collision.gameObject);
		}
	}
}
