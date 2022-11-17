using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData",menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10.0f;
    public float jumpUpModify = 0.95f;
    public float jumpVelocity = 8.0f;
    [Header("Check")]
    public LayerMask WhatIsGround;
    public float GroundCheckRadius = 0.4f;
    // public float 
}
