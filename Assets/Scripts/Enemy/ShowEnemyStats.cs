using System.Globalization;
using TMPro;
using UnityEngine;

namespace Enemy
{
    public class ShowEnemyStats : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private Health _health;
        private void Start()
        {
            _health = GetComponent<Health>();
        }
        private void Update()
        {
            text.text = $"HP:{(_health.CurrentValueNormalized * 100).ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
