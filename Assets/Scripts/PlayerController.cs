using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float radius;
    private Vector2 pos;
	public bool canMove = true;
	private int goodness;
    private int nbPassenger;
    private int nbTalk;

    private Rigidbody2D rb;

    private Animator anim;
    private Camera cam;

    private bool collide = false;
    
    void Start()
    {	
		goodness = 0;
        nbTalk = 0;
        nbPassenger = 0;
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
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
            else if (Input.GetKey(KeyCode.DownArrow))
		{
            anim.SetBool("inputRight", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputDown", true);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
		{
            anim.SetBool("inputRight", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputLeft", true);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
		{
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputRight", true);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
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
        nbPassenger ++;
		goodness += good;
	}
	public int getGood(){
		return goodness;
	}
    public int getPassenger()
    {
        return nbPassenger;
    }

    public void addTalk()
    {
        nbTalk++;
    }
    public int getTalk()
    {
        return nbTalk;
    }
}
