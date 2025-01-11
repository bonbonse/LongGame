using Core.Managers;
using Core.Managers.GameObjectManagers;
using Unity.VisualScripting;
using UnityEngine;

namespace Interaction
{
    public class PlayingBody : InteractionObject
    {
        public override void Use()
        {
            LeaveBody();
            EnterToBody();
        }
        // Метод выхода из текущего тела
        private void LeaveBody()
        {
            // Удаляет камеру игроку
            RemovePlayerCamera();
            // Убрать скрипт у действующего тела
            RemovePlayerScriptsFromCharacter();
            // Добавить этому телу скрипт InteractionObject
            // Добавить Mark
        }
        // Метод входа в новое тело
        private void EnterToBody()
        {
            // Дать этому объекту скрипт Player и PlayerBehavior
            AddPlayerScriptsOnCharacter();
            // Добавить объекту камеру
            AddCamera();
            // Удалить у тела скрипт InteractionObject
            RemoveInteractionObjectScript();
            // Удалить Mark
        }
        private void RemovePlayerScriptsFromCharacter()
        {
            Player.Player player = GameObjectManager.GetPlayer();
            if (player != null) 
            {
                Destroy(player.GetComponent<Player.PlayerBehaviourHandler>());
                Destroy(player);
            }
        }
        private void AddPlayerScriptsOnCharacter()
        {
            Player.Player newPlayer = gameObject.AddComponent<Player.Player>();
            gameObject.AddComponent<Player.PlayerBehaviourHandler>();

            GameObjectManager.SetPlayer(newPlayer);
        }
        // Удаляет скрипт PlayingBody с объекта
        private void RemoveInteractionObjectScript()
        {
            Destroy(this);
        }
        // Добавляет новую камеру объекту
        private void AddCamera()
        {
            Vector3 camPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Quaternion camRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            GameObject rotaterCamera = Instantiate(
                    PrefabsManager.GetRotaterCamera(), 
                    camPosition, 
                    camRotation, 
                    transform
            );
            Player.Player player = GameObjectManager.GetPlayer();
            player.SetRotaterCamera(rotaterCamera);
        }
        // Удаление камеры у Player
        private void RemovePlayerCamera()
        {
            Destroy(GameObjectManager.GetMainCamera());
        }
    }
}

