using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    public bool driving = true;
    public float moveSpeed = 12f;
    public float moveSpeedBoost = 6f;

    public float slowSpeed = 6f;
    [System.NonSerialized] public float defaultMoveSpeed = 0f;
    public float steerSpeed = 150f;
    public float slowSteerSpeed = 75f;
    [System.NonSerialized] public float defaultSteerSpeed = 0f;
    public float steerSpeedBoost = 25f;
    public float boostLength = 5f;
    public ParticleSystem boostParticles;
    [System.NonSerialized] public float boostTimer = 0f;
    public AudioClip boostSound;
    public AudioClip pizzaSound;

    public float bumpSlowTime = 2f;
    public AudioClip bumpSound;



    // Start is called before the first frame update
    void Start()
    {
        defaultMoveSpeed = moveSpeed;
        defaultSteerSpeed = steerSpeed;
    }

    // fixedupdate to fix a stuttering issue
    void FixedUpdate()
    {   
        float dt = Time.fixedDeltaTime;
        if (driving) {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -steerSpeed * dt);
        transform.Translate(0, moveSpeed * Input.GetAxis("Vertical") * dt, 0);
        }

        if (boostTimer <= 0)
        {
            moveSpeed = defaultMoveSpeed;
            steerSpeed = defaultSteerSpeed;
            boostParticles.Stop();
        }
        else if (!boostParticles.isPlaying && moveSpeed > defaultMoveSpeed) boostParticles.Play(); //only play them if we're boosting

        boostTimer -= dt;
    }


}
