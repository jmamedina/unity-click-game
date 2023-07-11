using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 15;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawn = -3;

    //reference to game manager script
    private GameManager gameManager;

    //assign the points per prefab
    public int pointValue;

    //effect everytime we click the object
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();

        //reference to game manager script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive)
    //    {
    //        Destroy(gameObject);
    //        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    //        gameManager.UpdateScore(pointValue);
    //        if (gameObject.CompareTag("Bad"))
    //        {
    //            gameManager.UpdateLife(-1);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        if (gameObject.CompareTag("Bad"))
        {
            gameManager.UpdateLife(-1);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawn);
    }
}
