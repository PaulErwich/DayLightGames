using UnityEngine;

public class DefaultArrow : ArrowScript
{
    //Jay

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys the arrow on collision
        Destroy(gameObject);
    }
}
