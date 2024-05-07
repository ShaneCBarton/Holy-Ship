
public class WaveManager : Singleton<WaveManager>
{
    private int waveNum = 0;
    private ObjectSpawner spawner;

    private void Awake()
    {
        spawner = GetComponentInChildren<ObjectSpawner>();
    }

    private void Start()
    {
        spawner.SpawnObjects();
    }

    public int WaveNum { get { return waveNum; } }

    public void NextWave()
    {
        waveNum++;
        spawner.SpawnObjects();
    }
}
