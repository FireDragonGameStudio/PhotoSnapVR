using Interfaces;
using UnityEngine;

namespace Gestures {
    public class GestureChecker : MonoBehaviour, IGestureChecker {

        [SerializeField]
        private OVRHand leftHand;
        [SerializeField]
        private OVRHand rightHand;

        private IGestureInterpreter gestureInterpreter;

        public OVRSkeleton LeftHandSkeleton { get; private set; }
        public OVRSkeleton RightHandSkeleton { get; private set; }

        private void Start() {
            if ((leftHand != null) && (rightHand != null)) {
                InitGestureData(leftHand, rightHand);
            }
            gestureInterpreter = GetComponent<IGestureInterpreter>();
        }

        public void InitGestureData(OVRHand leftHandData, OVRHand rightHandData) {
            leftHand = leftHandData;
            rightHand = rightHandData;

            LeftHandSkeleton = leftHandData.GetComponent<OVRSkeleton>();
            RightHandSkeleton = rightHandData.GetComponent<OVRSkeleton>();
        }

        public bool GetPinchGesture(OVRHand.Hand hand, OVRHand.HandFinger finger) {
            if ((leftHand == null) || (rightHand == null) ||
                leftHand.IsSystemGestureInProgress || rightHand.IsSystemGestureInProgress) {
                return false;
            }

            switch (hand) {
                case OVRHand.Hand.HandLeft:
                    return leftHand.GetFingerIsPinching(finger);
                case OVRHand.Hand.HandRight:
                    return rightHand.GetFingerIsPinching(finger);
            }
            return false;
        }

        public float GetCustomGestureDistance(OVRHand.Hand hand, CustomGestures gesture) {
            if (gestureInterpreter != null) {
                return gestureInterpreter.CheckCustomGestureDistance(hand, RightHandSkeleton, gesture);
            }
            return 0f;
        }

        public bool GetCustomGesture(OVRHand.Hand hand, CustomGestures gesture) {
            if (gestureInterpreter != null) {
                switch (hand) {
                    case OVRHand.Hand.HandLeft:
                        return gestureInterpreter.CheckCustomGesture(hand, LeftHandSkeleton, gesture);
                    case OVRHand.Hand.HandRight:
                        return gestureInterpreter.CheckCustomGesture(hand, RightHandSkeleton, gesture);
                }
            }
            return false;
        }
    }
}