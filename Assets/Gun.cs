using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public GameObject o_bullet;
    public float oSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            float b =  Mathf.Sign( GameObject.Find("Hero").transform.localScale.x );
            GameObject o = (GameObject)Instantiate(o_bullet, this.transform.position,Quaternion.Euler(0,0,0));
            o.GetComponent<Rigidbody2D>().velocity = new Vector2(oSpeed * b, 0);
            o.transform.localScale =new Vector3( o.transform.localScale.x * b,o.transform.localScale.y,o.transform.localScale.z);

            this.GetComponent<AudioSource>().Play();

            GameObject hero = this.transform.parent.gameObject;
            hero.GetComponent<Animator>().SetTrigger("Shoot");
 
        }
	}
}
