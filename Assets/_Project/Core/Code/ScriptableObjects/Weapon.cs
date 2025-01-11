using UnityEngine;
using Attacks;

namespace ScriptableObjects.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
    public class Weapon : ScriptableObject
    {
        public string Name = "������";
        public string Description = "";
        public float Distance = 0;
        public float Damage = 0;
        public float Cooldown = 0;
        public GameObject Whizzbang = null; // ������ ��� ������������ ����
        public Sprite Icon = null; // ������ ��� ����������� � ����������
    }
}

