using System.Collections;
using System.Collections.Generic;
using Lesson_6.Animals;
using UnityEngine;

namespace Lesson_6
{
    public class Player : MonoBehaviour
    {
        public FriendlyAnimal SelectedAnimal = null;
        public GameObject Arm, Wrist, Hand;

        private float _moveSpeed = 5.0f;
        private float _jumpForce = 500.0f;

        private bool _isGrounded = true;
        private float _mouseSensitivity = 100.0f;
        private float _verticalLookRotation;
        private Rigidbody _rb;

        private Vector3 _armStartScale;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _armStartScale = Arm.transform.localScale;
        }

        protected void Update()
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }

            if (Input.GetKey(KeyCode.P) && _isGrounded)
            {
                Arm.transform.localScale += new Vector3(0, 0.1f, 0);
                Arm.transform.localPosition += new Vector3(0, 0.0f, 0.1f);
            }
            else if (Arm.transform.localScale.y > _armStartScale.y)
            {
                Arm.transform.localScale -= new Vector3(0, 0.1f, 0);
                Arm.transform.localPosition -= new Vector3(0, 0.0f, 0.1f);
            }
            Hand.transform.position = Wrist.transform.position;
        }

        protected void FixedUpdate()
        {
            // Calculate movement vector based on player input
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput).normalized * _moveSpeed * Time.deltaTime;

            // Rotate player based on mouse input
            float horizontalLook = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            transform.Rotate(Vector3.up * horizontalLook);
            _verticalLookRotation -= Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
            _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90.0f, 90.0f);

            // Move player
            _rb.MovePosition(transform.position + transform.TransformDirection(movement));
        }

        protected void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("AnimalPenGround"))
            {
                _isGrounded = true;
            }
        }
    }
}