using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //Jay

    [Header("Upgrades")]
    public bool bowSpecial1;
    public bool bowSpecial2;
    public bool enhance;
    public bool damageUp;

    [Header("Stats")]
    public float duration = 3;
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Awake()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.TransformDirection(new Vector2(0, 10));
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroys the arrow on collision
        if (collision.gameObject.tag == "Player" && CompareTag("playerArrow"))
        {
            return;
        }
        Destroy(gameObject);
    }
}
