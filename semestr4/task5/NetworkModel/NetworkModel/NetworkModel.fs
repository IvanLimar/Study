module Network

open ComputerModel

type Network(adjacencyMatrix : array<array<bool>>, computersList : array<Computer>, probabilisticFunction) =
    let mutable mInfectedComputers = List.empty
    let mutable mComputers = computersList
    let updateList (ls : list<int>) (index : int) =
        if (mComputers.[index].IsInfected && not(List.exists ((=) index) ls))
        then (index :: ls)
        else ls
    do
        for i in [0..computersList.Length - 1] do
            mInfectedComputers <- updateList mInfectedComputers i
    member network.InfectedComputers
        with get() = mInfectedComputers
    member network.MakeTurn =
        let mutable infectedComputersAtThisTurn = List.empty
        for i in [0..mComputers.Length - 1] do if (mComputers.[i].IsInfected && not(List.exists ((=) i) infectedComputersAtThisTurn))
                                               then for j in [0..mComputers.Length - 1] do if (i <> j && adjacencyMatrix.[i].[j] && not(mComputers.[j].IsInfected))
                                                                                           then mComputers.[j].TryInfect probabilisticFunction
                                                                                           mInfectedComputers <- updateList mInfectedComputers j
                                                                                           infectedComputersAtThisTurn <- updateList infectedComputersAtThisTurn j                        