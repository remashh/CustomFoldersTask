using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class CharacterInfo : ScriptableObject
    {
        [SerializeField] private string prefabName;
        

        public string PrefabName => prefabName;
    }
}