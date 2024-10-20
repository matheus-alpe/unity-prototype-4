using UnityEngine;

namespace Assets.Scripts
{
    class InputControl : MonoBehaviour
    {
        public float speed;

        public float Vertical
        {
            get => Input.GetAxis("Vertical");
        }

        public float Horizontal
        {
            get => Input.GetAxis("Horizontal");
        }

        public Vector3 Movement
        {
            get => new Vector3(Horizontal, 0, Vertical) * speed;
        }
    }
}
