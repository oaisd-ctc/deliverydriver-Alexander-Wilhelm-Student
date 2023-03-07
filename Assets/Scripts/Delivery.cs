using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] int maxPackages = 3;
    [System.NonSerialized] public int packages = 0; //dont serialize this

    [System.NonSerialized] public int totalDelivered = 0;



    [System.NonSerialized] public Color defaultcolor;
    [SerializeField] Gradient colorPalette;

    [SerializeField] AudioClip winSound;

    [SerializeField] GameObject SpawnPrefab;

    //[SerializeField] int InitialSpawnCount = 5;

    private float packageTimer; //protect from duplicate packages



    // Start is called before the first frame update
    void Start()
    {
        defaultcolor = this.GetComponent<SpriteRenderer>().color; //store default color for later
        SpriteRenderer sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        packageTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Package") && packages < maxPackages && packageTimer <= 0)
        {
            packages++;
            this.GetComponent<SpriteRenderer>().color = colorPalette.Evaluate(((float) packages) / ((float) maxPackages));
            Destroy(other.gameObject, 0);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<Driver>().pizzaSound);
            GameObject.FindGameObjectWithTag("SpawnLogic").GetComponent<SpawnLogic>().SpawnPackage(); //spawn new thing
            packageTimer = 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeliveryZone"))
        {
            if (packages > 0) {
                totalDelivered += packages;
                packages = 0;
                other.gameObject.GetComponent<ParticleSystem>().Play();
                this.GetComponent<AudioSource>().PlayOneShot(winSound);
                this.GetComponent<SpriteRenderer>().color = defaultcolor;
            }
        }
    }
}
