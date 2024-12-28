using UnityEngine;

public class PointSpawn : MonoBehaviour
{
    private Vector3 _spawnPosition;

    private void Awake()
    {
        _spawnPosition = transform.position;
    }

    public Vector3 SpawnPosition => _spawnPosition;
}
