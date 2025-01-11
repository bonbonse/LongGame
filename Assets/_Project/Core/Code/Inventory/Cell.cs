using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class Cell : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private Vector3 originalPosition =Vector3.zero;
        private Vector3 startCursorPosition = Vector3.zero;
        private Transform parent = null;
        private RectTransform rectTransform = null;
        private void Start()
        {
            originalPosition = transform.localPosition;
            parent = this.transform.parent;
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Start");
            // Сохраняем исходный позицию объекта
            Vector3 originalPosition = rectTransform.localPosition;
            // transform.SetParent(null);
            gameObject.SetActive(true);
            startCursorPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("Drag");

            Vector3 dist = Camera.main.ScreenToWorldPoint(eventData.position);
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;
            rectTransform.localPosition = new Vector3(x, y, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Возвращаем объект на исходное место
            // transform.parent = this.parent;
            transform.localPosition = eventData.position;
            Debug.Log("End");
        }
    }
}
