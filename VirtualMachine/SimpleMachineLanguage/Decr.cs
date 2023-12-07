namespace SVM.SimpleMachineLanguage
{
    public class Decr : IInstruction
    {
        public IVirtualMachine VirtualMachine { get; set; }

        public void Run()
        {
            // Check if the stack is not empty
            if (VirtualMachine.Stack.Count == 0)
            {
                throw new SvmRuntimeException("Stack is empty. 'decr' instruction cannot be executed.");
            }

            var topItem = VirtualMachine.Stack.Pop();

            // Check if the top item is an integer
            if (!(topItem is int topValue))
            {
                throw new SvmRuntimeException("Top item on stack is not an integer. 'decr' instruction requires an integer.");
            }

            // Decrement the value and push it back onto the stack
            VirtualMachine.Stack.Push(topValue - 1);
        }
    }
}
