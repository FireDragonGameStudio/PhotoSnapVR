using UnityEngine;
using Zinnia.Action;
using Zinnia.Process;

namespace Actions {
    public class InvertBoolAction : BooleanAction, IProcessable {

        [SerializeField]
        private BooleanAction boolAction;

        public void Process() {
            Receive(!boolAction.Value);
        }
    }
}