using System;
using UnityEngine;

using Interaction;
using Core.Managers;
using Unity.Burst.CompilerServices;

namespace Mark
{
    public class Mark : MonoBehaviour
    {
        public InteractionObject interactionObject = null;
        public GameObject hint = null;
        // public GameObject hintText = null;

        private void Start()
        {
            hint = GameObjectManager.GetHint();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == Player.Player.GetTagName())
            {
                SetInteractionObjectToPlayer();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            Player.Player player = GameObjectManager.GetPlayer();
            if (!player.IsInteractionObjectSelected() && other.tag == Player.Player.GetTagName())
            {
                // Передать объект взаимодействия игроку
                SetInteractionObjectToPlayer();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == Player.Player.GetTagName())
            {
                ResetInteractionObjectToPlayer();
            }
        }
        // В Player.Player кладёт объект взаимодействия
        private void SetInteractionObjectToPlayer()
        {
            Player.Player player = GameObjectManager.GetPlayer();
            // Передать объект взаимодействия игроку
            player.SetInteractionObjectSelected(interactionObject);
            // Включить подсказку
            HintActiveOn();
        }
        // Сбросить значение выбранного предмета взаимодействия для игрока
        private void ResetInteractionObjectToPlayer()   
        {
            Player.Player player = GameObjectManager.GetPlayer();
            // Передать объект взаимодействия игроку
            player.SetInteractionObjectSelected(null);
            // Выключить подсказку
            HintActiveOff();
        }
        // Включить подсказку
        private void HintActiveOn()
        {
            if (hint != null)
            {
                hint.SetActive(true);
            }
        }
        // Выключить подсказку
        private void HintActiveOff()
        {
            if (hint != null)
            {
                hint.SetActive(false);
            }
        }
    }
}

