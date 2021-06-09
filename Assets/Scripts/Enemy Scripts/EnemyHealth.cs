using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBar;

    [SerializeField]
    private float health = 100f;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private GameObject destroyEffect;

    private Vector3 healthBarScale;

    private DropCollectable dropCollectable;

	private void Awake()
	{
        dropCollectable = GetComponent<DropCollectable>();
	}

	public void TakeDamage(float damageAmount, float damageResistance)
	{
        damageAmount -= damageResistance;

        health -= damageAmount;

        if (health <= 0)
		{
            health = 0;

            if (gameObject.CompareTag(TagManager.ENEMY_TAG))
			{
                GameplayUIController.instance.SetInfo(2);

                EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            }

            if (gameObject.CompareTag(TagManager.METEOR_TAG))
			{
                GameplayUIController.instance.SetInfo(3);
            }

            Instantiate(destroyEffect, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDestroySound();

            dropCollectable.CheckToSpawnCollectable();

            Destroy(gameObject);
		}
        else
		{
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            SoundManager.instance.PlayDamageSound();
        }

        SetHealthBar();
	}

    private void SetHealthBar()
	{
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;

        healthBarScale.x = health / 100f;

        healthBar.transform.localScale = healthBarScale;
	}
}
