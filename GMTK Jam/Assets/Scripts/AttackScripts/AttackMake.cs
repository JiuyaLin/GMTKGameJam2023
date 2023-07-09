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
    
    private float meleeTime;
    private float rangeTime;
    // private ThirdPersonMovement2 direction;
    

    // Start is called before the first frame update
    void Start()
    {
        meleeTime = -meleeDelay;
        rangeTime = -rangeDelay;
        
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

        foreach (Item item in ItemList.itemList)
            item.OnMeleeUse(meleeAttack);
        
        return true;
    }

    public bool RangedAttack() {
        if (Time.time - rangeTime < rangeDelay || rangePrefab == null) return false;

        rangeTime = Time.time;
        GameObject rangeAttack = Instantiate(rangePrefab,
            transform.position + GetComponent<GroundedPaperSprite>().facingDirection.normalized * rangedOffset,
            Quaternion.LookRotation(GetComponent<GroundedPaperSprite>().facingDirection), transform);

        foreach (Item item in ItemList.itemList)
            item.OnRangeUse(rangeAttack);
        
        return true;
    }

    public bool MeleeAttackEnemy() {
        if (Time.time - meleeTime < meleeDelay || meleePrefab == null) return false;

        meleeTime = Time.time;
        GameObject meleeAttack = Instantiate(meleePrefab,
            transform.position + GetComponent<GroundedPaperSprite>().facingDirection.normalized * meleeRange,
            Quaternion.LookRotation(GetComponent<GroundedPaperSprite>().facingDirection), transform);

        meleeAttack.GetComponentInChildren<MeleeDamage>().isPlayer = false;
        return true;
    }

    public bool RangedAttackEnemey() {
        if (Time.time - rangeTime < rangeDelay || rangePrefab == null) return false;

        (FindAnyObjectByType(typeof(AudioSource)) as AudioSource).clip = (FindAnyObjectByType(typeof(SoundHolder)) as SoundHolder).enemyRanged;
        (FindAnyObjectByType(typeof(AudioSource)) as AudioSource).Play();
        rangeTime = Time.time;
        GameObject rangeAttack = Instantiate(rangePrefab,
            transform.position + GetComponent<GroundedPaperSprite>().facingDirection.normalized * rangedOffset,
            Quaternion.LookRotation(GetComponent<GroundedPaperSprite>().facingDirection), transform);

        rangeAttack.GetComponentInChildren<RangeDamage>().isPlayer = false;
        return true;
    }
}
