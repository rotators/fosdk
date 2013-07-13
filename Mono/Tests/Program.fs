module Tests.Main

open System
open FOnline

type Player(cr) =
    inherit GameType()
    do base.HandleGameType(cr)
        
    member val Coins = 0 with get, set
   
type NukaColaMachine(amount, coins, machine:Item) as self =
    inherit GameType()
    
    do
     self.Event(machine.Use(fun e ->
         if self.Amount > 0 then
             self.HandleGameType<Player>(e.Cr, fun player ->
                 if player.Coins > 0 then
                     player.Coins <- player.Coins - 1
                     self.Coins <- self.Coins + 1
                     self.Amount <- self.Amount - 1 )))
       
    member val Amount = amount with get, set
    member val Coins = coins with get, set
        
open Foq
open FOnline

[<EntryPoint>]
let main args = 
    let cr = Mock.Of<Critter>()
    let item = Mock.Of<Item>()
    let player = new Player(cr)
    player.Coins <- 10
    let machine = new NukaColaMachine(10, 1, item)
    item.RaiseUse(cr, null, null, IntPtr.Zero) |> ignore
    printfn "%d, %d" machine.Amount machine.Coins
    0

