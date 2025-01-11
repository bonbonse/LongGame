using UnityEngine;

namespace Attacks
{
    /**
     * Абстрактный класс для атак (дальнобойная, близкая, атака слизня и т.п.)
     * В классах потомков необходимо переопределить Attach()
     */
    public abstract class AbstractAttack : MonoBehaviour
    {
        [SerializeField]
        protected ScriptableObjects.Weapons.Weapon weapon;
        public abstract void Attach();
    }
}

