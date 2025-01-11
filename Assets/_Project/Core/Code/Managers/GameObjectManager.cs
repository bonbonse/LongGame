using Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Managers
{
    public class GameObjectManager : MonoBehaviour
    {
        public static GameObjectManager Instance = null;
        [SerializeField]
        private Player.Player player = null;
        [SerializeField]
        private GameObject hint = null; // Подсказка по типу "Нажмите E..."
        [SerializeField]
        private GameObject mainCamera = null;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            if (player == null)
            {
                player = FindFirstObjectByType<Player.Player>();
            }
            if (hint == null)
            {
                Debug.LogError("Hint is null");
            }
            if (mainCamera == null)
            {
                mainCamera = Camera.main.gameObject;
            }
        }
        public static Player.Player GetPlayer()
        {
            return Instance.player;
        }
        public static void SetPlayer(Player.Player newPlayer)
        {
            Instance.player = newPlayer;
        }
        public static GameObject GetHint()
        {
            return Instance.hint;
        }
        public static GameObject GetMainCamera() {
            GameObject result = Instance.mainCamera;
            if (result == null)
            {
                result = Camera.main.gameObject;
            }
            return result;
        }
    }
}

