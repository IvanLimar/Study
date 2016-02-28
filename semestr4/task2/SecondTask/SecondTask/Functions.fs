module Functions

let multiplyDigits number = 
    let rec makeList number accumulator =
        match number with
            | negative when negative < 0 -> makeList -number accumulator
            | positive when positive > 0 -> makeList (number / 10) (number % 10 :: accumulator)
            | _ -> accumulator
    List.fold (*) 1 (makeList number List.Empty)

let findFirstPosition ls number =
    let equal x y = x = y
    List.find (equal number) ls

let isPalindrome (line : string) =
    let rec loop ls (line : string) accumulator =
        let equal x y = x = y 
        match (ls, accumulator) with
            | (head :: tail, true) -> loop tail line (equal line.[head] line.[line.Length - 1 - head])
            | (head::tail, false) -> accumulator
            | ([], _) -> accumulator
    loop [0..(line.Length - 1) / 2] line true

let areDifferent ls =
    let sortedLs = List.sort ls
    let rec loop ls accumulator previous =
        let notEqual x y = x <> y
        match (ls, accumulator) with
            | (head :: tail, true) -> loop tail (notEqual head previous) head
            | (head :: tail, false) -> accumulator
            | ([], _) -> accumulator
    loop sortedLs.Tail true sortedLs.Head