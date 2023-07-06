using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int spawnTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
}
