
public class WaveManager : Singleton<WaveManager>
{
    private int waveNum = 0;
    private ObjectSpawner spawner;

    private void Awake()
    {
        spawner = GetComponentInChildren<ObjectSpawner>();
    }

    public int WaveNum { get { return waveNum; } }

    public void NextWave()
    {
        waveNum++;
        spawner.SpawnObjects();
    }
}
