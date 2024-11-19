using UnityEditor.Rendering.Universal;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    //Jay

    [Header("Transform")]
    private Transform pivotPoint;
    public GameObject[] arrow;
    EvolveTypeBow evolve;

    [Header("Variables")]
    private float cooldown;
    public float bowAtkSpeed = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        evolve = EvolveTypeBow.Default;
        pivotPoint = Player.instance.pivotPoint.transform;
    }

    public void Shoot()
    {
        if (cooldown >= 1 / bowAtkSpeed)
        {
            GameObject instantiatedArrow = Instantiate(arrow[(int)evolve], pivotPoint.position, pivotPoint.rotation);
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
