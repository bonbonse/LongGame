using Core.Managers;
using UnityEngine;

namespace Interaction
{
    public abstract class InteractionObject : MonoBehaviour
    {
        [SerializeField]
        protected InteractionTypes interactionType;
        public virtual void Use() 
        {

        }
    }
}

