using UnityEngine;

namespace Utils {
    public class CameraPosition : MonoBehaviour {

        private const float HalfwayFactor = 0.5f;
        private const float MinimumDistance = 0.4f;

        [SerializeField]
        private Transform firstPoint;
        [SerializeField]
        private Transform secondPoint;
        [SerializeField]
        private Transform centerPoint;
        [SerializeField]
        private Transform photoCamera;
        [SerializeField]
        private Transform cameraPreview;

        private float scaleX = 0f;
        private float scaleY = 0f;
        private float scaleZ = 0f;

        private void Update() {
            PlaceCameraOnMedianPosition();
            CalculateCameraForwardBasedOnHead();
            SetCameraZoom();
        }

        private void PlaceCameraOnMedianPosition() {
            if (scaleX > MinimumDistance || scaleY > MinimumDistance || scaleZ > MinimumDistance) {
                photoCamera.position = Vector3.Lerp(firstPoint.position, secondPoint.position, HalfwayFactor) + photoCamera.forward * 3f;
            } else {
                photoCamera.position = Vector3.Lerp(firstPoint.position, secondPoint.position, HalfwayFactor);
            }
            cameraPreview.position = Vector3.Lerp(firstPoint.position, secondPoint.position, HalfwayFactor);
        }

        private void CalculateCameraForwardBasedOnHead() {
            photoCamera.forward = photoCamera.position - centerPoint.position;
            cameraPreview.forward = cameraPreview.position - centerPoint.position;
        }

        private void SetCameraZoom() {
            Vector3 p1 = firstPoint.position;
            Vector3 p2 = secondPoint.position;

            Vector3 scale = p1 - p2;
            scaleX = Mathf.Abs(scale.x);
            scaleY = Mathf.Abs(scale.y);
            scaleZ = Mathf.Abs(scale.z);
        }
    }
}