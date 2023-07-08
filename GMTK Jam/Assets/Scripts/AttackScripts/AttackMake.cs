using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(GroundedPaperSprite))]
public class AttackMake : MonoBehaviour
{   
    public float angle = 0;
    public float meleeDelay = 1f;
    public float rangeDelay = 1f;
    public float meleeRange = 0f;
    public float rangedOffset = 0f;
    public GameObject meleePrefab; 
    public GameObject rangePrefab;
    public ThirdPersonMovement2 player;
    
    private float meleeTime;
    private float rangeTime;
    // private ThirdPersonMovement2 direction;
    

    // Start is called before the first frame update
    void Start()
    {
        meleeTime = -meleeDelay;
        rangeTime = -rangeDelay;
        // direction = player.GetComponent<ThirdPersonMovement2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the correct attack angle
        // angle = direction.getAngle();

        // Create the attack instance
    }

    public bool MeleeAttack() {
        if (Time.time - meleeTime < meleeDelay || meleePrefab == null) return false;

        meleeTime = Time.time;
        GameObject meleeAttack = Instantiate(meleePrefab,
            transform.position + GetComponent<GroundedPaperSprite>().facingDirection.normalized * meleeRange,
            Quaternion.LookRotation(GetComponent<GroundedPaperSprite>().facingDirection), transform);
        if (player != null)
        {
            foreach (Item item in ItemList.itemList)
                item.OnMeleeUse(player.GetComponent<ThirdPersonMovement2>(), meleeAttack);
        }
        return true;
    }

    public bool RangedAttack() {
        if (Time.time - rangeTime < rangeDelay || rangePrefab == null) return false;

        rangeTime = Time.time;
        GameObject rangeAttack = Instantiate(rangePrefab,
            transform.position + GetComponent<GroundedPaperSprite>().facingDirection.normalized * rangedOffset,
            Quaternion.LookRotation(GetComponent<GroundedPaperSprite>().facingDirection), transform);
        if (player != null)
        {
            foreach (Item item in ItemList.itemList)
                item.OnRangeUse(player.GetComponent<ThirdPersonMovement2>(), rangeAttack);
        }
        return true;
    }
}
