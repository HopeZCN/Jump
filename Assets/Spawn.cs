using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public float spawnEachTime = 4.0f;
    public GameObject oneEnemy;

	// Use this for initialization
	void Start () {
        this.InvokeRepeating("spawnEnemy", 1, spawnEachTime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnEnemy()
    {
        GameObject.Instantiate(oneEnemy, this.transform.position, Quaternion.identity);
    }
}
