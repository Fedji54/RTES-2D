using UnityEngine;

namespace WinterUniverse
{
    public class PlayerCameraController : MonoBehaviour
    {
        private PlayerController _player;

        [SerializeField] private Vector3 _offset;

        private void Start()
        {
            _player = FindFirstObjectByType<PlayerController>();
        }

        private void LateUpdate()
        {
            if (_player != null)
            {
                transform.position = _player.transform.position + _offset;
            }
        }
    }
}