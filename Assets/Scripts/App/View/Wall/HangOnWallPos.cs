using System;
using System.Collections;
using System.Collections.Generic;
using App.View;
using UnityEngine;

public class HangOnWallPos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("Player"))
        // {
        //     Player player = other.GetComponent<Player>();
        //     player.StateMachine.ChangeState(player.StateMachine.HangOnWallState);
        // }
    }
}
