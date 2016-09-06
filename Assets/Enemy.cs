using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float enemySpeed = 2.0f;

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, this.GetComponent<Rigidbody2D>().velocity.y);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Collider2D zhuang = Physics2D.OverlapPoint(this.transform.Find("frontCheck").position, 1 << LayerMask.NameToLayer("wall"));
        if (zhuang != null)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);

        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed * Mathf.Sign(this.transform.localScale.x), this.GetComponent<Rigidbody2D>().velocity.y);
        print(this.transform.position);
 
    }
}
