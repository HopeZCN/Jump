using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float maxForce = 356;
    public float maxSpeed = 200;
    public float jumpForce = 500;
    private bool isJumping;
    private Vector3 lastMousePosition;
    private Vector3 mouseDownPosition;
    private Animator anim;

	// Use this for initialization
	void Start () {
        print("Hello,Unity");
        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
        //print("Hello,Update" + Time.deltaTime.ToString());
        Debug.DrawLine(this.transform.position,this.transform.FindChild("groundCheck").position);
	}
    void FixedUpdate()
    {
        //print("Hello,Update" + Time.deltaTime.ToString());
        float h = Input.GetAxis("Horizontal");
        //float j = Input.GetAxis("Vertical");

        //float h;
        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 dir = Input.mousePosition - lastMousePosition;
        //    h = dir.normalized.x;
        //}
        //else
        //{
        //    h = 0;
        //}
        lastMousePosition = Input.mousePosition;
        anim.SetFloat("Speed", Mathf.Abs(h));

        //print(h.ToString());
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();

        isJumping = !Physics2D.Linecast(this.transform.position, this.transform.FindChild("groundCheck").position, 1 << LayerMask.NameToLayer("ground"));
        if (!isJumping)
        {
            if (Mathf.Abs(body.velocity.x) <= maxSpeed)
            {
                body.AddForce(h * Vector2.right * maxForce);
                //body.AddForce(j * Vector2.up * maxForce);
            }

            if (Mathf.Abs(body.velocity.x) > maxSpeed)
            {
                body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * maxSpeed, body.velocity.y);
            }


        }
        if ((h > 0 && this.transform.localScale.x < 0) || (h < 0 && this.transform.localScale.x > 0))
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1.0f, this.transform.localScale.y, this.transform.localScale.z);
        }

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            body.AddForce(new Vector2(0, jumpForce));
        }





        //if (Input.GetMouseButtonDown(0))
        //{
        //    mouseDownPosition = Input.mousePosition;
        //}
        
        //if (!isJumping && Input.GetMouseButtonUp(0) && mouseDownPosition == Input.mousePosition)
        //{
        //    body.AddForce(new Vector2(0,jumpForce));
        //    anim.SetTrigger("Jump");

        //}
    }
}
