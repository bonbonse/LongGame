using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        protected List<Item> items = new List<Item>();
        protected int maxItemsCount = 6;

        /**
         * Добавляет предмет в инвентарь
         * @param Item newItem
         * @return bool
         */
        public bool Take(Item newItem)
        {
            int availableCellIndex = FindAvailableCell(newItem);
            if (availableCellIndex == -1)
            {
                return false;

            }
            AddItemInInventory(newItem, availableCellIndex);
            return true;
        }
        protected void AddItemInInventory(Item item, int index)
        {
            if (index > items.Count)
            {
                items.Add(item);
            } else
            {
                items[index].Count++;
            }
        }
        /**
         * Убирает предмет из инвенторя
         * 
         */
        public void Drop()
        {

        }
        /**
         * Находит индекс пустой или доступной ячейки для добавления предмета
         * @param Item newItem
         * @return int | -1 - если нет доступной ячейки вернет -1
         */
        protected int FindAvailableCell(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (item.Name == items[i].Name)
                {
                    if (items[i].Count < items[i].MaxCount)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}

