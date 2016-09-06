using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {
    public GameObject partExplosion;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 2);


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);

        Quaternion q =  Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 359)));
        GameObject e = (GameObject) Instantiate(partExplosion, this.transform.position,q);
        Destroy(e, 0.333f);

        if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Hero").GetComponent<PlayerControl>().score += 10;

            GameObject.Find("Score").GetComponent<GUIText>().text = "Score:" + GameObject.Find("Hero").GetComponent<PlayerControl>().score;
        }

    }
}
