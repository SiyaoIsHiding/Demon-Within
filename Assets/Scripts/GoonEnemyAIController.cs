using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonEnemyAIController : BaseEnemyAIController
{
    [Tooltip("A transform component that dictates where the hitbox will apear")]
    public Transform attackSocket;
    [Tooltip("How close the player has to be in order for the enemy to start throwing hands.")]
    public float attackRange;
    [Tooltip("How long should the hitbox stay active?")]
    public float attackHitboxDuration;
    [Tooltip("The delay in between the first hit and the two quick hits.")]
    public float firstHitDelay;
    [Tooltip("The delay in between hits during the two quick hits.")]
    public float comboHitDelay;
    [Tooltip("The delay in between looping back to the first hit after the combo.")]
    public float attackLoopDelay;
}
