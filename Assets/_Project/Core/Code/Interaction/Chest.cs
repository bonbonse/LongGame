using UnityEngine;

namespace Interaction
{
    public class Chest : InteractionObject
    {
        [SerializeField]
        private bool isMimic = false;
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
        public override void Use()
        {
            Open();
        }
        private void Open()
        {
            // �������� ����������
            animator.SetTrigger("Opening");
        }
    }
}
