using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterCubeLife : MonoBehaviour
{
    [SerializeField] private List<Grass> _grasses;
    [SerializeField] private Painter _painter;

    public event Action<Cube> Destroyed;

    private void OnEnable()
    {
        foreach (Grass grass in _grasses)
        {
            grass.Bumped += ComeEndOfLife;
        }
    }

    private void OnDisable()
    {
        foreach (Grass grass in _grasses)
        {
            grass.Bumped -= ComeEndOfLife;
        }
    }

    public void ComeEndOfLife(Cube cube)
    {
        if (cube.isChangeColor == false)
        {
            _painter.ChangeColor(cube);
            StartCoroutine(Countdown(cube));
        }
    }

    private IEnumerator Countdown(Cube cube)
    {
        yield return new WaitForSeconds(cube.LifeTime);

        Destroyed?.Invoke(cube);
    }
}
