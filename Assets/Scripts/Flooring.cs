using System;
using UnityEngine;

public class Flooring : MonoBehaviour
{
    public event Action<Collider> SomeoneEntered;
    public event Action<Collider> SomeoneCameOut;

    private void OnTriggerEnter(Collider other)
    {
        SomeoneEntered?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        SomeoneCameOut?.Invoke(other);
    }
}
