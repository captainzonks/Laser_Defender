using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private int startingWave = 0;

    private void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (var i = startingWave; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (var i = 0; i < currentWave.GetNumberOfEnemies(); i++)
        {
            var newEnemy = Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWaypoints()[i].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWave);

            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }
}
