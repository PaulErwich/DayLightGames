using UnityEditor.Rendering.Universal;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    //Jay

    [Header("Transform")]
    public Transform player;
    public Transform bow;
    public GameObject[] arrow;
    EvolveType evolve;

    [Header("Variables")]
    private float chargedTime;
    private float requiredCharge;
    public float bowAtkSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chargedTime = 0;
        evolve = EvolveType.Default;
        player = transform.parent.transform;
    }

    private void Awake()
    {
        requiredCharge = 1 * bowAtkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for right click hold to charge bow
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Charges the bow to shoot
            chargedTime += 0.5f * Time.deltaTime;
        }

        //If the bow has been charged shoots
        if (Input.GetKeyUp(KeyCode.Mouse1) && chargedTime >= requiredCharge)
        {
            //Resets charge
            chargedTime = 0;

            //Instantiate and shoot arrow
            GameObject instantiatedArrow = Instantiate(arrow[(int)evolve], bow.position, player.rotation);
            instantiatedArrow.SetActive(true);
        }

        //If the bow has not been charged doesnt shoot
        else if (Input.GetKeyUp(KeyCode.Mouse1) && chargedTime < requiredCharge)
        {
            //Returns charge to zero
            chargedTime = 0;
        }
    }
}
public enum EvolveType
{
    Default = 0,
    Ice = 1,
    Fire = 2,
    Electric = 3,
    Explosive = 4,
    Multishot = 5,
    Crossbow = 6
}
