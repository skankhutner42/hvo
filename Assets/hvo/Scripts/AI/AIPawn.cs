using System;
using UnityEngine;

namespace hvo.Scripts.AI
{
    public class AIPawn : MonoBehaviour
    {
        [SerializeField] private float m_Speed = 5f;
        private Vector3? m_Destination;

        public Vector3? Destination => m_Destination;


        private void Start()
        {
            SetDestination(new Vector3(4.5f, 0, 0));
            Debug.Log("Start");
        }

        private void Update()
        {
            if (m_Destination.HasValue)
            {
                var dir = m_Destination.Value - transform.position;
                Debug.Log($"dir is:{dir.normalized}");
                transform.position += dir.normalized * (Time.deltaTime * m_Speed);
                Debug.Log($"transform.position is:{transform.position}");
            }
        }

        public void SetDestination(Vector3 destination)
        {
            m_Destination = destination;
        }
    }
}