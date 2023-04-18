using System.Globalization;
using TMPro;
using UnityEngine;

namespace Player
{
    public class ShowPlayerStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private Health _health;
        private void Start()
        {
            _health = GetComponent<Health>();
        }
        private void Update()
        {
            text.text = $"k:{PlayerController.Instance.EnemyCounter.ToString()} " + 
                        $"HP:{(_health.CurrentValueNormalized * 100).ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
