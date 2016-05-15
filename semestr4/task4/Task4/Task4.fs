module task4

let isBracketLineCorrect line =
    let rec loop line stack isCorrect =
        let push stack element = element :: stack
        let pop stack = if stack = List.empty then ([], '1') else (stack.Tail, stack.Head)
        let isOpenedBracket symbol = symbol = '(' || symbol = '{' || symbol = '['
        let isClosedBracket symbol = symbol = ')' || symbol = '}' || symbol = ']'
        let opened = if line = List.empty then false else isOpenedBracket line.Head
        let closed = if line = List.empty then false else isClosedBracket line.Head
        match (line, isCorrect, opened, closed) with
            | (head :: tail, true, false, false) -> loop tail stack true
            | (head :: tail, true, true, false) -> loop tail (push stack head) true
            | (head :: tail, true, false, true) -> let (stackPop, symbol) = pop stack
                                                   let reverseBracket bracket =
                                                       match bracket with
                                                           | ')' -> '('
                                                           | '}' -> '{'
                                                           | ']' -> '['
                                                           | _ -> bracket
                                                   loop tail stackPop (reverseBracket head = symbol)
            | (head :: tail, false, _, _) -> false
            | ([], _, _, _) -> isCorrect && stack.IsEmpty
    loop [for i in line -> i] [] true
    
let bracketTest1 = ""
let bracketTest2 = "   (    {     {   [   [   ] ] } } )"
let bracketTest3 = "())("

printfn "%s: %A" bracketTest1 (isBracketLineCorrect bracketTest1)
printfn "%s: %A" bracketTest2 (isBracketLineCorrect bracketTest2)
printfn "%s: %A" bracketTest3 (isBracketLineCorrect bracketTest3)
printfn ""

let func0 x l = List.map (fun y -> y * x) l
let func1 x : int list -> int list = List.map (fun y -> y * x)
let func2 x : int list -> int list = List.map (fun y -> (*) y x)
let func3 x : int list -> int list = List.map ((*) x)
let func4 x : int list -> int list = ((*) x) |> List.map
let func5 : int -> int list -> int list = List.map << (*)

printfn "%A" (func5 3 [1; 1; 1])
printfn ""

type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec mapTree func tree =
    match tree with
        | Tree(value, left, right) -> Tree(func value, mapTree func left, mapTree func right)
        | Tip(value) -> Tip(func value)

let tip = Tip 5
let node = Tree (4, tip, tip)
let testTree = Tree (1, node, tip)

let testResult = mapTree (fun x -> x * 10) testTree

type Expression<'a> =
    | Constant of 'a
    | Variable of ('a -> 'a)
    | Sum of Expression<'a> * Expression<'a>
    | Subtraction of Expression<'a> * Expression<'a>
    | Multiplication of Expression<'a> * Expression<'a>
    | Division of Expression<'a> * Expression<'a>

let rec differentiation expression zero one =
    match expression with
        | Constant(_) -> Constant(zero)
        | Variable(_) -> Constant(one)
        | Sum(first, second) -> Sum(differentiation first zero one, differentiation second zero one)
        | Subtraction(first, second) -> Subtraction(differentiation first zero one, differentiation second zero one)
        | Multiplication(first, second) -> Sum(Multiplication(differentiation first zero one, second), 
                                               Multiplication(first, differentiation second zero one))
        | Division(first, second) -> Division(Subtraction(Multiplication(differentiation first zero one, second), 
                                                          Multiplication(first, differentiation second zero one)), 
                                              Multiplication(second, second))

let rec simplify expression (zero, one, sum, sub, mult, div) =
    let field = (zero, one, sum, sub, mult, div)
    match expression with
        | Constant(value) -> Constant(value)
        | Variable(var) -> Variable(var)
        | Sum(first, second) -> match (first, second) with
                                    | (Constant(value1), Constant(value2)) -> Constant(sum value1 value2)
                                    | (_, _) -> Sum(simplify first field, simplify second field)

        | Subtraction(first, second) -> match (first, second) with
                                            | (Constant(value1), Constant(value2)) -> Constant(sub value1 value2)
                                            | (_, _) -> Subtraction(simplify first field, simplify second field)

        | Multiplication(first, second) -> match (first, second) with
                                               | (Constant(value1), Constant(value2)) -> Constant(mult value1 value2)
                                               | (Constant(value), expr) | (expr, Constant(value)) -> 
                                                                            match value with
                                                                                | nil when nil = zero -> Constant(zero)
                                                                                | fst when fst = one -> simplify expr field
                                                                                | _ -> Multiplication(Constant(value), simplify expr field)
                                               | (expr1, expr2) -> Multiplication(simplify expr1 field, simplify expr2 field)

        | Division(first, second) -> match (first, second) with
                                        | (Constant(value1), Constant(value2)) -> Constant(div value1 value2)
                                        | (Constant(value), expr) -> if value = zero
                                                                     then Constant(zero)
                                                                     else Division(Constant(value), simplify expr field)
                                        | (expr, Constant(value)) -> if value = one
                                                                     then simplify expr field
                                                                     else Division(simplify expr field, Constant(value))
                                        | (expr1, expr2) -> Division(simplify expr1 field, simplify expr2 field)

let id x = x
let expression = Division(Sum(Variable(id), Constant(1)), Multiplication(Variable(id), Variable(id)))
let derivative = differentiation expression 0 1
let simplifyExpression = simplify derivative (0, 1, (+), (-), (*), (/))