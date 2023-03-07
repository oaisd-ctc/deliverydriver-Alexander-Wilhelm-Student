using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOffset : MonoBehaviour
{

    public float randomRadius;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = this.transform.position;
        Vector2 randOffset = Random.insideUnitCircle;
        pos = new Vector2(pos.x + randOffset.x, pos.y + randOffset.y) * randomRadius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
