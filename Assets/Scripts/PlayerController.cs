using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float radius;
    private Vector2 pos;
	public bool canMove;

    void Update()
    {
        if (!canMove)
        {
            return;
        }
        Movement();
        NoRotate();
        Interact();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void NoRotate()
    {
        if (transform.rotation.x != 0 || transform.rotation.y != 0 || transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    Collider2D CheckIfCloseEnough()
    {
        return Physics2D.OverlapCircle(pos, radius);
    }

    void Interact()
    {
        pos = transform.position;
        Debug.Log(pos);
        Collider2D close = CheckIfCloseEnough();
        if (Input.GetKey(KeyCode.Space) && close != null)
        {
            float dot = close.transform.position.x * transform.forward.x + close.transform.position.y * transform.forward.y;
            if (dot >= 0)
            {
                Debug.Log("OOOOOUUUUUUAAAAAAIIIIIISSSSSS");
                //close.gameObject.GetComponent<InteractiveObject>.Interact();
            }
        }
    }
}
