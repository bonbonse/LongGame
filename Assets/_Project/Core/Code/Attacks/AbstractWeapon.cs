using UnityEngine;

namespace Attacks
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField]
        protected ScriptableObjects.Weapons.Weapon weapon;
        protected virtual AttackTypes AttackType { get; }
        public abstract void Attach();
    }
}

