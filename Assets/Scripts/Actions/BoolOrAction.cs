using UnityEngine;
using Zinnia.Action;
using Zinnia.Process;

namespace Actions {
    public class BoolOrAction : BooleanAction, IProcessable {

        [SerializeField]
        private BooleanAction firstBool;
        [SerializeField]
        private BooleanAction secondBool;

        public void Process() {
            Receive(firstBool.Value && secondBool.Value);
        }
    }
}