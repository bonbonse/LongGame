using UnityEngine;

namespace Core.Managers.GameObjectManagers
{
    public class PrefabsManager : MonoBehaviour
    {
        public static PrefabsManager Instance = null;

        [SerializeField]
        private GameObject rotaterCamera;
        [SerializeField]
        private GameObject Test;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        public static GameObject GetRotaterCamera()
        {
            return Instance.rotaterCamera;
        }
        public static GameObject GetTestObject()
        {
            return Instance.Test;
        }

    }
}

