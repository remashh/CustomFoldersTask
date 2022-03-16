using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourcesLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer baseSprite;
        [SerializeField] private Transform prefabRoot;

        [SerializeField] private string[] icons = new string[3];

        private GameObject currentPrefab;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetupIcon(icons[0]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetupIcon(icons[1]);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetupIcon(icons[2]);
            }
        }

        private void SetupIcon(string configName)
        {
            var config = Resources.Load<IconInfo>($"Configs/{configName}");
            var sprite = Resources.Load<Sprite>($"Icons/{config.IconName}");
            var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");

            baseSprite.sprite = sprite;

            if (currentPrefab != null)
            {
                Destroy(currentPrefab);
            }

            currentPrefab = Instantiate(prefab, prefabRoot);
        }
    }
}