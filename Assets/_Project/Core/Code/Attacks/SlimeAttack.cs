using System.Collections;
using Core.Managers.GameObjectManagers;
using UnityEngine;

namespace Attacks
{
    public class SlimeAttack : AbstractWeapon
    {
        private float acceleration = 1000f; // Ускорение снаряда при создании
        private float timeForRemove = 5f; // Время уничтожения снаряда
        public override void Attach()
        {
            Vector3 offset = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            GameObject whizzbang = Instantiate(PrefabsManager.GetTestObject(), transform.position + transform.forward, transform.rotation);
            whizzbang.GetComponent<Rigidbody>().AddForce(Vector3.forward * acceleration * Time.deltaTime, ForceMode.Impulse);
            StartCoroutine(RemoveWhizzbang(whizzbang));
        }
        IEnumerator RemoveWhizzbang(GameObject whizzbang)
        {
            yield return new WaitForSeconds(timeForRemove);
            Destroy(whizzbang);
        }
    }
}

