using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _standartColor;

    private Renderer _renderer;
    private float _lifeTime;
    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private bool _isChangeColor = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public bool isChangeColor => _isChangeColor;
    public float LifeTime => _lifeTime;

    public void Init()
    {
        _lifeTime = Random.Range(_minLifeTime, _maxLifeTime + 1);        
    }

    public void SetColor(Color color)
    {
        if (_renderer != null)
        {
            _renderer.material.color = color;
        }
    }

    public void CanChangeColor(bool canChange)
    {
        _isChangeColor = canChange;
    }
}
