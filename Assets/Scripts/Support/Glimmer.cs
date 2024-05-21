using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Glimmer : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        yield return new WaitForSeconds(RandomiseTimer());

        _animator.SetBool("Anim", true);

        yield return new WaitForSeconds(1f);

        _animator.SetBool("Anim", false);

        StartCoroutine(Anim());
    }

    private float RandomiseTimer()
    {
        float timer = Random.Range(3.0f, 7.0f);
        return timer;
    }
}
