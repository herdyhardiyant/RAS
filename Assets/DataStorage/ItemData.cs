using System;
using System.Globalization;
using UnityEngine;

namespace DataStorage
{
    public class ItemData
    {
        public readonly string id;
        public readonly string name;
        public readonly string description;
        public readonly RenderTexture image;
        public readonly GameObject prefab;

        public ItemData(string name, string description, RenderTexture image, GameObject prefab)
        {
            this.id = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            this.name = name;
            this.description = description;
            this.image = image;
            this.prefab = prefab;
        }
    }
}