using PurrNet;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScrapMain : NetworkBehaviour
{

    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float minLifetime;
    [SerializeField] private float maxLifetime;
    [SerializeField] private float maxDeviation;

    [SerializeField] private Rigidbody rb;

    private float lifetime;

    

    protected override void OnSpawned()
    {
        base.OnSpawned();

        float deviation = Random.Range(-maxDeviation, maxDeviation);
        float speed = Random.Range(minSpeed, maxSpeed);
        lifetime = Random.Range(minLifetime, maxLifetime);

        transform.LookAt(new Vector3(0, transform.position.y, 0));
        transform.Rotate(new Vector3(0, deviation, 0));

        rb.linearVelocity = transform.forward * speed;

        StartCoroutine(Lifetime());
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
