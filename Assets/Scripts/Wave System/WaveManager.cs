using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{ 
    public int WaveNum { get { return waveNum; } }
    public int AsteroidsInLevel {  get {  return waveRoundData[waveNum].numOfAsteroids; } }
    public int EnemiesInLevel { get { return waveRoundData[waveNum].numOfEnemies; } }
    public float AsteroidCooldownInLevel { get { return waveRoundData[waveNum].asteroidCooldown; } }
    public float EnemyCooldownInLevel { get { return waveRoundData[waveNum].enemyCooldown; } }
    public int AsteroidsInCurrentWave { get { return asteroidsInCurrentWave; } }

    [SerializeField] private WaveRoundDataScriptableObject[] waveRoundData;

    private int waveNum = 0;
    private int asteroidsInCurrentWave;
    private ObjectSpawner spawner;

    private void Awake()
    {
        spawner = GetComponentInChildren<ObjectSpawner>();
    }

    private void Start()
    {
        asteroidsInCurrentWave = waveRoundData[waveNum].numOfAsteroids;
        spawner.SpawnObjects();
    }

    private void Update()
    {
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (asteroidsInCurrentWave == 0)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        waveNum++;
        spawner.SpawnObjects();
    }

    public void AsteroidDestroyed()
    {
        asteroidsInCurrentWave--;
    }

}
