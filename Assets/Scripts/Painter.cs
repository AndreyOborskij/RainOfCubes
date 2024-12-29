using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private Material _standartColor;
    [SerializeField] private CounterCubeLife _counterCubeLife;

    private bool _isChangeColor = false;

    private void OnEnable()
    {
        _counterCubeLife.Destroyed += ResetChanges;
    }

    private void OnDisable()
    {
        _counterCubeLife.Destroyed += ResetChanges;
    }

    public bool IsChangeColor => _isChangeColor;

    public void ChangeColor(Cube cube)
    {
        Color color = Random.ColorHSV();

        cube.SetColor(color);

        cube.CanChangeColor(true);
    }

    public void ResetChanges(Cube cube)
    {
        cube.SetColor(_standartColor.color);

        cube.CanChangeColor(false);
    }
}