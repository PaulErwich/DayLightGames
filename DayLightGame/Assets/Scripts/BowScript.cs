using UnityEditor.Rendering.Universal;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    //Jay

    [Header("Transform")]
    public Transform player;
    public Transform bow;
    public GameObject[] arrow;
    EvolveTypeBow evolve;

    [Header("Variables")]
    private float cooldown;
    public float bowAtkSpeed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        evolve = EvolveTypeBow.Default;
        player = transform.parent.transform;
    }

    public void Shoot()
    {
        if (cooldown >= 1 / bowAtkSpeed)
        {
            GameObject instantiatedArrow = Instantiate(arrow[(int)evolve], bow.position, player.rotation);
            instantiatedArrow.SetActive(true);
            cooldown = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
    }

    public EvolveTypeBow GetEvolveType()
    {
        return evolve;
    }
}
public enum EvolveTypeBow
{
    Default = 0,
    Ice = 1,
    Fire = 2,
    Electric = 3,
    Explosive = 4,
    Multishot = 5,
    Crossbow = 6
}
