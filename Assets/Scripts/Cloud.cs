using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private float _repeatRate = 0.5f;
    private float _startTime = 0.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCubes), _startTime, _repeatRate);
    }

    public Vector3 DefinePosition()
    {
        int randomPoint = Random.Range(0, _spawnPoints.Count);

        return _spawnPoints[randomPoint].transform.position;
    }

    private void SpawnCubes()
    {
        _cubeSpawner.GetCube();
    }
}
