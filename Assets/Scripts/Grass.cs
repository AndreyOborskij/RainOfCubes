using System;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public event Action<Cube> Bumped;

    private void OnCollisionEnter(Collision collision)
    {
        Cube cube = collision.gameObject.GetComponent<Cube>();

        Bumped?.Invoke(cube);
    }
}
