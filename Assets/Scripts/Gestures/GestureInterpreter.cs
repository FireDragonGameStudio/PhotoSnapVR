using Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Gestures {
    public class GestureInterpreter : MonoBehaviour, IGestureInterpreter {

        [SerializeField]
        private float recognizeThreshold = 0.05f;
        [SerializeField]
        private List<GestureData> leftHandGestureData = new List<GestureData>();
        [SerializeField]
        private List<GestureData> rightHandGestureData = new List<GestureData>();

        public void SetHandGestureData(List<GestureData> leftGestureData, List<GestureData> rightGestureData) {
            leftHandGestureData = leftGestureData;
            rightHandGestureData = rightGestureData;
        }

        public bool CheckCustomGesture(OVRHand.Hand hand, OVRSkeleton handSkeleton, CustomGestures customGesture) {
            List<OVRBone> handFingerBones = new List<OVRBone>(handSkeleton.Bones);

            GestureData currentGesture;
            if (hand == OVRHand.Hand.HandLeft) {
                currentGesture = CheckGesture(handSkeleton, leftHandGestureData, handFingerBones, customGesture);
            } else {
                currentGesture = CheckGesture(handSkeleton, rightHandGestureData, handFingerBones, customGesture);
            }

            return !currentGesture.Name.Equals("");
        }

        private GestureData CheckGesture(OVRSkeleton handSkeleton, List<GestureData> gestureData, List<OVRBone> fingerBones, CustomGestures customGesture) {
            GestureData currentGesture = new GestureData();
            float currentMin = Mathf.Infinity;

            foreach (GestureData gesture in gestureData) {
                if (customGesture.ToString().ToLower().Equals(gesture.Name.ToLower())) {
                    float sumDistance = 0;
                    bool isDiscarded = fingerBones.Count <= 0;

                    for (int i = 0; i < fingerBones.Count; i++) {
                        Vector3 currentPosition = handSkeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                        float distance = Vector3.Distance(currentPosition, gesture.FingerData[i]);

                        if (distance > recognizeThreshold) {
                            isDiscarded = true;
                            break;
                        }

                        sumDistance += distance;
                    }

                    if (!isDiscarded && sumDistance < currentMin) {
                        currentMin = sumDistance;
                        currentGesture = gesture;
                    }
                }
            }

            return currentGesture;
        }

        public float CheckCustomGestureDistance(OVRHand.Hand hand, OVRSkeleton handSkeleton, CustomGestures customGesture) {
            return 0f;
        }
    }
}