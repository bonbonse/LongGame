using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
    public class PlayerBehaviourIdle : PlayerBehaviour
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
            if (player.GetMoveDirection() != Vector3.zero)
            {
                behaviourHandler.SetBehaviourWalking();
            }
        }
        public override void PhysicalUpdate()
        {
            base.PhysicalUpdate();
        }
        public override void Exit()
        {

        }
    }
}