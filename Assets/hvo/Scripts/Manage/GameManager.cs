using System;
using UnityEngine;

namespace hvo.Scripts.Manage
{
    public class GameManager : SingletonManager<GameManager>
    {
        // 绑定的对象
        public Unit ActiveUnit;

        private Vector2 m_InitialTouchPosition;

        private void Update()
        {
            // 检测到点击则调用detectClick转换摄像机坐标和世界坐标并将坐标传给绑定对象
            Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;

            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                m_InitialTouchPosition = inputPosition;
            }

            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                if (Vector2.Distance(m_InitialTouchPosition, inputPosition) < 10)
                {
                    DetectClick(inputPosition);
                }
            }
        }

        bool HasClickedOnUnit(RaycastHit2D hit, out Unit unit)
        {
            Debug.Log("HasClickedUnit");
            if (hit.collider != null && hit.collider.TryGetComponent<Unit>(out var clickedUnit))
            {
                Debug.Log("On Clicked");
                unit = clickedUnit;
                return true;
            }

            unit = null;
            return false;
        }

        void DetectClick(Vector2 inputPosition)
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(inputPosition);
            Debug.Log($"worldPoint: {worldPoint}");
            // 解释这段代码的意思
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (HasClickedOnUnit(hit, out Unit unit))
            {
                HandleClickOnUnit(unit);
            }
            else
            {
                HandleClickOnGround(worldPoint);
            }
        }

        void HandleClickOnGround(Vector2 worldPoint)
        {
            ActiveUnit.MoveTo(worldPoint);
        }

        void HandleClickOnUnit(Unit unit)
        {
            SelectNewUnit(unit);
        }

        void SelectNewUnit(Unit unit)
        {
            ActiveUnit = unit;
            Debug.Log($"New Active Unit: {unit.gameObject.name}");
        }
    }
}