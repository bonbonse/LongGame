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
        // ����� ������ �� �������� ����
        private void LeaveBody()
        {
            // ������� ������ ������
            RemovePlayerCamera();
            // ������ ������ � ������������ ����
            RemovePlayerScriptsFromCharacter();
            // �������� ����� ���� ������ InteractionObject
            // �������� Mark
        }
        // ����� ����� � ����� ����
        private void EnterToBody()
        {
            // ���� ����� ������� ������ Player � PlayerBehavior
            AddPlayerScriptsOnCharacter();
            // �������� ������� ������
            AddCamera();
            // ������� � ���� ������ InteractionObject
            RemoveInteractionObjectScript();
            // ������� Mark
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
        // ������� ������ PlayingBody � �������
        private void RemoveInteractionObjectScript()
        {
            Destroy(this);
        }
        // ��������� ����� ������ �������
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
        // �������� ������ � Player
        private void RemovePlayerCamera()
        {
            Destroy(GameObjectManager.GetMainCamera());
        }
    }
}

