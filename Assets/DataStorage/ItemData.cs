using UnityEngine;

namespace DataStorage
{
    public class ItemData
    {
        public readonly string name;
        public readonly string description;
        public readonly RenderTexture image;

        public ItemData(string name, string description, RenderTexture image)
        {
            this.name = name;
            this.description = description;
            this.image = image;
        }
    }
}
