using System.Collections;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Flooring _flooring;
    [SerializeField] private float _speedChange = 0.1f;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource.volume = 0.0f;
    }

    private void OnEnable()
    {
        _flooring.WasSteppedOn += TurnSiren;
        _flooring.LeftMe += TurnOffSiren;
    }

    private void OnDisable()
    {
        _flooring.WasSteppedOn -= TurnSiren;
        _flooring.LeftMe -= TurnOffSiren;
    }

    private void TurnSiren(Collider collider)
    {
        if (collider.GetComponent<Ñrook>())
        {
            if (_audioSource.isPlaying == false)
                _audioSource.Play();

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ChangingVolume(1.0f));
        }
    }

    private void TurnOffSiren(Collider collider)
    {
        if (collider.GetComponent<Ñrook>())
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangingVolume(0.0f));

            if (_audioSource.volume == 0.0f)
                _audioSource.Stop();
        }
    }

    private IEnumerator ChangingVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}
