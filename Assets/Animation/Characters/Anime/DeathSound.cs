using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : StateMachineBehaviour
{
    public AudioClip deathSound;
    private Health health;
    private AudioSource audio;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
        health = animator.gameObject.GetComponent<Character>().health;
        health.Death += OnDeath;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        health.Death -= OnDeath;
    }

    private void OnDeath()
    {
        Debug.Log("DeathSound");
        audio.PlayOneShot(deathSound);
    }
}
