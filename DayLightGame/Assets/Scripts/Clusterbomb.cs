using UnityEngine;

public class Clusterbomb : ExplosiveArrow
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        //damage *= 0.5f
        //Mathf.roundToInt

        //Do explosion
        RaycastHit2D[] Hit = Physics2D.CircleCastAll(transform.position, (blastRadius / 2), Vector2.zero);

        foreach (RaycastHit2D ray in Hit)
        {
            //Apply explosive damage
        }

        //Do sick ass explosions

        Destroy(gameObject);
    }
}
