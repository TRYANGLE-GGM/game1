using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Move")]

public class MovementSO : ScriptableObject
{
    public float speed; // ���ǵ� 

    public float accel, deAccel; // ���� ����
}
