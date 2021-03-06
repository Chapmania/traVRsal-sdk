﻿using UnityEngine;

namespace traVRsal.SDK
{
    public class ReturnToPosition : MonoBehaviour
    {
        public float speed = 10f;
        public bool resetLayer = false;

        private Vector3 originalPosition;
        private Quaternion originalRotation;
        private int originalLayer;
        private bool doReturn = false;

        void Start()
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation;
            originalLayer = gameObject.layer;
        }

        void Update()
        {
            if (doReturn)
            {
                transform.position = Vector3.Lerp(transform.position, originalPosition, speed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, speed * Time.deltaTime);

                float dist = Vector3.Distance(transform.position, originalPosition);

                // reached destination, snap to final transform position
                if (dist <= 0.002f)
                {
                    doReturn = false;
                    transform.position = originalPosition;
                    transform.rotation = originalRotation;
                }
            }
        }

        public void Trigger()
        {
            doReturn = true;
            if (resetLayer) gameObject.layer = originalLayer;
        }

        public void Stop()
        {
            doReturn = false;
        }
    }
}