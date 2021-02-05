using Gestures;

namespace Interfaces {
    public interface IGestureChecker {
        void InitGestureData(OVRHand leftHandData, OVRHand rightHandData);
        bool GetPinchGesture(OVRHand.Hand hand, OVRHand.HandFinger finger);
        float GetCustomGestureDistance(OVRHand.Hand hand, CustomGestures gesture);
        bool GetCustomGesture(OVRHand.Hand hand, CustomGestures gesture);
        OVRSkeleton LeftHandSkeleton { get; }
        OVRSkeleton RightHandSkeleton { get; }
    }
}