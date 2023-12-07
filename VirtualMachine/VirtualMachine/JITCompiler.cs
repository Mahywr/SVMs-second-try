namespace SVM.VirtualMachine;

#region Using directives
using System.Reflection;
#endregion

/// <summary>
/// Utility class which generates compiles a textual representation
/// of an SML instruction into an executable instruction instance
/// </summary>
internal static class JITCompiler
{
    #region Constants
    #endregion

    #region Fields
    #endregion

    #region Constructors
    #endregion

    #region Properties
    #endregion

    #region Public methods
    #endregion

    #region Non-public methods
    internal static IInstruction CompileInstruction(string opcode)
    {
        Type instructionType = FindInstructionType(opcode);
        if (instructionType == null)
        {
            throw new SvmCompilationException($"Invalid instruction: {opcode}");
        }

        return (IInstruction)Activator.CreateInstance(instructionType);
    }



    internal static IInstruction CompileInstruction(string opcode, params string[] operands)
    {
        Type instructionType = FindInstructionType(opcode);
        if (instructionType == null)
        {
            throw new SvmCompilationException($"Invalid instruction: {opcode}");
        }

        var instruction = (IInstructionWithOperand)Activator.CreateInstance(instructionType);
        instruction.Operands = operands;

        return instruction;
    }
    private static Type FindInstructionType(string opcode)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(IInstruction).IsAssignableFrom(type) &&
                    string.Equals(type.Name, opcode, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
        }

        return null;
    }
    #endregion
}
