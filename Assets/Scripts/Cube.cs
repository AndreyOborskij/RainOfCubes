using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _standartColor;

    private Renderer _color;
    private float _lifeTime;
    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;
    private bool _isChangeColor = false;

    private void Awake()
    {
        _color = GetComponent<Renderer>();
    }

    public bool isChangeColor => _isChangeColor;
    public float LifeTime => _lifeTime;

    public void Init()
    {
        _lifeTime = Random.Range(_minLifeTime, _maxLifeTime + 1);        
    }

    public void ChangeColor()
    {
        Color color = Random.ColorHSV();

        _color.material.color = color;
        _isChangeColor = true;
    }

    public void ResetChanges()
    {
        _color.material.color = _standartColor.color;
        _isChangeColor = false;
    }
}
