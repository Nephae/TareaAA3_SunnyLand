using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateAudio : MonoBehaviour
{
    bool isPlaying = false;

    Rigidbody2D rb;

    AudioSource[] allSources;

    AudioSource crateMovement;
    AudioSource crateImpact;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        allSources = GetComponents<AudioSource>();

        crateMovement = allSources[0];
        crateImpact = allSources[1];
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude >= 1 && !isPlaying)
        {
            crateMovement.Play();
            isPlaying = true;
        }
        else if (rb.velocity.magnitude < 1 && isPlaying)
        {
            crateMovement.Stop();
            isPlaying = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        crateImpact.Play();
    }
}
