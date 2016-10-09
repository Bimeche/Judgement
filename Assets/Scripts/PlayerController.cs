using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float radius;
    private Vector2 pos;
	public bool canMove = true;
	int goodness;

    private Rigidbody2D rb;

    private Animator anim;
    private Camera cam;

    private bool collide = false;
    
    void Start()
    {	
		goodness = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = FindObjectOfType<Camera>();
    } 

    void Update()
    {
        if (!canMove)
        {
            return;
        }
        Movement();
        NoRotate();
        //if (Input.GetKey(KeyCode.Space){
        //	Interact();
        //}
        cam.transform.position = this.transform.position + new Vector3(0, 0, -10f);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("inputRight", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputUp", true);
            //Changer sprite
            /*if (!collide)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            } else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }*/
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            //rb.AddForce(Vector2.up * speed * Time.deltaTime);
            //rb.MovePosition(Vector2.up * speed * Time.deltaTime);

        }
            else if (Input.GetKey(KeyCode.DownArrow))
		{
            anim.SetBool("inputRight", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputDown", true);
            //Changer sprite
            /*if (!collide)
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }*/
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            //rb.AddForce(Vector2.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
		{
            anim.SetBool("inputRight", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputLeft", true);
            //Changer sprite
            /*if (!collide)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }*/
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
		{
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputRight", true);
            //Changer sprite
            /*if (!collide)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }*/
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //rb.AddForce(Vector2.right* speed * Time.deltaTime);
        } else
        {
            anim.SetBool("inputRight", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputUp", false);
        }
    }

    void NoRotate()
    {
        if (transform.rotation.x != 0 || transform.rotation.y != 0 || transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        collide = true;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        collide = false;
    }
	public void setGood(int good){
		goodness += good;
		Debug.Log (goodness);
	}
	public int getGood(){
		return goodness;
	}
    // void Interact()
    // {
    //     pos = transform.position;
    //     Debug.Log(pos);
    //     Collider2D[] close = CheckIfCloseEnough();
    //     if (close != null)
    //     {
    //int i = 0;
    //string tagOfClose;
    //while(i<close.Length && )
    //{

    //}
    //         //float dot = close.transform.position.x * transform.forward.x + close.transform.position.y * transform.forward.y;
    //         //if (dot >= 0)
    //         //{
    //             Debug.Log("OOOOOUUUUUUAAAAAAIIIIIISSSSSS");
    //             close.gameObject.GetComponent<InteractiveObject>().Interact();
    //         //}
    //     }
    // }
}
