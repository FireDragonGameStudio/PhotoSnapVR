using UnityEngine;

namespace Utils {
    public class ToggleVisibility : MonoBehaviour {

        [SerializeField]
        private GameObject toggleObject;

        public void Toggle(bool changedValue) {
            if (changedValue) {
                toggleObject.SetActive(!toggleObject.activeInHierarchy);
            }
        }
    }
}