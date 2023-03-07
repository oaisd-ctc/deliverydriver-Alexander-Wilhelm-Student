using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject follow;
    public Vector3 offset;
    public Vector3 offset2; //HAAAAAAAAAAAAX!
    public float offsetDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform tf = follow.transform;
        float followAngle = Vector2.SignedAngle(tf.up, Vector2.up) * Mathf.Deg2Rad;
        offset = new Vector2((Mathf.Sin(followAngle)), Mathf.Cos(followAngle)) * offsetDistance;
        transform.position = follow.transform.position + offset + offset2;
        
    }
}
