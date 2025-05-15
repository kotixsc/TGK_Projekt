using Unity.Properties;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private float speed = 3f;
    public int gold;
    private float hor, vert;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = rb.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        if (rb)
        {
            rb.linearVelocity = new Vector2(hor * speed, vert * speed);
        }
        if (hor < 0 && hor != 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else if(hor != 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("World2Tp"))
        {
            GameManager.instance.LoadWorld2();
        }
        if (collision.CompareTag("Coin"))
        {
            gold += 1;
            Destroy(collision.gameObject);
        }
    }
}
