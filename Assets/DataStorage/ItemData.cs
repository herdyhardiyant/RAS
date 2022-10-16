using System;
using System.Globalization;
using UnityEngine;

namespace DataStorage
{
    public class ItemData
    {
        public readonly string ID;
        public readonly string Name;
        public readonly string Description;
        public readonly RenderTexture Image;
        public readonly GameObject ItemObjectReference;

        public ItemData(string id, string name, string description, RenderTexture image, GameObject itemObjectReference)
        {
            this.ID = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.ItemObjectReference = itemObjectReference;
        }
    }
}