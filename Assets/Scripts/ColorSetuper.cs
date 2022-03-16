using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public enum HairColor
    { 
        Brown,
        Blonde
    }

    public enum Gender
    {
        Male,
        Female
    }
    
    public class ColorSetuper : MonoBehaviour
    {
        private Material _hairMaterial;
        private List<Texture> _textures;
        private void Start()
        {
            var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
            var textures = directoryInfo.GetFiles("*.*");
            _textures = new List<Texture>();

            foreach (var texture in textures)
            {
                if (texture.Name.Contains("meta"))
                {
                    continue;
                }

                var bytes = File.ReadAllBytes(texture.FullName);
                var texture2D = new Texture2D(1, 1);

                texture2D.LoadImage(bytes);
                texture2D.name = texture.Name;
                _textures.Add(texture2D);
                
            }
        }

        private Texture GetTextureByName(string name)
        {
            return _textures.Find(t => t.name == name);
        }

        public Texture GetHairTexture(HairColor hairColor, Gender gender)
        {
            if (gender == Gender.Female)
            {
                return GetTextureByName(hairColor == HairColor.Brown ? "Female_Hair.png" : "Female_Hair_Blonde.png");
            }
            return GetTextureByName(hairColor == HairColor.Brown ? "Male_Hair.png" : "Male_Hair_Blonde.png");
        }
    }
}