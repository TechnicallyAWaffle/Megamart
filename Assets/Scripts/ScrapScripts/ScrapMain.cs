using PurrNet;
using Unity.VisualScripting;
using UnityEngine;

public class ScrapMain : NetworkBehaviour
{

    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxDeviation;

    [SerializeField] private Rigidbody rb;

    protected override void OnSpawned()
    {
        base.OnSpawned();

        float deviation = Random.Range(-maxDeviation, maxDeviation);
        float speed = Random.Range(minSpeed, maxSpeed);

        transform.LookAt(new Vector3(0, transform.position.y, 0));
        transform.Rotate(new Vector3(0, deviation, 0));

        rb.linearVelocity = transform.forward * speed;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
