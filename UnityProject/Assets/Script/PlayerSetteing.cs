using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSetteing : ScriptableObject {
    public float maxSpeed;      //  最高速度
    public float minSpeed;      //  最低速度
    public float acceleration;  //  加速度
    public float acceleSlope;   //  旋回速度
}
