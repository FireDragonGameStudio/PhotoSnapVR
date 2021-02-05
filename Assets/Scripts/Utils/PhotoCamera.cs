using UnityEngine;

namespace Utils {
    [RequireComponent(typeof(Camera))]
    public class PhotoCamera : MonoBehaviour {

        [SerializeField]
        private Camera photoCamera;
        [SerializeField]
        private PhotoAlbum photoAlbum;

        private void Start() {
            if (!photoCamera) {
                photoCamera = GetComponent<Camera>();
            }
        }

        public void TakePicture() {
            Texture2D photoCameraTexture = CreatePhotoCameraTexture();
            photoAlbum.SaveNewPhotoInAlbum(photoCameraTexture);
        }

        private Texture2D CreatePhotoCameraTexture() {
            RenderTexture rt = photoCamera.targetTexture;

            RenderTexture.active = rt;
            Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGBAFloat, false);
            tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            tex.Apply();
            RenderTexture.active = null;

            return tex;
        }
    }
}