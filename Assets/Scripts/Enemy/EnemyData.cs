using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "new EnemyData", menuName = "EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float attack;

        public float Health => health;
        public float Attack => attack;
    }
}