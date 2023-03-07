using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        Driver d = GetComponent<Driver>();
        if (other.gameObject.CompareTag("Boost"))
        {

            if (d.moveSpeed < d.defaultMoveSpeed) {
                d.moveSpeed = d.defaultMoveSpeed;
                d.steerSpeed = d.defaultSteerSpeed;
            } else {
            d.moveSpeed += d.moveSpeedBoost;
            d.steerSpeed += d.steerSpeedBoost;
            d.boostTimer = d.boostLength;
            }
            
            Destroy(other.gameObject, 0);
            GameObject.FindGameObjectWithTag("SpawnLogic").GetComponent<SpawnLogic>().SpawnBoost(); //spawn new thing
            GetComponent<AudioSource>().PlayOneShot(d.boostSound);
            return;
        }
        
        else if (!other.gameObject.CompareTag("Package"))
        { // this will eventually be handled by the boost cancel code
            d.moveSpeed = d.slowSpeed;
            d.steerSpeed = d.slowSteerSpeed;
            d.boostTimer = d.bumpSlowTime;

            GetComponent<Delivery>().packages = 0;
            this.GetComponent<SpriteRenderer>().color = GetComponent<Delivery>().defaultcolor;

            GetComponent<AudioSource>().PlayOneShot(d.bumpSound);
            d.boostParticles.Stop();
        }


    }
}
