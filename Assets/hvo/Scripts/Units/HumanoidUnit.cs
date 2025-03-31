using System;
using UnityEngine;

namespace hvo.Scripts.Units
{
    public class HumanoidUnit : Unit
    {
        protected Vector2 m_Velocity;
        protected Vector3 m_LastVelocity;

        public float CurrentSpeed => m_Velocity.magnitude;

        private void Start()
        {
            m_LastVelocity = transform.position;
        }

        protected void Update()
        {
            m_Velocity = new Vector2(
                (transform.position.x - m_LastVelocity.x),
                (transform.position.y - m_LastVelocity.y)
            ) / Time.deltaTime;
            m_LastVelocity = transform.position;
            IsMoving = m_Velocity.magnitude > 0;
            m_Animator.SetFloat("Speed", Mathf.Clamp01(CurrentSpeed));
        }
    }
}