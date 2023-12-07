using Microsoft.VisualStudio.TestTools.UnitTesting;
using SVM.SimpleMachineLanguage;
using Moq;
using SVM.VirtualMachine;
using System.Collections;

namespace SVM.UnitTests
{
    public class IncrTests
    {
        [TestMethod]
        public void Incr_ShouldIncrementTopValue()
        {
            // Arrange
            var mockVM = new Mock<IVirtualMachine>();
            var stack = new Stack();
            stack.Push(1); 
            mockVM.Setup(vm => vm.Stack).Returns(stack); 

            var incr = new Incr();
            incr.VirtualMachine = mockVM.Object; 

            // Act
            incr.Run(); 

            // Assert
            Assert.AreEqual(2, stack.Peek()); 
        }
    }
}
    [TestClass]
    public class DecrTests
    {
    [TestMethod]
    public void Decr_ShouldDecrementTopValue()
    {
        // Arrange
        var mockVM = new Mock<IVirtualMachine>();
        var stack = new Stack();
        stack.Push(2); 
        mockVM.Setup(vm => vm.Stack).Returns(stack); 

        var decr = new Decr();
        decr.VirtualMachine = mockVM.Object; 

        // Act
        decr.Run(); 

        // Assert
        Assert.AreEqual(1, stack.Peek()); 
    }
}
    

