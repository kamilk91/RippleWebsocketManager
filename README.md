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
- ```Install-Package RippleSocketManager -Version 1.0.0	```
- ```dotnet add package RippleSocketManager --version 1.0.0	```
- ```paket add RippleSocketManager --version 1.0.0```

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
- account_tx 
-  account_info 
-  account_lines 
-  account_offers 
-  account_currencies 
-  tx 
-  tx_history 
-  sign_and_submit 
-  server_info 
-  server_state 
-  ping 
-  subscribe 
-  unsubscribe 
-  ledger 
-  ledger_closed 
-  ledger_current 
-  ledger_entry 
-  transaction_entry 
