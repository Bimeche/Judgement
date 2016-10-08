using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float radius;
    private Vector2 pos;
	public bool canMove;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("inputUp",true);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputRight", false);
            //Changer sprite
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.DownArrow))
		{
            anim.SetBool("inputDown", true);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputRight", false);
            //Changer sprite
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.LeftArrow))
		{
            anim.SetBool("inputLeft", true);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputRight", false);
            //Changer sprite
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.RightArrow))
		{
            anim.SetBool("inputRight", true);
            anim.SetBool("inputUp", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputLeft", false);
            //Changer sprite
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } else {
            anim.SetBool("inputUp", false);
            anim.SetBool("inputDown", false);
            anim.SetBool("inputLeft", false);
            anim.SetBool("inputRight", false);
        }

    }

    void NoRotate()
    {
        if (transform.rotation.x != 0 || transform.rotation.y != 0 || transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
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
