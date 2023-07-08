using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMake : MonoBehaviour
{   
    public float angle = 0;
    public float meleeDelay = 1f;
    public float rangeDelay = 1f;
    public GameObject meleePrefab; 
    public GameObject rangePrefab;
    public GameObject playerTransform;
    public ThirdPersonMovement2 player;
    

    private Transform tf;
    private float meleeTime;
    private float rangeTime;
    // private ThirdPersonMovement2 direction;
    

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.transform;
        meleeTime = -meleeDelay;
        rangeTime = -rangeDelay;
        player = playerTransform.GetComponent<ThirdPersonMovement2>();
        // direction = player.GetComponent<ThirdPersonMovement2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set the correct attack angle
        // angle = direction.getAngle();

        tf.eulerAngles = new Vector3(0, angle, 0);

        // Create the attack instance

        if (Time.time - meleeTime > meleeDelay && meleePrefab != null && Input.GetButtonDown("Melee")) {
            meleeTime = Time.time;
            GameObject meleeAttack = Instantiate(meleePrefab, tf);

            foreach (Item item in ItemList.itemList)
                item.OnMeleeUse(player, meleeAttack);
        }
    }

    public bool MeleeAttack() {
        if (Time.time - meleeTime < meleeDelay || meleePrefab == null) return false;

        meleeTime = Time.time;
        GameObject meleeAttack = Instantiate(meleePrefab, tf);
        foreach (Item item in ItemList.itemList)
            item.OnMeleeUse(player.GetComponent<ThirdPersonMovement2>(), meleeAttack);
        return true;
    }

    public bool RangedAttack() {
        if (Time.time - rangeTime < rangeDelay || rangePrefab == null) return false;

        rangeTime = Time.time;
        GameObject rangeAttack = Instantiate(rangePrefab, tf);
        foreach (Item item in ItemList.itemList)
            item.OnRangeUse(player.GetComponent<ThirdPersonMovement2>(), rangeAttack);
        return true;
    }
}
