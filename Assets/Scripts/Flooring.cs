using System;
using UnityEngine;

public class Flooring : MonoBehaviour
{
    public event Action<Collider> WasSteppedOn;
    public event Action<Collider> LeftMe;

    private void OnTriggerEnter(Collider other)
    {
        WasSteppedOn?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        LeftMe?.Invoke(other);
    }
}
