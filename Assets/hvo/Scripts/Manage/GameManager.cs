using System;
using UnityEngine;

namespace hvo.Scripts.Manage
{
    public class GameManager : SingletonManager<GameManager>
    {
        private void Update()
        {
            Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;
            Debug.Log(inputPosition);

            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
            }
        }
    }
}