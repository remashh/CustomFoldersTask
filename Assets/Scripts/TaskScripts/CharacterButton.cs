using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharacterButton : MonoBehaviour

    {
        [SerializeField] private Button button;
        [SerializeField] private Text textLabel;

        public void Setup(string id, Action<string> callback)
        {
            textLabel.text = id;
            
            button.onClick.AddListener(delegate
            {
                callback?.Invoke(id);
            });
        }
    }
}