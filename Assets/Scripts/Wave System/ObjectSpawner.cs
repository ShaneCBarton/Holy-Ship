using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidToSpawn;
    [SerializeField] private GameObject enemyToSpawn;


    public void SpawnObjects()
    {
        int waveNumber = WaveManager.Instance.WaveNum;
        int asteroidAmount = WaveManager.Instance.AsteroidsInLevel;
        int enemyAmount = WaveManager.Instance.EnemiesInLevel;
        float asteroidCooldown = WaveManager.Instance.AsteroidCooldownInLevel;
        float enemyCooldown = WaveManager.Instance.EnemyCooldownInLevel;

        StartCoroutine(SpawnObjectOnCooldownRoutine(asteroidAmount, asteroidCooldown, asteroidToSpawn));
        StartCoroutine(SpawnObjectOnCooldownRoutine(enemyAmount, enemyCooldown, enemyToSpawn));
    }

    private IEnumerator SpawnObjectOnCooldownRoutine(int amount, float cooldownDuration, GameObject objectToSpawn)
    {
        if (amount <= 0) { yield break; }

        for (int i = 1; i <= amount; i++)
        {
            yield return new WaitForSeconds(cooldownDuration);
            Instantiate(objectToSpawn);
        }
    }
}
