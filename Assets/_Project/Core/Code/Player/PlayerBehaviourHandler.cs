using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBehaviourHandler : MonoBehaviour
    {
        //Behaviours
        private Dictionary<Type, PlayerBehaviour> behavioursMap;
        private PlayerBehaviour behaviourCurrent;
        private Player player;
        private PlayerBehaviourHandler behaviourHandler;

        private void Start()
        {
            player = GetComponent<Player>();
            behaviourHandler = GetComponent<PlayerBehaviourHandler>();

            InitBehaviours();
            SetBehaviourByDefault();
        }
        private void InitBehaviours()
        {
            behavioursMap = new Dictionary<Type, PlayerBehaviour>();

            behavioursMap[typeof(PlayerBehaviourWalking)] = new PlayerBehaviourWalking();
            behavioursMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle();
        }
        private void Update()
        {
            if (behaviourCurrent != null)
                behaviourCurrent.Update();
        }
        private void FixedUpdate()
        {
            if (behaviourCurrent != null)
                behaviourCurrent.FixedUpdate();
        }

        private void SetBehaviour(PlayerBehaviour newBehaviour)
        {
            if (behaviourCurrent != null)
                behaviourCurrent.Exit();
            behaviourCurrent = newBehaviour;
            behaviourCurrent.player = player;
            behaviourCurrent.behaviourHandler = behaviourHandler;
            behaviourCurrent.Enter();
        }
        private void SetBehaviourByDefault()
        {
            var behaviourByDefault = GetBehaviour<PlayerBehaviourIdle>();
            SetBehaviour(behaviourByDefault);
        }

        private PlayerBehaviour GetBehaviour<T>() where T : PlayerBehaviour
        {
            var type = typeof(T);
            return behavioursMap[type];
        }

        public void SetBehaviourIdle()
        {
            var behaviour = GetBehaviour<PlayerBehaviourIdle>();
            SetBehaviour(behaviour);
        }
        public void SetBehaviourWalking()
        {
            var behaviour = GetBehaviour<PlayerBehaviourWalking>();
            SetBehaviour(behaviour);
        }
    }
}
