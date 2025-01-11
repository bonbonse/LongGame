using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerBehaviour
    {
        public Player player;
        public PlayerBehaviourHandler behaviourHandler;

        public virtual void Enter()
        {

        }
        public virtual void Exit()
        {

        }
        public virtual void Update()
        {
            HandleUpdate();
            LogicUpdate();
        }
        public virtual void FixedUpdate()
        {
            PhysicalUpdate();
        }

        public virtual void LogicUpdate()
        {
        }
        public virtual void HandleUpdate()
        {
            player.SetMoveDirection(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetAxis("Jump") != 0)
            {
                player.Jump();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.UseSelectedInteractionObject();
            }
            if (Input.GetAxis("Fire1") != 0)
            {
                player.Attach();
            }
            player.RotateOnMouse();
        }
        public virtual void PhysicalUpdate()
        {
            
        }
    }
}