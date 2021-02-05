using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utils {
    public class PhotoAlbum : MonoBehaviour {

        private const int MaxNumberOfPhotos = 9;
        private const int PhotoStartValue = -1;

        [SerializeField]
        private List<RawImage> albumImages = new List<RawImage>();
        [SerializeField]
        private Transform followTarget;
        [SerializeField]
        private float smoothTime = 0.3f;

        private Vector3 velocity = Vector3.zero;
        private int photoCounter = PhotoStartValue;
        private bool isFollowing = true;

        public void SaveNewPhotoInAlbum(Texture2D tex) {
            if (photoCounter == (MaxNumberOfPhotos - 1)) {
                photoCounter = PhotoStartValue;
            }
            photoCounter++;

            albumImages[photoCounter].texture = tex;
        }

        public void StartFollowing() {
            isFollowing = true;
        }

        public void StopFollowing() {
            isFollowing = false;
        }

        public void ResetPhotos() {
            for (int i = 0; i < albumImages.Count; i++) {
                albumImages[i].texture = null;
            }
            photoCounter = PhotoStartValue;
        }

        private void Update() {
            if (isFollowing) {
                Vector3 targetPosition = followTarget.TransformPoint(new Vector3(0, -0.5f, 1));
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
        }
    }
}