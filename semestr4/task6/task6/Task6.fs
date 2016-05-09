type RoundBuilder(precision : int) =
    member this.Bind(x : float, f: float -> float) = System.Math.Round(f x, precision)
    member this.Return(x) = x
    
let rounding precision = new RoundBuilder(precision)

rounding 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    
type ExpressionBuilder() =
    member this.Bind(x, f) =
        let mutable number = 0.0
        let parseResult = System.Double.TryParse(x, &number)
        match parseResult with
            | false -> None
            | true -> f number
    member this.Return(x) = Some(x)
    
let strexpr = ExpressionBuilder()
    
strexpr {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    
strexpr {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    }