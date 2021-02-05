using Gestures;
using Interfaces;
using System.ComponentModel.Design;
using UnityEngine;

namespace Services {
    public class ServiceLocator : MonoBehaviour {

        [SerializeField]
        private GestureChecker gestureChecker;

        private static ServiceContainer serviceContainer = new ServiceContainer();

        private void Awake() {
            serviceContainer.AddService(typeof(IGestureChecker), gestureChecker);
        }

        private void OnDestroy() {
            serviceContainer.Dispose();
        }

        public static T GetService<T>() {
            return (T)serviceContainer.GetService(typeof(T));
        }
    }
}