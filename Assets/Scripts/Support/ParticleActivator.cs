using System.Collections;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    [SerializeField] private float _timeToActivate;
    [SerializeField] private ParticleSystem _particle;
    private bool _onPoint = false;
    private float alpha = 0;

    private void Update()
    {
        if (_onPoint)
        {
            StartCoroutine(ActivateParticle());
        }
        else
        {
            if (alpha >= 0)
            {
                StartCoroutine(DeactivateParticle());
            }
        }
    }

    public void ActicateParticleBool(bool activate)
    {
        _onPoint = activate;
    }

    private IEnumerator ActivateParticle()
    {
        var col = _particle.colorOverLifetime;
        while (alpha <= 0.7)
        {
            col.color = new Color(1, 1, 1, alpha);
            alpha += _timeToActivate * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator DeactivateParticle() 
    {
        var col = _particle.colorOverLifetime;
        while (alpha >= 0)
        {
            col.color = new Color(1, 1, 1, alpha);
            alpha -= _timeToActivate * Time.deltaTime;
            yield return null;
        }
    }
}
