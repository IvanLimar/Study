module iterator

open System.Collections.Generic

type TreeIterator<'a>(ls : list<'a>) =
    let fullList = if ls.IsEmpty then List.empty
                                 else ls.Head :: ls
    let mutable currentList = fullList
    
    interface IEnumerator<'a> with
        member iter.Current
            with get() = currentList.Head :> obj
        member iter.Current
            with get() = currentList.Head
        member iter.MoveNext() =
            match currentList with
                | (head :: tail) -> currentList <- tail
                                    not tail.IsEmpty
                | [] -> false
        member iter.Reset() = currentList <- fullList
        member iter.Dispose() = ()