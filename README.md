# Warning

**Never use your Private Key (seed, hash, whatever) when connected to public node!**

# RippleWebsocketManager
Wrapper to Ripple Websocket methods.

To use correctly You have to:

 - Start new instance
 - Use methods from method lists 
 - Start websocket (do it in new thread - watch into Usage ) 
 
 
 When you using data parser, you just receiving new data from que named **incoming**. Use **incoming.Dequeue()**, then parse like a normal json by for example '''["status"]''' 

# NugetPackageManager
- [Use this url to check NuggetPackage Store](https://www.nuget.org/packages/RippleSocketManager/ "Use this url to check NuggetPackage Store")
- ```Install-Package RippleSocketManager -Version 2.0.0	```
- ```dotnet add package RippleSocketManager --version 2.0.0	```
- ```paket add RippleSocketManager --version 2.0.0```

# Usage
```
using RippleType;

 static void Main(string[] args)
        {
            RippleImplementation xrp = new RippleImplementation("wss://s.altnet.rippletest.net:51233", debugger: false);
            xrp.RippleServerInfo();
            var t = new Thread(() => xrp.RippleSocketRun());
            t.Start();

            while(true)
            {
                if(xrp.incoming.Count > 0)
                {

                Console.WriteLine(xrp.incoming.Dequeue()["status"]);
                }
            }
        }
```
Will connect you to Ripple websocket based on Ripple Testnet. Where rippleaccount please provide your account.  

# Available methods
When you checking balance, or doing anything with Ripple balances, you have to use "unit" (sorry i dont know how it was called by Ripple). It is exactly counted by yourAmount * (or /) 10^6. 
I made little feature related with that. If you want to simply count Value use

```
new RippleNumbers().RippleToUnit("1.234567");
// where amount is placed with string, or to count nohumanreadableunit to Ripple:
new RippleNumbers().RippleToUnit(10000000000);
// where amount is placed with Double. 
// 
//
// WARNING: IT WASN'T UNITTESTED YOU ARE USING ON OWN RISK, PLEASE CHECK YOUR CALCULATIONS BEFORE DO ANYTHING WITH THIS CLASS !!!!
//
//

```

| Official API  | RippleWebsocketManager |
| ------------- | ------------- |
| ping  | RipplePing()  |
| tx_history  | RippleTXHistory()  |
| server_state  | RippleServerState()  |
| server_info  | RippleServerInfo()  |
| tx  | RippleTX()  |
| account_tx  | RippleAccountTX()  |
| transaction_entry  | RippleTransactionEntry()  |
| account_currencies  | RippleAccountCurrencies()  |
| account_offers  | RippleAccountOffers()  |
| account_lines  | RippleAccountLines()  |
| ledger_entry  | RippleLedgerEntry()  |
| ledger_current  | RippleLedgerCurrent()  |
| ledger_closed  | RippleLedgerClosed()  |
| ledger  | RippleLedger()  |
| subscribe  | RippleSubscribe()  |
| unsubscribe  | RippleUnSubscribe()  |
| sign_and_submit  | RippleSendTransaction()  |
| account_info  | RippleAccountInfo()  |
