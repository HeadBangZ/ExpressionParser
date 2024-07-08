# ExpressionParser

The solution is divided into 3 projects

ExpressionParser.Cli - The Commandline Program where the program is executed
ExpressionParser.Tests - The unittests for the solution (Using xUnit)
ExpressionParser - The code which handles the logic for the parser

## ExpressionParser Library
The expression parser Library, contains the following:
- Enums
  - TokenType
- Evaluable
- Lexer
- Token
- Node
- Parser

### TokenType
Contains a list of all the different token values

### Evaluable
Takes care of the evaluation of the AST tree when it is created and makes sure the operators are correctly chosen when the calculation is needed, this is also created as a Singleton

### Lexer
Does the tokenization of the expressions, I am using a Queue<Token>

### Token
Has two readonly properties _type which is of type TokenType and _value which is of type object?

### Node
Has three properties all public with get and set, Left and Right which are of type INode and Data which is of type Token

### Parser
Then we have the Parser, the parser is responsible for creating the AST (Abstracy Syntax Tree) tree, and it has a method called Parse which takes a queue of tokens