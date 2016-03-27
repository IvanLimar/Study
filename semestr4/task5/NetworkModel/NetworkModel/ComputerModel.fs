module ComputerModel

open System

type OperationalSystem = string

type Computer(operationalSystem : OperationalSystem, isInfected) =
    let mutable mIsInfected = isInfected
    let random = Random()
    member computer.IsInfected
        with get() = mIsInfected
    member computer.OperationalSystem
        with get() = operationalSystem
    member computer.TryInfect probabilisticFunction =
        let temp = random.Next(0, 100)
        mIsInfected <- temp < (probabilisticFunction operationalSystem)