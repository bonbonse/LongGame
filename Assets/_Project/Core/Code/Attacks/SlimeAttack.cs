using System.Collections;
using Core.Managers;
using Core.Managers.GameObjectManagers;
using UnityEngine;

namespace Attacks
{
    public class SlimeAttack : AbstractAttack
    {
        private float acceleration = 1000f; // ��������� ������� ��� ��������
        private float timeForRemove = 5f; // ����� ����������� �������
        public override void Attach()
        {
            Vector3 offset = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Transform transformCamera = GameObjectManager.GetMainCamera().transform;
            GameObject whizzbang = Instantiate(PrefabsManager.GetTestObject(), transform.position + transform.forward, transformCamera.rotation);
            whizzbang.GetComponent<Rigidbody>().AddForce(transformCamera.forward * acceleration * Time.deltaTime, ForceMode.Impulse);
            StartCoroutine(RemoveWhizzbang(whizzbang));
        }
        IEnumerator RemoveWhizzbang(GameObject whizzbang)
        {
            yield return new WaitForSeconds(timeForRemove);
            Destroy(whizzbang);
        }
    }
}

