using UnityEngine;

namespace Attacks
{
    /**
     * ����������� ����� ��� ���� (������������, �������, ����� ������ � �.�.)
     * � ������� �������� ���������� �������������� Attach()
     */
    public abstract class AbstractAttack : MonoBehaviour
    {
        [SerializeField]
        protected ScriptableObjects.Weapons.Weapon weapon;
        public abstract void Attach();
    }
}

