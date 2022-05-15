using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    // keep track of the jumping state ... 
    bool isJumping = false;
    bool isPlaying = false;
    int random = 0;
    // make sure to keep track of the movement as well !

    Rigidbody2D rb; // note the "2D" prefix 
    AudioSource[] allSources;

    AudioSource jump;
    AudioSource land;
    AudioSource crouch;
    AudioSource run;
    AudioSource cherry;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        allSources = GetComponents<AudioSource>();

        jump = allSources[0];
        land = allSources[1];
        crouch = allSources[2];
        run = allSources[3];

        cherry = allSources[4];
        // get the references to your audio sources here !        
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
        // Use the ridgidbody instance to find out if the fox is
        // moving, and play the respective sound !
        // Make sure to trigger the movement sound only when
        // the movement begins ...

        // Use a magnitude threshold of 1 to detect whether the
        // fox is moving or not !
        // i.e.

        if (rb.velocity.magnitude >= 1 && !isJumping && !isPlaying)
        {
            run.Play();
            isPlaying = true;
        }
        else if (rb.velocity.magnitude < 1 && isPlaying || isJumping && isPlaying)
        {
            run.Stop();
            isPlaying = false;
        }
    }

    // trigger your landing sound here !
    public void OnLanding()
    {
        random = Random.Range(0, 100);
        if (random > 50)
        {
            land.pitch = 2;
        }
        else
        {
            land.pitch = 1;
        }
        isJumping = false;
        land.Play();
        print("the fox has landed");
        // to keep things cleaner, you might want to
        // play this sound only when the fox actually jumped ...
    }

    // trigger your crouching sound here
    public void OnCrouching()
    {
        crouch.Play();
        print("the fox is crouching");
    }

    // trigger your jumping sound here !
    public void OnJump()
    {
        random = Random.Range(0, 100);
        if (random > 50)
        {
            jump.pitch = 2;
        }
        else
        {
            jump.pitch = 1;
        }
        isJumping = true;
        jump.Play();
        print("the fox has jumped");
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect()
    {
        cherry.Play();
        print("the fox has collected a cherry");
    }
}
