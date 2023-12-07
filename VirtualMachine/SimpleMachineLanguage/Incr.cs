namespace SVM.SimpleMachineLanguage
{
    public class Incr : IInstruction
    {
        public IVirtualMachine VirtualMachine { get; set; }

        public void Run()
        {
            // Check if the stack is not empty
            if (VirtualMachine.Stack.Count == 0)
            {
                throw new SvmRuntimeException("Stack is empty. 'incr' instruction cannot be executed.");
            }

            var topItem = VirtualMachine.Stack.Pop();

            // Check if the top item is an integer
            if (!(topItem is int topValue))
            {
                throw new SvmRuntimeException("Top item on stack is not an integer. 'incr' instruction requires an integer.");
            }

            // Increment the value and push it back onto the stack
            VirtualMachine.Stack.Push(topValue + 1);
        }
    }
}
