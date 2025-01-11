using UnityEngine;

using Interaction;

using Attacks;
using Core.Managers;
using Core.Managers.GameObjectManagers;

namespace Player
{
    public class Player : MonoBehaviour
    {
        /** TAG_NAME - константное значение тега на игроке*/
        protected static string TAG_NAME = "Player";

        public float moveSpeed = 10f; // Скорость передвижения
        public float jumpForce = 5f; // Сила прыжка
        public float speedRotate = 25f;
        private float jumpRayDistance = 0.2f; // Расстояние до земли
        private Vector3 moveDirection = Vector3.zero; // Направление движения
        private Rigidbody rb;

        private InteractionObject selectedInteractionObject = null;

        [SerializeField]
        private GameObject cameraRotater;

        [SerializeField]
        private AbstractAttack weapon = null;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            transform.tag = TAG_NAME;
            Cursor.lockState = CursorLockMode.Locked;
        }
        // Возвращает имя тега
        public static string GetTagName()
        {
            return TAG_NAME;
        }
        // Метод для перемещения объекта
        public void Move()
        {
            rb.Move(moveDirection * moveSpeed * Time.deltaTime + transform.position, transform.rotation); // Установка скорости движения
        }
        // Задать направление движения
        public void SetMoveDirection(Vector3 direction)
        {
            moveDirection = direction;
        }
        public void SetMoveDirection(float x, float z)
        {
            // Вектор вперед относительно и игрока + вектор вправо
            moveDirection = transform.forward * x + (-transform.right * z);
            moveDirection *= -1;
        }
        // Получить направление движения
        public Vector3 GetMoveDirection()
        {
            return moveDirection;
        }

        // Прыжок
        public void Jump()
        {
            if (Physics.Raycast(transform.position, Vector3.down, jumpRayDistance))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Прыжок, если есть поверхность под объектом
            }
        }
        // Поворот камеры и персонажа
        public void RotateOnMouse()
        {
            RotateCameraX(Input.GetAxis("Mouse X"));
            RotateCameraY(Input.GetAxis("Mouse Y"));
        }
        private void RotateCameraX(float x)
        {
            transform.Rotate(
                new Vector3(0, x, 0) * Time.deltaTime * speedRotate
            );
        }
        private void RotateCameraY(float y)
        {
            cameraRotater.transform.Rotate(
                new Vector3(y, 0, 0) * Time.deltaTime * speedRotate
            );
        }
        
        public void SetInteractionObjectSelected(InteractionObject interactionObject)
        {
            selectedInteractionObject = interactionObject;
        }
        public bool IsInteractionObjectSelected()
        {
            return selectedInteractionObject != null;
        }
        // Использование объекта взаимодействия
        public void UseSelectedInteractionObject()
        {
            if (selectedInteractionObject != null)
            {
                selectedInteractionObject.Use();
            }
        }
        public void SetRotaterCamera(GameObject cameraRotater)
        {
            this.cameraRotater = cameraRotater;
        }
        public void Attach()
        {
            //Vector3 offset = new Vector3(transform.position.x + 1, transform.position.y + 0.5f, transform.position.z);
            //GameObject whizzbang = Instantiate(PrefabsManager.GetTestObject(), transform.position + transform.forward, transform.rotation);
            //whizzbang.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * 15, ForceMode.Impulse);
            weapon.Attach();
        }
        public void SetWeapon(AbstractAttack newWeapon)
        {
        }
    }
}

