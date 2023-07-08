using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngle : MonoBehaviour
{
    public AttackMake maker;
    public ThirdPersonMovement2 movement;

    void Update() {
        maker.updateAngle(movement.getAngle());
    }
}
