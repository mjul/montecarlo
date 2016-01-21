#I @"packages/FSharp.Core/lib/net40"
#I @"packages/FSharp.Data/lib/net40"
#I @"packages/MathNet.Numerics/lib/net40"
#I @"packages/MathNet.Numerics.FSharp/lib/net40"

#r "FSharp.Data"
#r "MathNet.Numerics"
#r "MathNet.Numerics.FSharp"

open FSharp.Data
open MathNet.Numerics.Distributions
open MathNet.Numerics.Random
open MathNet.Numerics.Statistics

type Budget = CsvProvider<"budget.csv", ";">
type Range = {Min: float; Max: float}

let ranges (fname : string) =
    Budget.Load(fname).Rows
    |> Seq.map (fun l -> {Min=float l.``Low Estimate``; Max=float l.``High Estimate``})

let simulate (r : Range) =
    let midpoint = (r.Max + r.Min)/2.0
    Triangular.Sample (r.Min, r.Max, midpoint)

let scenario rs =
    rs
    |> Seq.map simulate

// Infinite lazy sequency of simulated scenarios
let scenarios rs =
    seq { while true do
              yield Seq.sum (scenario rs) }

let monteCarlo repetitions rs =
    Seq.take repetitions (scenarios rs)


let input = ranges @"budget.csv"
let samples = (monteCarlo 10000 input)


printfn "Mean: %f -- 25%%: %f -- 75%% %f " (Statistics.Mean samples) (Statistics.LowerQuartile samples) (Statistics.UpperQuartile samples)

