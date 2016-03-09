module task3

let QuantityOfEvenNumbersWithMap ls =
    List.sum (List.map (fun x -> ((x % 2) + 1) % 2) ls)
    
let QuantityOfEvenNumbersWithFilter ls =
    List.length (List.filter (fun x -> x % 2 = 0) ls)
    
let QuantityOfEvenNumbersWithFold ls =
    List.fold (fun x y -> x + ((y % 2) + 1) % 2) 0 ls

let findMaximumNeighbours ls =
    let rec loop ls currentIndex currentMaximum accumulator =
        match (ls, currentIndex) with
            | (head :: tail, 0) -> if tail.IsEmpty then 0 else loop tail 1 (head + tail.Head) 0
            | (head :: tail, _) -> if tail.IsEmpty
                                   then accumulator
                                   else let temp = head + tail.Head
                                        let nextIndex = currentIndex + 1
                                        if temp > currentMaximum
                                        then loop tail nextIndex temp currentIndex
                                        else loop tail nextIndex currentMaximum accumulator
            | ([], 0) -> -1
            | ([], _) -> accumulator
    loop ls 0 0 0

type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a
    
let rec heigthOfTree tree =
    match tree with
        | Tree(_, left, rigth) -> 1 + max (heigthOfTree left) (heigthOfTree rigth)
        | Tip(_) -> 1
        
type ArithmeticalExpression =
    | Number of int
    | Sum of ArithmeticalExpression * ArithmeticalExpression
    | Difference of ArithmeticalExpression * ArithmeticalExpression
    | Multiplication of ArithmeticalExpression * ArithmeticalExpression
    | Division of ArithmeticalExpression * ArithmeticalExpression
    
let rec countExpression expression =
    match expression with
        | Number(_) -> System.Int32.Parse(expression.ToString())
        | Sum(first, second) -> countExpression first + countExpression second
        | Difference(first, second) -> countExpression first - countExpression second
        | Multiplication(first, second) -> countExpression first * countExpression second
        | Division(first, second) -> countExpression first / countExpression second
        
let rowOfPrimeNumbers =
    let primeNumber i =
        let rec loop ls (row : list<'a>) accumulator =
            let currentPrimeNumber = row.Head
            let newRow = List.filter (fun x -> x % currentPrimeNumber <> 0) row
            match ls with
                | (head :: tail) -> loop tail newRow currentPrimeNumber
                | ([]) -> accumulator
        loop [0..i] [2..1000000] 0
    Seq.initInfinite primeNumber