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
    public GameObject player; 
    

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
        // direction = player.GetComponent<ThirdPersonMovement2>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        // Set the correct attack angle
        // angle = direction.getAngle();

        tf.eulerAngles = new Vector3(0, angle, 0);
        
    }

    public bool rangedAttack() {
        if (Time.time - meleeTime < meleeDelay || meleePrefab == null) return false;

        meleeTime = Time.time;
        GameObject meleeAttack = Instantiate(meleePrefab, tf);
        
        foreach (Item item in ItemList.itemList)
            item.onMeleeUse(player, meleeAttack);
        return true;
    }

    public bool meleeAttack() {
        if (Time.time - rangeTime < rangeDelay || rangePrefab == null) return false;

        rangeTime = Time.time;
        GameObject rangeAttack = Instantiate(rangePrefab, tf);
        foreach (Item item in ItemList.itemList)
            item.onRangeUse(player, rangeAttack);
        return true;
        
    }
}
