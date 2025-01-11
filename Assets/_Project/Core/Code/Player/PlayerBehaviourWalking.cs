using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviourWalking : PlayerBehaviour
    {
        public override void Enter()
        {
        }
        public override void HandleUpdate()
        {
            base.HandleUpdate();
        }
        public override void LogicUpdate()
        {
            if (player.GetMoveDirection() == Vector3.zero)
            {
                behaviourHandler.SetBehaviourIdle();
            }
        }
        public override void PhysicalUpdate()
        {
            player.Move();
        }
        public override void Exit()
        {

        }
    }
}