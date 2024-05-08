using UnityEngine;

[CreateAssetMenu(fileName = "RoundData", menuName = "ScriptableObjects/WaveRoundDataScriptableObject", order = 1)]
public class WaveRoundDataScriptableObject : ScriptableObject
{
    public int numOfAsteroids;
    public int numOfEnemies;
    public float asteroidCooldown;
    public float enemyCooldown;
}
