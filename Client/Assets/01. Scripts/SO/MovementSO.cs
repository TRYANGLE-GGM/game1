using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Move")]

public class MovementSO : ScriptableObject
{
    public float speed; // 스피드 

    public float accel, deAccel; // 가속 감속
}
