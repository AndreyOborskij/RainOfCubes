using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Cloud _cloud;
    [SerializeField] private CounterCubeLife _counterLife;

    private ObjectPool<Cube> _cubesPool;

    private void Awake()
    {
        _cubesPool = new ObjectPool<Cube>(
            createFunc: () => CraeteCube(),
            actionOnGet: (cube) => ActionOnGet(cube),
            actionOnRelease: (cube) => ActionOnRelease(cube),
            collectionCheck: true
            );
    }

    private void OnEnable()
    {
        _counterLife.Destroyed += ReturnCube;
    }

    private void OnDisable()
    {
        _counterLife.Destroyed -= ReturnCube;
    }

    public void GetCube()
    {
        _cubesPool.Get();
    }

    public void ReturnCube(Cube cube)
    {
        _cubesPool.Release(cube);
    }

    private Cube CraeteCube()
    {
        var cube = Instantiate(_cubePrefab);
        cube.Init();
        return cube;
    }

    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = _cloud.DefinePosition();

        cube.gameObject.SetActive(true);
        cube.ResetChanges();
    }

    private void ActionOnRelease(Cube cube)
    {        
        cube.gameObject.SetActive(false);
    }
}
