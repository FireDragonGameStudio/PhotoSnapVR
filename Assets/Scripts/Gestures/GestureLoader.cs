using Interfaces;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Gestures {
    public class GestureLoader : MonoBehaviour {

        private const string leftHandGestureFileName = "LeftHandGestures.json";
        private const string rightHandGestureFileName = "RightHandGestures.json";

        private bool reloadGestureData = false;

        private List<GestureData> leftHandGestures = new List<GestureData>();
        private List<GestureData> rightHandGestures = new List<GestureData>();

        private IGestureInterpreter gestureInterpreter;

        private void Awake() {
            if (reloadGestureData) {
                LoadGesturesFromFile();
            }
        }

        private void LoadGesturesFromFile() {
            leftHandGestures = LoadHandGesturesFromFile(leftHandGestureFileName);
            rightHandGestures = LoadHandGesturesFromFile(rightHandGestureFileName);
        }

        private List<GestureData> LoadHandGesturesFromFile(string fileName) {
            string filePath = Path.GetFullPath(Path.Combine(Application.streamingAssetsPath, fileName));
            if (File.Exists(filePath)) {
                using (StreamReader reader = new StreamReader(filePath)) {
                    return JsonUtility.FromJson<GestureDataWrapper>(reader.ReadToEnd()).gestureData;
                }
            }
            return new List<GestureData>();
        }
    }
}