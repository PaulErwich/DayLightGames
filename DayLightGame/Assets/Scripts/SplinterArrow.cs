using UnityEngine;

public class SplinterArrow : MultishotArrow
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(10, 0));

        //damage = Multishot arrow / 3
        //Mathf.roundToInt
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys the arrow on collision
        Destroy(gameObject);
    }
}