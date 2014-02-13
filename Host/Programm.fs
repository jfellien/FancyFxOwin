open FancyFxOwin
open System

let maxConnections = 12
let defaultReturnValue = 0

[<EntryPoint>]
let main argv = 
        
    Environment().Start maxConnections

    Console.WriteLine "... Zoo is open ..."
    Console.WriteLine "Press a key to close the Zoo"

    Console.ReadLine()

    Console.WriteLine "... Zoo is closed ..."
    defaultReturnValue

