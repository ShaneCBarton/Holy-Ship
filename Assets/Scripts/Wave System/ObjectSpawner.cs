using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidToSpawn;
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private WaveRoundDataScriptableObject[] waveRoundData;


    public void SpawnObjects()
    {
        int waveNumber = WaveManager.Instance.WaveNum;
        int asteroidAmount = waveRoundData[waveNumber].numOfAsteroids;
        int enemyAmount = waveRoundData[waveNumber].numOfEnemies;
        float asteroidCooldown = waveRoundData[waveNumber].asteroidCooldown;
        float enemyCooldown = waveRoundData[waveNumber].enemyCooldown;

        InstantiateObjects(asteroidAmount, asteroidCooldown, asteroidToSpawn);
        InstantiateObjects(enemyAmount, enemyCooldown, enemyToSpawn);
    }

    private void InstantiateObjects(int amount, float cooldown, GameObject objectToSpawn)
    {
        if (amount <= 0) { return; }

        for (int i = 1; i <= amount; i++)
        {
            StartCoroutine(SpawnTimeCooldownRoutine(cooldown));
            Instantiate(objectToSpawn);
        }
    }

    private IEnumerator SpawnTimeCooldownRoutine(float cooldownDuration)
    {
        yield return new WaitForSeconds(cooldownDuration);
    }
}
