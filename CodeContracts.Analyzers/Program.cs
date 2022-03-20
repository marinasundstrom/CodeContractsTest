using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

var programText = await File.ReadAllTextAsync("../../../../ContractsTest/Program.cs");

SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);
CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

foreach (var member in root.Members)
{
    var globalMember = member as GlobalStatementSyntax;
    if (globalMember is not null)
    {
        if (globalMember.Statement is LocalDeclarationStatementSyntax localDeclarationStatement)
        {

        }
        else if (globalMember.Statement is ExpressionStatementSyntax expressionStatement)
        {

        }
        else if (globalMember.Statement is LocalFunctionStatementSyntax localFunctionStatement)
        {

        }
    }
}

Console.WriteLine(root);